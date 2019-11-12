using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoir.ORM
{
    public class Vehicule
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Immatriculation { get; set; }
        [Required]
        [StringLength(50)]
        public string Marque { get; set; }

        public float VolumeUtile { get; set; }
        [Required]
        [StringLength(50)]
        public string Model { get; set; }
        public bool Disponible { get; set; }

       
    }
}
