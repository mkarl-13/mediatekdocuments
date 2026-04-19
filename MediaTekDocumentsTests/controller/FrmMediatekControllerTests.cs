using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.controller;
using System;

namespace MediaTekDocuments.Tests
{
    [TestClass]
    public class CommandeRevueTests
    {
        [TestMethod]
        public void ParutionDansPeriode_RetourneVrai()
        {
            FrmMediatekController controller = new FrmMediatekController();
            DateTime dateCommande = new DateTime(2025, 1, 1);
            DateTime dateFin = new DateTime(2025, 12, 31);
            DateTime dateParution = new DateTime(2025, 6, 15);
            bool resultat = controller.ParutionDansAbonnement(dateCommande, dateFin, dateParution);
            Assert.IsTrue(resultat);
        }

        [TestMethod]
        public void ParutionAvantCommande_RetourneFaux()
        {
            FrmMediatekController controller = new FrmMediatekController();
            DateTime dateCommande = new DateTime(2025, 1, 1);
            DateTime dateFin = new DateTime(2025, 12, 31);
            DateTime dateParution = new DateTime(2024, 12, 31);
            bool resultat = controller.ParutionDansAbonnement(dateCommande, dateFin, dateParution);
            Assert.IsFalse(resultat);
        }

        [TestMethod]
        public void ParutionApresFinAbonnement_RetourneFaux()
        {
            FrmMediatekController controller = new FrmMediatekController();
            DateTime dateCommande = new DateTime(2025, 1, 1);
            DateTime dateFin = new DateTime(2025, 12, 31);
            DateTime dateParution = new DateTime(2026, 1, 1);
            bool resultat = controller.ParutionDansAbonnement(dateCommande, dateFin, dateParution);
            Assert.IsFalse(resultat);
        }

        [TestMethod]
        public void ParutionSurDateCommande_RetourneVrai()
        {
            FrmMediatekController controller = new FrmMediatekController();
            DateTime dateCommande = new DateTime(2025, 1, 1);
            DateTime dateFin = new DateTime(2025, 12, 31);
            DateTime dateParution = new DateTime(2025, 1, 1);
            bool resultat = controller.ParutionDansAbonnement(dateCommande, dateFin, dateParution);
            Assert.IsTrue(resultat);
        }

        [TestMethod]
        public void ParutionSurDateFin_RetourneVrai()
        {
            FrmMediatekController controller = new FrmMediatekController();
            DateTime dateCommande = new DateTime(2025, 1, 1);
            DateTime dateFin = new DateTime(2025, 12, 31);
            DateTime dateParution = new DateTime(2025, 12, 31);
            bool resultat = controller.ParutionDansAbonnement(dateCommande, dateFin, dateParution);
            Assert.IsTrue(resultat);
        }
    }
}