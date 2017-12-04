using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiget.Model
{
    public class InformationNeedToChooseGroup
    {
        private string _selectedFaculty;
        public string SelectedFaculty
        {
            get
            {
                return _selectedFaculty;
            }
            set
            {
                _selectedFaculty = value;
                
            }
        }

        private string _selectedCourse;
        public string SelectedCourse
        {
            get
            {
                return _selectedCourse;
            }
            set
            {
                _selectedCourse = value;
                
            }
        }

        private int _selectedYear;
        public int SelectedYear
        {
            get
            {
                return _selectedYear;
            }
            set
            {
                _selectedYear = value;
                
            }
        }

    }
}
