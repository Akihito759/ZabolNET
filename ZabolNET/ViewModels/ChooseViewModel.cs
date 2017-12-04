using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZabolNET.Models;

namespace ZabolNET.ViewModels
{
    public class ChooseViewModel
    {
        public int Year { get; set; }
        public string Faculty { get; set; }
        public string Group { get; set; }
        public string Course { get; set; }
        public List<string> ToChoose { get; set; }
    }
}