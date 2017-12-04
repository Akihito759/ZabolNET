using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZabolNET.Models
{
    public class Course
    {
        public Course()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public virtual List<Year> Years { get; set; }
        public int FacultyID { get; set; }
        //public virtual Faculty Faculty { get; set; }
    }
}