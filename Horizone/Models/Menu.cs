using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public int Order { get; set; }
        public Byte Status { get; set; }
        public string Target { get; set; }
    }
}