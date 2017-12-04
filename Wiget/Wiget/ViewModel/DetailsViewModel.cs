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
        private List<string> _courses = new List<string>();
        private List<int> _years = new List<int>();

        private string _selectedFaculty;
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
        public string SelectedFaculty
        {
            get
            {
                return _selectedFaculty;
            }
            set
            {
                _selectedFaculty = value;
                NotifyPropertyChanged();
            }
        }

        private string _selectedCourse;
        public List<string> Courses
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
                NotifyPropertyChanged();
            }
        }

        private string _selectedYear;
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
        public string SelectedYear
        {
            get
            {
                return _selectedYear;
            }
            set
            {
                _selectedYear = value;
                NotifyPropertyChanged();
            }
        }



        public DetailsViewModel()
        {
            Faculty = new List<string>();
            Years = new List<int>();
            Courses = new List<string>();
            Faculty.Add("AEiI");
            Faculty.Add("IB");
        }
    }
}
