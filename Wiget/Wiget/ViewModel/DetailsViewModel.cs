using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiget.ViewModel
{
    public class DetailsViewModel:BaseViewModel
    {
        private List<string> _faculty = new List<string>();
        public string SingleFacul;
        public List<string> Faculty
        {
            get
            {
                return _faculty;
            }
            set
            {
                _faculty = value;
                NotifyPropertyChanged();
            }
        }


        public DetailsViewModel()
        {
            Faculty = new List<string>(); 
            Faculty.Add("AEiI");
            Faculty.Add("IB");
        }
    }
}
