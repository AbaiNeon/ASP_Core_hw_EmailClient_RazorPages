﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Message
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
