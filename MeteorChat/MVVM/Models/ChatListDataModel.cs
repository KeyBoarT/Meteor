﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteorChat.MVVM.Models
{
    public class ChatListDataModel
    {
        public string ContactName { get; set; }
        public Uri ContactPhoto { get; set; }
        public string Message { get; set; }
        public string LastMessageTime { get; set; }
        public bool IsSelected { get; set; }
    }
}