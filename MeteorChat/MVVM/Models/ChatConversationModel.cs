using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteorChat.MVVM.Models
{
    public class ChatConversationModel
    {
        public string ContactName { get; set; }
        public string ReceivedMessage { get; set; }
        public string MsgReceiveOn { get; set; }
        public string SentMessage { get; set; }
        public string MsgSentOn { get; set; }
        public bool IsMessageReceived { get; set; }
        public bool MessageContainsReply { get; set; }
    }
}
