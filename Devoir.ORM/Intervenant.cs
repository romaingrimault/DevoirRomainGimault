using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoir.ORM
{
    public class Intervenant
    {
        [Key]
        public int Matricule { get; set; }
        [Required]
        [StringLength(50)]
        public string Nom { get; set; }
        [Required]
        [StringLength(50)]
        public string Prenom { get; set; }
        [Required]
        public virtual ICollection<Intervention> Interventions { get; set; }

        public Intervenant()
        {
            Interventions = new List<Intervention>();
        }

    }
}
