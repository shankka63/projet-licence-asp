using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entites
{
    [Table("APP_Classe")]
    public class Classe
    {
        public Classe()
        {
            eleves = new List<Eleve>();
        }

        [Key]
        public int ClasseId { get; set; }

        [StringLength(60)]
        [Required]
        public string NomEtablissement { get; set; }

        [StringLength(20)]
        [Required]
        public string Niveau { get; set; }


        public ICollection<Eleve> eleves { get; set; }


    }
}
