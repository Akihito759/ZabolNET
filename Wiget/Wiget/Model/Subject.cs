using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiget.Model
{
    public class Subject
    {
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public  int Diff { get; set; }
        public string RecordType { get; set; }
        public string DiffVer2 {
            get
            { return "Truność wynosi - " + Diff; } }
    }
}
