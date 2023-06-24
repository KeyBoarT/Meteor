using MeteorChat.Core;
using MeteorChat.MVVM.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Data;

namespace MeteorChat.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        #region Fields
        private string _contactName;
        private Uri _contactPhoto;
        private string _lastSeen;
        private string _messageBox;
        private string _conversationFilter = string.Empty;
        private string _chatFilter = string.Empty;
        private ObservableCollection<StatusDataModel> _statusThumbsCollection = new ObservableCollection<StatusDataModel>();
        private ObservableCollection<ChatListDataModel> _chats = new ObservableCollection<ChatListDataModel>();
        private ObservableCollection<ChatConversationModel> _conversations = new ObservableCollection<ChatConversationModel>();
        private ObservableCollection<ChatListDataModel> _archivedChats = new ObservableCollection<ChatListDataModel>();
        #endregion

        #region Properties
        public string ContactName { get => _contactName; set { _contactName = value; OnPropertyChanged(); } }
        public Uri ContactPhoto { get => _contactPhoto; set { _contactPhoto = value; OnPropertyChanged(); } }
        public string LastSeen { get => _lastSeen; set { _lastSeen = value; OnPropertyChanged(); } }
        public string MessageText { get => _messageBox; set { _messageBox = value; OnPropertyChanged(); } }
        public string ConversationFilter { get => _conversationFilter; set { _conversationFilter = value; OnPropertyChanged(); ConversationsCollectionView.Refresh(); } }
        public string ChatsFilter { get => _chatFilter; set { _chatFilter = value; OnPropertyChanged(); ChatsCollectionView.Refresh(); } }
        public ObservableCollection<StatusDataModel> StatusThumbsCollection { get => _statusThumbsCollection; set { _statusThumbsCollection = value; OnPropertyChanged(); } }
        public ObservableCollection<ChatListDataModel> Chats { get => _chats; set { _chats = value; OnPropertyChanged(); } }
        public ObservableCollection<ChatConversationModel> Conversations { get => _conversations; set { _conversations = value; OnPropertyChanged(); } }
        public ObservableCollection<ChatListDataModel> ArchivedChats { get => _archivedChats; set { _archivedChats = value; OnPropertyChanged(); } }
        public ICollectionView ChatsCollectionView { get; set; }
        public ICollectionView ConversationsCollectionView { get; set; }
        public ICollectionView ArchivedChatsCollectionView { get; set; }
        #endregion

        #region Commands
        public RelayCommand MoveWindowCommand { get; set; }
        public RelayCommand MinimizeWindowCommand { get; set; }
        public RelayCommand CloseWindowCommand { get; set; }
        public RelayCommand MaximizeWindowCommand { get; set; }
        public RelayCommand GetSelectedChatCommand { get; set; }
        public RelayCommand ChangeChatPinStateCommand { get; set; }
        public RelayCommand ChangeChatArchiveStateCommand { get; set; }
        #endregion

        #region Methods
        private void LoadStatusThumbs()
        {

            StatusThumbsCollection = new ObservableCollection<StatusDataModel>()
            {
                //Since we want to keep first status blank for the user to add own status
                new StatusDataModel
                {
                    IsMeAddStatus = true
                },

                new StatusDataModel
                {
                    ContactName = "Mike",
                    ContactPhoto = new Uri("/assets/1.png", UriKind.RelativeOrAbsolute),
                    StatusImage = new Uri("/assets/2.jpg", UriKind.RelativeOrAbsolute),
                    IsMeAddStatus = false
                },
                new StatusDataModel
                {
                    ContactName = "Steve",
                    ContactPhoto = new Uri("/assets/2.jpg", UriKind.RelativeOrAbsolute),
                    StatusImage = new Uri("/assets/8.jpg", UriKind.RelativeOrAbsolute),
                    IsMeAddStatus = false
                },
                new StatusDataModel
                {
                    ContactName = "Will",
                    ContactPhoto = new Uri("/assets/1.png", UriKind.RelativeOrAbsolute),
                    StatusImage = new Uri("/assets/2.jpg", UriKind.RelativeOrAbsolute),
                    IsMeAddStatus = false
                },
                new StatusDataModel
                {
                    ContactName = "Dımbık",
                    ContactPhoto = new Uri("/assets/3.jpg", UriKind.RelativeOrAbsolute),
                    StatusImage = new Uri("/assets/3.jpg", UriKind.RelativeOrAbsolute),
                    IsMeAddStatus = false
                }
            };
            //Demo StatusThumbs
        }
        private void AssignCommands()
        {
            //Assign the commands
            MoveWindowCommand = new RelayCommand(o => (o as Window).DragMove());
            MinimizeWindowCommand = new RelayCommand(o => (o as Window).WindowState = WindowState.Minimized);
            CloseWindowCommand = new RelayCommand(o => Application.Current.Shutdown());
            MaximizeWindowCommand = new RelayCommand(o =>
            (o as Window).WindowState =
            (o as Window).WindowState == WindowState.Maximized
            ? WindowState.Normal
            : WindowState.Maximized);

            GetSelectedChatCommand = new RelayCommand(o =>
            {
                if (o is ChatListDataModel v)
                {
                    ContactName = v.ContactName;
                    ContactPhoto = v.ContactPhoto;
                    LastSeen = v.LastMessageTime;
                    LoadChatConversation(ContactName);
                }
            });
            ChangeChatPinStateCommand = new RelayCommand(o =>
            {
                if (o is ChatListDataModel v)
                {
                    v.IsPinned = !v.IsPinned;
                }
                ChatsCollectionView.Refresh();
                ArchivedChatsCollectionView.Refresh();
            });
            ChangeChatArchiveStateCommand = new RelayCommand(o =>
            {
                //1 Arşivde mi, değil mi kontrol et
                //2 Arşivde değil ise...
                //2.1 Arşivlenmiş işaretini ekle
                //3 Arşivde ise
                //3.1 Arşivden Kaldır
                //4 İki tarafı da refreshle

                if (o is ChatListDataModel model)
                {
                    if (model.IsArchived)
                    {
                        model.IsArchived = false;
                        ArchivedChats.Remove(model);
                        Chats.Add(model);
                        //To-Do: Sql Update
                    }
                    else
                    {
                        model.IsArchived = true;
                        ArchivedChats.Add(model);
                        Chats.Remove(model);
                        //To-Do: Sql Update
                    }
                }
            });
        }
        private void LoadChats()
        {
            Chats = new ObservableCollection<ChatListDataModel>()
            {
                new ChatListDataModel()
                {
                    ContactName = "Billy",
                    ContactPhoto = new Uri("/assets/8.jpg", UriKind.RelativeOrAbsolute),
                    Message = "What'up my nigga",
                    LastMessageTime = "Tue, 12:59 PM",
                    IsSelected = true,
                    IsPinned = true
                },
                new ChatListDataModel()
                {
                    ContactName = "Mike",
                    ContactPhoto = new Uri("/assets/1.png", UriKind.RelativeOrAbsolute),
                    Message = "What'up my nigga",
                    LastMessageTime = "Tue, 12:54 PM",
                    IsSelected = false
                },
                new ChatListDataModel()
                {
                    ContactName = "Selam",
                    ContactPhoto = new Uri("/assets/3.jpg", UriKind.RelativeOrAbsolute),
                    Message = "What'up my nigga",
                    LastMessageTime = "Tue, 09:24 PM",
                    IsSelected = false
                },
                new ChatListDataModel()
                {
                    ContactName = "Dımbık",
                    ContactPhoto = new Uri("/assets/1.png", UriKind.RelativeOrAbsolute),
                    Message = "What'up my nigga",
                    LastMessageTime = "Tue, 11:59 AM",
                    IsSelected = false,
                    IsPinned = true
                }
            };
            ArchivedChats = new ObservableCollection<ChatListDataModel>
            {
               new ChatListDataModel()
                {
                    ContactName = "Mehmet",
                    ContactPhoto = new Uri("/assets/1.png", UriKind.RelativeOrAbsolute),
                    Message = "What'up my nigga",
                    LastMessageTime = "Tue, 12:54 PM",
                    IsSelected = false,
                    IsArchived = true
                },
                new ChatListDataModel()
                {
                    ContactName = "Samet",
                    ContactPhoto = new Uri("/assets/1.png", UriKind.RelativeOrAbsolute),
                    Message = "What'up my nigga",
                    LastMessageTime = "Tue, 12:54 PM",
                    IsSelected = false,
                    IsArchived = true
                }
            };
        }
        private void LoadChatConversation(string name)
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
            if (_conversations == null) _conversations = new ObservableCollection<ChatConversationModel>();
            using (SqlCommand com = new SqlCommand($"select * from conversations where ContactName='{name}'", _connection))
            {
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    Conversations.Clear();
                    while(reader.Read())
                    {
                        string MsqReceivedOn = !string.IsNullOrEmpty(reader["MsgReceivedOn"].ToString()) ? Convert.ToDateTime(reader["MsgReceivedOn"].ToString()).ToString("MMM dd, hh:mm tt") : "";
                        string MsgSentOn = !string.IsNullOrEmpty(reader["MsgSentOn"].ToString()) ? Convert.ToDateTime(reader["MsgSentOn"].ToString()).ToString("MMM dd, hh:mm tt") : "";

                        ChatConversationModel conversation = new ChatConversationModel()
                        {
                            ContactName = reader["ContactName"].ToString(),
                            ReceivedMessage = reader["ReceivedMsgs"].ToString(),
                            MsgReceivedOn = MsqReceivedOn,
                            SentMessage = reader["SentMsgs"].ToString(),
                            MsgSentOn = MsgSentOn,
                            IsMessageReceived = !string.IsNullOrEmpty(reader["ReceivedMsgs"].ToString())
                        };
                        Conversations.Add(conversation);
                    }
                }
            }
        }
        private void SetConversationFilter()
        {
            //For Conversation Filter
            ConversationsCollectionView = CollectionViewSource.GetDefaultView(Conversations);
            ConversationsCollectionView.Filter = o => FilterConversation(o);
        }
        private void SetChatFilter()
        {
            //For Chat Filter
            ChatsCollectionView = CollectionViewSource.GetDefaultView(Chats);
            ChatsCollectionView.Filter = o => FilterChats(o);

            //following code is to keep the pinned chats always up.
            ChatsCollectionView.SortDescriptions.Add(new SortDescription("IsPinned", ListSortDirection.Descending));
        }
        private void SetArchivedChatFilter()
        {
            ArchivedChatsCollectionView = CollectionViewSource.GetDefaultView(ArchivedChats);
            ArchivedChatsCollectionView.SortDescriptions.Add(new SortDescription("IsPinned", ListSortDirection.Descending));
        }
        private bool FilterConversation(object o)
        {
            return o is ChatConversationModel model
                && (model.ReceivedMessage.ToLower().Contains(ConversationFilter.ToLower()) || model.SentMessage.ToLower().Contains(ConversationFilter.ToLower()));
        }
        private bool FilterChats(object o)
        {
            return o is ChatListDataModel model && model.ContactName.ToLower().Contains(ChatsFilter.ToLower());
        }
        #endregion

        #region Database
        /// <summary>
        /// Bu kısım daha sonra güncellenecek, şimdilik proje tasarımını görmek için oluşturulmuş bir database kullanacağız
        /// </summary>

        private readonly SqlConnection _connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mehme\source\repos\MeteorChat\MeteorChat\Database\Database1.mdf;Integrated Security=True");
        #endregion

        public MainViewModel()
        {
            AssignCommands();
            LoadStatusThumbs();
            LoadChats();
            //LoadChatConversation();
            SetConversationFilter();
            SetChatFilter();
            SetArchivedChatFilter();
        }
    }
}
