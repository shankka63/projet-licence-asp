using ClassLibrary1.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class MonProjetDbContext: DbContext
    {
       public MonProjetDbContext() : base("name=connexionString1")
        {
            Database.SetInitializer<MonProjetDbContext>(new DropCreateDatabaseIfModelChanges<MonProjetDbContext>());
        }

        public DbSet<Classe> Classes { get; set; }
        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
