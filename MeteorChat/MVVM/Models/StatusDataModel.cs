using System;

namespace MeteorChat.MVVM.Models
{
    public class StatusDataModel
    {
        public string ContactName { get; set; }
        public Uri ContactPhoto { get; set; }
        public Uri StatusImage { get; set; }
        public bool IsMeAddStatus { get; set; }
        /// <summary>
        /// We will be covering in one of our upcoming videos
        /// To-Do Status Message
        /// </summary>
        // public string StatusMessage { get => _statusMessage; set => _statusMessage = value; }
    }
}
