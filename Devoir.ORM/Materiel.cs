using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoir.ORM
{
    public class Materiel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string designation { get; set; }
        public bool Disponible { get; set; }
        public string description { get; set; }

        public DateTime DateAchat { get; set; }

        [Required]
        [StringLength(50)]
        public string reference { get; set; }

        public virtual ICollection<Intervention> Interventions { get; set; }

        public Materiel()
        {
            Interventions = new List<Intervention>();
        }
    }
}
