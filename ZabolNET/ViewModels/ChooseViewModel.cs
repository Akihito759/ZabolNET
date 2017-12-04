using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZabolNET.Models;

namespace ZabolNET.ViewModels
{
    public class ChooseViewModel
    {
        public Year Year { get; set; }
        public Faculty Faculty { get; set; }
        public Group Group { get; set; }
        public Course Course { get; set; }
        public List<string> ToChoose { get; set; }
    }
}