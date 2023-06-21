using MeteorChat.Core;
using MeteorChat.MVVM.Models;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace MeteorChat.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        #region Fields
        private string _contactName;
        private Uri _contactPhoto;
        private string _lastSeen;
        private ObservableCollection<StatusDataModel> _statusThumbsCollection = new ObservableCollection<StatusDataModel>();
        private ObservableCollection<ChatListDataModel> _chats = new ObservableCollection<ChatListDataModel>();
        private ObservableCollection<ChatConversationModel> _conversations = new ObservableCollection<ChatConversationModel>();
        #endregion

        #region Properties
        public string ContactName { get => _contactName; set { _contactName = value; OnPropertyChanged(); } }
        public Uri ContactPhoto { get => _contactPhoto; set { _contactPhoto = value; OnPropertyChanged(); } }
        public string LastSeen { get => _lastSeen; set { _lastSeen = value; OnPropertyChanged(); } }
        public ObservableCollection<StatusDataModel> StatusThumbsCollection { get => _statusThumbsCollection; set { _statusThumbsCollection = value; OnPropertyChanged(); } }
        public ObservableCollection<ChatListDataModel> Chats { get => _chats; set { _chats = value; OnPropertyChanged(); } }
        public ObservableCollection<ChatConversationModel> Conversations { get => _conversations; set { _conversations = value; OnPropertyChanged(); } }
        #endregion

        #region Commands
        public RelayCommand MoveWindowCommand { get; set; }
        public RelayCommand MinimizeWindowCommand { get; set; }
        public RelayCommand CloseWindowCommand { get; set; }
        public RelayCommand MaximizeWindowCommand { get; set; }
        public RelayCommand GetSelectedChatCommand { get; set; }
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
                    IsSelected = true
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
                    IsSelected = false
                }
            };
        }
        private void LoadChatConversation()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
            if (_conversations == null) { _conversations = new ObservableCollection<ChatConversationModel>(); }
            using (SqlCommand com = new SqlCommand("select * from conversations where ContactName='Mike'", _connection))
            {
                using (SqlDataReader reader = com.ExecuteReader())
                {
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
            LoadChatConversation();
        }

    }
}
