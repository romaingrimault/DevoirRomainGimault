using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devoir.ORM;

namespace Devoir.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ConnexionBDD())
            {
                var v = new Vehicule()
                {
                    Disponible = true,
                    Marque = "Renault",
                    Immatriculation = "13-Vz-5",
                    VolumeUtile = 50,
                    Model = "nisan",
                };
                var personne = new Intervenant()
                {
                    Nom = "Ricard",
                    Prenom = "Didier"

                };
                db.intervenants.Add(personne);
                db.Vehicules.Add(v);
                db.SaveChanges();
            }
        }
    }
}
