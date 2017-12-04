﻿using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiget.Event
{
  
        public static class GlobalEvent
        {
            private static IEventAggregator _eventAggregator;

            public static IEventAggregator GetEventAggregator()
            {
                if (_eventAggregator == null)
                {
                    _eventAggregator = new EventAggregator();
                }
                return _eventAggregator;
            }
        }
  
}