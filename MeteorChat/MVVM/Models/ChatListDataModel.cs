using System;

namespace MeteorChat.MVVM.Models
{
    public class ChatListDataModel
    {
        public string ContactName { get; set; }
        public Uri ContactPhoto { get; set; }
        public string Message { get; set; }
        public string LastMessageTime { get; set; }
        public bool IsSelected { get; set; }
        public bool IsPinned { get; set; }
        public bool IsArchived { get; set; }
    }
}
