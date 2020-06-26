using ClassLibrary1;
using ClassLibrary1.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Commands
{
    public class EleveCommand
    {
        private readonly MonProjetDbContext _context;

        public EleveCommand(MonProjetDbContext context)
        {
            _context = context;
        }

        public int Ajouter(Eleve a)
        {
            _context.Eleves.Add(a);
            return _context.SaveChanges();
        }

        public void Modifier(Eleve a)
        {
            Eleve updElv = _context.Eleves.Where(ele => ele.EleveId == a.EleveId).FirstOrDefault();

            if (updElv != null)
            {
                updElv.Classe = a.Classe;
                updElv.DateNaissance = a.DateNaissance;
                updElv.Prenom = a.Prenom;
                updElv.notes = a.notes;
                updElv.Nom = a.Nom;
                updElv.absences = a.absences;
            }

            _context.SaveChanges();
        }

        public void Supprimer(int EleveId)
        {
            Eleve delelv = _context.Eleves.Where(elv => elv.EleveId == EleveId).FirstOrDefault();

            if (delelv != null)
            {
                _context.Eleves.Remove(delelv);

                _context.SaveChanges();
            }
        }
    }
}
