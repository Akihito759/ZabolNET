using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wiget.Event;
using Wiget.Model;
using Wiget.View.ViewModel;

namespace Wiget.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        private InformationNeedToChooseGroup _info;
        private bool _detailsViewEnabled = true;
        private bool _groupViewEnabled = false;
        private bool _planViewEnabled = false;
        private bool _isButtonVisible = true;
        private string _course = string.Empty;
        private string _faculty = string.Empty;
        private string _chosenGroup = string.Empty;


        private int _year = 0;
        private ObservableCollection<Subject> _todaySubjects;
        private ObservableCollection<Subject> _tommorowSubjects;

        public ObservableCollection<Subject> TodaySubjects
        {
            get
            {
                return _todaySubjects;
            }
            set
            {
                _todaySubjects = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Subject> TommorowSubjects
        {
            get
            {
                return _tommorowSubjects;
            }
            set
            {
                _tommorowSubjects = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand NextCommand { get; set; }
        public ICommand PreviousCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public string Faculty
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
        public string Course
        {
            get
            {
                return _course;
            }
            set
            {
                _course = value;
                NotifyPropertyChanged();
            }
        }
        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
                NotifyPropertyChanged();
            }
        }
        public string ChosenGroup
        {
            get
            {
                return _chosenGroup;
            }
            set
            {
                _chosenGroup = value;
                NotifyPropertyChanged();
            }
        }

        public bool DetailsViewEnabled
        {
            get
            {
                return _detailsViewEnabled;

            }
            set
            {
                _detailsViewEnabled = value;
                NotifyPropertyChanged();
            }
        }
        public bool GroupViewEnabled
        {
            get
            {
                return _groupViewEnabled;
            }
            set
            {
                _groupViewEnabled = value;
                NotifyPropertyChanged();
            }
        }
        public bool PlanViewEnabled
        {
            get
            {
                return _planViewEnabled;
            }
            set
            {
                _planViewEnabled = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsButtonVisible
        {
            get
            {
                return _isButtonVisible;
            }
            set
            {
                _isButtonVisible = value;
                if (PlanViewEnabled == true)
                {
                    _isButtonVisible = false;
                    NotifyPropertyChanged();
                        }
            }
        }

        //public string Mama {
        //    get
        //    {
        //        return _mama;
        //    }
        //    set
        //    {
        //        _mama = value;
        //        NotifyPropertyChanged();
        //    }
        //}
        //public string Tata
        //{
        //    get
        //    {
        //        return _tata;
        //    }
        //    set
        //    {
        //        _ta = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        public MainViewModel()
        {
            _info = new InformationNeedToChooseGroup();
            NextCommand = new RelayCommand(ExecuteNext, CanExecuteNext);
            PreviousCommand = new RelayCommand(ExecutePrevious, CanExecutePrevious);
            ExitCommand = new RelayCommand(ExecuteExit, CanExecuteExit);
          
            _aggregator.GetEvent<SendInfoToGetGroupFaculty>().Subscribe(item => { Faculty = item; });
            _aggregator.GetEvent<SendInfoToGetGroupCourse>().Subscribe(item => { Course = item; });
            _aggregator.GetEvent<SendInfoToGetGroupYear>().Subscribe(item => { Year = item; });
            _aggregator.GetEvent<SendChosenGroup>().Subscribe(item => { ChosenGroup = item; });

        }

        public void ExecuteNext(object p)
        {
            if(GroupViewEnabled == true)
            {
                GroupViewEnabled = false;
                DetailsViewEnabled = false;
                PlanViewEnabled = true;
                IsButtonVisible = false;
            }
            if(DetailsViewEnabled == true)
            {
                DetailsViewEnabled = false;
                PlanViewEnabled = false;
                GroupViewEnabled = true;
            }
        }
        public bool CanExecuteNext(object p)
        {
            bool mama = false;

            if (!string.IsNullOrEmpty(Faculty) && !string.IsNullOrEmpty(Course) && Year != 0 && _detailsViewEnabled == true)
            {
                
                return true;
            }
            if (!string.IsNullOrEmpty(ChosenGroup) && _groupViewEnabled == true && _detailsViewEnabled == false)
            {
                return true;
            }
            else
                return false;
        }

        public void ExecutePrevious(object p)
        {
            if (GroupViewEnabled == true)
            {
                GroupViewEnabled = false;
                DetailsViewEnabled = true;
                PlanViewEnabled = false;
                
            }
           
        }
        public bool CanExecutePrevious(object p)
        {
            if (DetailsViewEnabled)
                return false;
            else
                return true;
        }

        public void ExecuteExit(object p)
        {
            Application.Current.MainWindow.Close();
        }
        public bool CanExecuteExit(object p)
        {
            return true;
        }
    }
}
