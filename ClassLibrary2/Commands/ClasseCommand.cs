using ClassLibrary1;
using ClassLibrary1.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Commands
{
    public class ClasseCommand
    {

        private readonly MonProjetDbContext _context;

        public ClasseCommand(MonProjetDbContext context)
        {
            _context = context;
        }

        public int Ajouter(Classe a)
        {
            _context.Classes.Add(a);
            return _context.SaveChanges();
        }

        public void Modifier(Classe a)
        {
            Classe updCla = _context.Classes.Where(ele => ele.ClasseId == a.ClasseId).FirstOrDefault();

            if (updCla != null)
            {
                updCla.Niveau = a.Niveau;
                updCla.NomEtablissement = a.NomEtablissement;
                updCla.eleves = a.eleves;
            }

            _context.SaveChanges();
        }

        public void Supprimer(int ClasseId)
        {
            Classe delCla = _context.Classes.Where(cla => cla.ClasseId == ClasseId).FirstOrDefault();

            if (delCla != null)
            {
                _context.Classes.Remove(delCla);

                _context.SaveChanges();
            }
        }
    }
}
