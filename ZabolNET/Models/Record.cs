using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZabolNET.Models
{
    public class Record
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecordID { get; set; }
        //public virtual Group Group { get; set; }
        public int GroupID { get; set; }
        public virtual DateTime RecordDate { get; set; }
        //public virtual Subject Subject { get; set; }
        public int SubjectID { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string RecordType { get; set; }
        public int Difficulty { get; set; }
    }
}