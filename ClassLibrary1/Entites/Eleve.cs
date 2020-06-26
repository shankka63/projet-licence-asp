using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entites
{
    [Table("APP_Eleve")]
    public class Eleve
    {

        public Eleve()
        {
            absences = new List<Absence>();
            notes = new List<Note>();
        }

        [Key]
        public int EleveId { get; set; }

        [StringLength(60)]
        [Required]
        public string Nom { get; set; }

        [StringLength(20)]
        [Required]
        public string Prenom { get; set; }

        [Required]
        public DateTime DateNaissance { get; set; }

        public int ClasseId { get; set; }

        [ForeignKey("ClasseId")]
        public Classe Classe { get; set; }


        public ICollection<Absence> absences { get; set; }
        public ICollection<Note> notes { get; set; }
    }
}
