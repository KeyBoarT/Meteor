using MeteorChat.Core;
using MeteorChat.MVVM.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;

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
        private ObservableCollection<ChatConversationModel> _conversation = new ObservableCollection<ChatConversationModel>();
        #endregion

        #region Properties
        public string ContactName { get { return _contactName; } set { _contactName = value; OnPropertyChanged(); } }
        public Uri ContactPhoto { get { return _contactPhoto; } set { _contactPhoto = value; OnPropertyChanged(); } }
        public string LastSeen { get { return _lastSeen; } set { _lastSeen = value; OnPropertyChanged(); } }
        public ObservableCollection<StatusDataModel> StatusThumbsCollection { get => _statusThumbsCollection; set { _statusThumbsCollection = value; OnPropertyChanged(); } }
        public ObservableCollection<ChatListDataModel> Chats { get => _chats; set { _chats = value; OnPropertyChanged(); } }
        public ObservableCollection<ChatConversationModel> Conversation { get => _conversation; set { _conversation = value; OnPropertyChanged(); } }
        #endregion

        #region Commands
        public RelayCommand MoveWindowCommand { get; set; }
        public RelayCommand MinimizeWindowCommand { get; set; }
        public RelayCommand CloseWindowCommand { get; set; }
        public RelayCommand MaximizeWindowCommand { get; set; }
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
            MoveWindowCommand = new RelayCommand(o => { (o as Window).DragMove(); });
            MinimizeWindowCommand = new RelayCommand(o => (o as Window).WindowState = WindowState.Minimized);
            CloseWindowCommand = new RelayCommand(o => Application.Current.Shutdown());
            MaximizeWindowCommand = new RelayCommand(o =>
            (o as Window).WindowState =
            (o as Window).WindowState == WindowState.Maximized
            ? WindowState.Normal
            : WindowState.Maximized);
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

        }
        #endregion

        #region Database
        /// <summary>
        /// Bu kısım daha sonra güncellenecek
        /// </summary>
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
