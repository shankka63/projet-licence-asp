using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entites
{
    [Table("APP_Absence")]
    public class Absence
    {
        [Key]
        public int AbsenceId { get; set; }

        [StringLength(100)]
        [Required]
        public string Motif { get; set; }

        [Required]
        public DateTime DateAbsence { get; set; }

        public int EleveId { get; set; }

        [ForeignKey("EleveId")]
        public Eleve Eleve { get; set; }
    }
}
