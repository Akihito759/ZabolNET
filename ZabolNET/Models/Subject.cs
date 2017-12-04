using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZabolNET.Models
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectID { get; set;}
        //public virtual Year Year { get; set; }
        public int YearID { get; set; }
        public string SubjectName { get; set; }
    }
}