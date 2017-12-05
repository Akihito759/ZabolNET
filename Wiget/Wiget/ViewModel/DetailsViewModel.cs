using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiget.Event;
using Wiget.Model;

namespace Wiget.ViewModel
{
    public class DetailsViewModel:BaseViewModel
    {
        private ObservableCollection<string> _faculty = new ObservableCollection<string>();
        private ObservableCollection<string> _courses = new ObservableCollection<string>();
        private List<int> _years = new List<int>();

        
        private string _selectedFaculty;
        public ObservableCollection<string> Faculty
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
        public string SelectedFaculty
        {
            get
            {
                return _selectedFaculty;
            }
            set
            {
                _selectedFaculty = value;
                _aggregator.GetEvent<SendInfoToGetGroupFaculty>().Publish(SelectedFaculty);
                if (SelectedFaculty == "AEiI")
                {
                    Courses.Clear();
                    Courses.Add("AiR");
                    Courses.Add("Makrokierunek");
                    Courses.Add("Elektrotecghnika");
                }
                if (SelectedFaculty == "IB")
                {
                    Courses.Clear();
                    Courses.Add("Inżynieria biomedyczna");

                }
                if (
                    SelectedFaculty == "MT - Muzyczno - Taneczny")
                {
                    Courses.Clear();
                    Courses.Add("Nanotechnologia");
                    Courses.Add("AiR");
                }
                NotifyPropertyChanged();
            }
        }

        private string _selectedCourse;
        public ObservableCollection<string> Courses
        {
            get
            {
                return _courses;
            }
            set
            {
                _courses = value;
                NotifyPropertyChanged();
            }
        }
        public string SelectedCourse
        {
            get
            {
                return _selectedCourse;
            }
            set
            {
                _selectedCourse = value;
                _aggregator.GetEvent<SendInfoToGetGroupCourse>().Publish(SelectedCourse);
                
                
                Years.Add(2017);
                Years.Add(2016);
                Years.Add(2015);
                NotifyPropertyChanged();
            }
        }

        private int _selectedYear;
        public List<int> Years
        {
            get
            {
                return _years;
            }
            set
            {
                _years = value;
                NotifyPropertyChanged();
            }
        }
        public int SelectedYear
        {
            get
            {
                return _selectedYear;
            }
            set
            {
                _selectedYear = value;
                NotifyPropertyChanged();
                _aggregator.GetEvent<SendInfoToGetGroupYear>().Publish(SelectedYear);
            }
        }



        public DetailsViewModel()
        {
            Faculty = new ObservableCollection<string>();
            Years = new List<int>();
            Courses = new ObservableCollection<string>();
            Faculty.Add("AEiI");
            Faculty.Add("IB");
            Faculty.Add("MT - Muzyczno - Taneczny");


            _aggregator.GetEvent<SendInfoToGetGroupFaculty>().Publish(SelectedFaculty);
            _aggregator.GetEvent<SendInfoToGetGroupCourse>().Publish(SelectedCourse);
            _aggregator.GetEvent<SendInfoToGetGroupYear>().Publish(SelectedYear);
        }
    }
}
