using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class Message
    {
        public MessageType MessageType { get; set; }
        public string Text { get; set; }

        public Message(MessageType messageType, string text)
        {
            MessageType = messageType;
            Text = text;
        }
    }


    public enum MessageType
    {
        SUCCES, ERROR
    }
}