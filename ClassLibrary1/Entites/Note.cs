using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entites
{
    [Table("APP_Note")]
    public class Note
    {
        [Key]
        public int NoteId { get; set; }

        [StringLength(60)]
        [Required]
        public string Matiere { get; set; }

        [StringLength(100)]
        [Required]
        public string Appreciation { get; set; }

        [Required]
        public DateTime DateNote { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Required]
        public int Notation { get; set; }

        public int EleveId { get; set; }

        [ForeignKey("EleveId")]
        public Eleve Eleve { get; set; }
    }
}
