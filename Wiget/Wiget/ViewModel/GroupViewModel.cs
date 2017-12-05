using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiget.Event;

namespace Wiget.ViewModel
{
    public class GroupViewModel:BaseViewModel
    {
        private string _selectedElement;
        private List<string> _listOfGroups = new List<string>();
        public List<string> ListOfGroups
        {
            get
            {
                return _listOfGroups;
            }
            set
            {
                _listOfGroups = value;
                NotifyPropertyChanged();
            }
        }
        public string SelectedElement
        {
            get
            {
                return _selectedElement;
            }
            set
            {
                _selectedElement = value;
                _aggregator.GetEvent<SendChosenGroup>().Publish(SelectedElement);
                NotifyPropertyChanged();
            }
        }
        public GroupViewModel()
        {
            ListOfGroups = new List<string>();
            ListOfGroups.Add("Grupa I");
            ListOfGroups.Add("Grupa II");
            ListOfGroups.Add("Grupa III");
            ListOfGroups.Add("Grupa IV");
            
            
        }
    }
}
