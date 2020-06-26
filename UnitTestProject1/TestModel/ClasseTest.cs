using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1;
using ClassLibrary1.Entites;
using ClassLibrary2.Commands;
using ClassLibrary2.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class ClasseTest
    {
        private readonly MonProjetDbContext _context;
        private ClasseCommand comm;
        private ClasseQuery query;

        public ClasseTest()
        {
            _context = new MonProjetDbContext();
            comm = new ClasseCommand(_context);
            query = new ClasseQuery(_context);

        }

        [TestMethod]
        public void TestAddClasse()
        {
            Classe newClasse = new Classe
            {
                Niveau = "4eme",
                NomEtablissement = "Collège Gerard Philipe"
            };

            comm.Ajouter(newClasse);
            Classe classeGotten = _context.Classes.FirstOrDefault(c => c.NomEtablissement == "Collège Gerard Philipe" && c.Niveau == "4eme");

            Assert.IsTrue(classeGotten.Niveau == newClasse.Niveau);
            Assert.IsTrue(classeGotten.NomEtablissement == newClasse.NomEtablissement);
        }

        [TestMethod]
        public void TestUpdateClasse()
        {
            Classe classe = query.GetById(1).First();
            string name = classe.NomEtablissement;
            string nomEtablissement = "Ecole Prims";
            classe.NomEtablissement = nomEtablissement;

            comm.Modifier(classe);
            Classe classGotten = query.GetById(1).First();

            Assert.AreEqual(classGotten.NomEtablissement, nomEtablissement);
        }

        [TestMethod]
        public void TestDeleteClasse()
        {
            //ARRANGE
            Classe myClasse = new Classe
            {
                Niveau = "CE2",
                NomEtablissement = "Ecole Primaire qui dégoûte"
            };
            _context.Classes.Add(myClasse);
            _context.SaveChanges();

            Classe classeGotten = _context.Classes.FirstOrDefault(c => c.NomEtablissement == "Ecole Primaire qui dégoûte" && c.Niveau == "CE2");


            //ACT
            comm.Supprimer(classeGotten.ClasseId);

            //ASSERT
            Assert.IsNull(_context.Classes.FirstOrDefault(c => c.NomEtablissement == "Ecole Primaire qui dégoûte" && c.Niveau == "CE2"));
        }

        [TestMethod]
        public void TestGetAllClasse()
        {
            //ARRANGE
            _context.Classes.Add(new Classe { Niveau = "CM1", NomEtablissement = "Ecole primaire" });
            _context.SaveChanges();
            //ACT
            List<Classe> classes = query.GetAll().ToList();
            //ASSERT

            Assert.IsTrue(classes.Count> 1);
        }
    }
}
