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
        public Group Group { get; set; }
        public DateTime RecordDate { get; set; }
        public Subject Subject { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string RecordType { get; set; }
        public int Difficulty { get; set; }
    }
}