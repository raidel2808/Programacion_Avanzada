using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1_1;
using repository;
namespace RepositoryTest
{
    [TestClass]
    public class RepositoryTest
    {
        IPImportedRepository _Repository;

        public void PImportedRepositoryTests()
        {
            var connectionString = @"Data Source=LAPTOP-DOFK9MS3\SQLDEVELPMENT;AttachDBFilename=D:\Cujae\3er año\2do Semestre\Programación Avnazada\Código\HumanResourcesDB.mdf;Initial Catalog=HumanResourcesDB;User ID=sa;Password=12345678";
            _Repository = new DBRepository(connectionString);
        }

        [TestMethod]
        public void Can_PIMPORTED_Test()
        {
            string description = "Leche";
            int id = 1;
            float price_purchase = 5000;
            float tax = 1500;

            _Repository.BeginTransaction();
            var pimported = _Repository.CreatePImported(description, id, price_purchase, tax);
            _Repository.CommitTransaction();

            Assert.IsNotNull(pimported);
            Assert.AreNotEqual(0, pimported.id);
            Assert.AreEqual(description, pimported.Description);
            Assert.AreEqual(price_purchase, pimported.PricePurchase);
            Assert.AreEqual(tax, pimported.Tax);
        }

        [TestMethod]
        public void Can_UpdatePImported_Test()
        {
            
            _Repository.BeginTransaction();
            var pimported = _Repository.FindPImported("Leche");
            _Repository.CommitTransaction();

            var newPricePurchase = 8000;
            pimported.PricePurchase = newPricePurchase;

            
            _Repository.BeginTransaction();
            _Repository.UpdatePImported(pimported);
            _Repository.PartialCommit();

            var newpImported = _Repository.GetPImported(pimported.id);
            _Repository.CommitTransaction();
            Assert.IsNotNull(newpImported);
            Assert.AreNotEqual(0, newpImported.id);
            Assert.AreEqual(newPricePurchase, newpImported.PricePurchase);
        }

        [TestMethod]
        public void Can_DeletePImported_Test()
        {
            // arrange
            _Repository.BeginTransaction();
            var pimported = _Repository.FindPImported("Leche");
            _Repository.CommitTransaction();

            // act
            _Repository.BeginTransaction();
            _Repository.DeletePImported(pimported);
            _Repository.PartialCommit();

            // assert
            var deletedWorker = _Repository.GetPImported(pimported.id);
            _Repository.CommitTransaction();
            Assert.IsNull(deletedWorker);
        }
    }
}