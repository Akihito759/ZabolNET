using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZabolNET.Models
{
    public class Year
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YearID { get; set; }
        public int StartYear { get; set; }
        public Course Course { get; set; }
        public List<Group> Groups { get; set; }
        public List<Subject> Subject { get; set; }
    }
}