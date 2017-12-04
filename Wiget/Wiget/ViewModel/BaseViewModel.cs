using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wiget.Event;

namespace Wiget.ViewModel
{
    public class BaseViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void NotifyPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        protected IEventAggregator _aggregator = GlobalEvent.GetEventAggregator();

        private bool _canGoForward;
        private bool _canGoBack;

        public bool CanGoForward
        {
            get
            {
                return _canGoForward;
            }

            set
            {
                _canGoForward = value;
                NotifyPropertyChanged();
            }
        }

        public bool CanGoBack
        {
            get
            {
                return _canGoBack;
            }

            set
            {
                _canGoBack = value;
                NotifyPropertyChanged();
            }
        }
    }
}
