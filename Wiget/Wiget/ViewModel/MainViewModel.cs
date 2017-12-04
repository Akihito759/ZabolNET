using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wiget.View.ViewModel;

namespace Wiget.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        private bool _detailsViewEnabled = true;
        private bool _groupViewEnabled = false;
        private bool _planViewEnabled = false;
        private bool _isButtonVisible = true;

        public ICommand NextCommand { get; set; }
        public ICommand PreviousCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        

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

        public MainViewModel()
        {
            NextCommand = new RelayCommand(ExecuteNext, CanExecuteNext);
            PreviousCommand = new RelayCommand(ExecutePrevious, CanExecutePrevious);
            ExitCommand = new RelayCommand(ExecuteExit, CanExecuteExit);
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
            return true;
        }

        public void ExecutePrevious(object p)
        {
            if (GroupViewEnabled == true)
            {
                DetailsViewEnabled = true;
                PlanViewEnabled = false;
                GroupViewEnabled = false;
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
