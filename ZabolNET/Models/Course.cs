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
        public List<Year> Years { get; set; }
        public Faculty Faculty { get; set; }
    }
}