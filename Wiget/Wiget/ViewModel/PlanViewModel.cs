using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiget.Model;

namespace Wiget.ViewModel
{
    public class PlanViewModel:BaseViewModel
    {
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
        public PlanViewModel()
        {
            TodaySubjects = new ObservableCollection<Subject>();
            TommorowSubjects = new ObservableCollection<Subject>();
            TodaySubjects.Add(new Subject
            {
                Diff = 5,
                LongDesc = "Przerąbane, punkty ujemne, nie mamy materiałów z zeszłych lat",
                Name = "Teoria obwodów cyfrowych",
                RecordType = "Kolokwium",
                ShortDesc = "Kolos - punkty ujemne, tragedia"
            });
            TommorowSubjects.Add(new Subject
            {
                Diff = 1,
                LongDesc = "Wejściówka z podstaw programowania, nic trudnego, wystarczy poczytać trochę o polimofizmie i predykatach, materiały są na dysku roku",
                Name = "Programowanie obiektowe",
                RecordType = "Wejściówka",
                ShortDesc = "Wejściówka - nic trudnego"
            });
        }

    }
}
