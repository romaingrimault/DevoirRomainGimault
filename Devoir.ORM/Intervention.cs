using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devoir.ORM
{
    public class Intervention
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateOuverture { get; set; }
        public DateTime? DateFermeture { get; set; }

        public virtual ICollection<Materiel> Materiels { get; set; }
        [Required]
        public virtual Vehicule Vehicule { get; set; }
        public Intervention()
        {
            Materiels = new List<Materiel>();
            
        }
    }
}
