using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZabolNET.Models
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        //public virtual Year Year { get; set; }
        public int YearID { get; set; }
        //public virtual List<Subject> Subjects { get; set; }
        public virtual List<Record> Records { get; set; }
    }
}