using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Devoir.ORM
{
    public class ConnexionBDD : DbContext
    {
        public ConnexionBDD()
        : base("ConnexionBDD")
        {
        }


        public DbSet<Intervenant> intervenants { get; set; }
        public DbSet<Intervention> interventions { get; set; }
        public DbSet<Materiel> Materiels { get; set; }
        public DbSet<Vehicule> Vehicules { get; set; }

    }
}
