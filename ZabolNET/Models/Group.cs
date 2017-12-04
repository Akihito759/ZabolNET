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
        public Year Year { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Record> Records { get; set; }
    }
}