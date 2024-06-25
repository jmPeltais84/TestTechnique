using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reconcile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corpus;

namespace Reconcile.Tests
{
    [TestClass()]
    public class ReconcileTransactionTests
    {
        [TestMethod()]
        public void reconcileTestEmptyLists()
        {
            decimal rate;
            List<ReconciliationLink> result = new List<ReconciliationLink>();
            List<Transaction> bank = new List<Transaction>();
            List<Transaction> accounting = new List<Transaction>();
             ReconcileTransaction.reconcile(bank, accounting, 3, result, out rate);
            Assert.AreEqual(0, result.Count);
            Assert.AreEqual(100, rate);
        }

        [TestMethod()]
        public void reconcileTestEmptyListBank()
        {
            decimal rate;
            List<ReconciliationLink> result = new List<ReconciliationLink>();
            List<Transaction> bank = new List<Transaction>();
            List<Transaction> accounting = new List<Transaction>();
            accounting.Add(new Transaction() { Amount = (Decimal)45.1, Id = 4, Date = DateTime.Parse("2024-01-01"), Description = "test" });
             ReconcileTransaction.reconcile(bank, accounting, 3, result, out rate);
            Assert.AreEqual(0, result.Count);
            Assert.AreEqual(100, rate);
        }

        [TestMethod()]
        public void reconcileTestEmptyListAccounting()
        {
            decimal rate;
            List<ReconciliationLink> result = new List<ReconciliationLink>();
            List<Transaction> bank = new List<Transaction>();
            List<Transaction> accounting = new List<Transaction>();

            bank.Add(new Transaction() { Amount = (Decimal)45.1, Id = 4, Date = DateTime.Parse("2024-01-01"), Description = "test" });
             ReconcileTransaction.reconcile(bank, accounting, 3, result, out rate);
            Assert.AreEqual(0, result.Count);
            Assert.AreEqual(0, rate);
        }


        [TestMethod()]
        public void reconcileTestTransactionEqual()
        {
            decimal rate;
            List<ReconciliationLink> result = new List<ReconciliationLink>();
            List<Transaction> bank = new List<Transaction>();
            List<Transaction> accounting = new List<Transaction>();
            accounting.Add(new Transaction() { Amount = (Decimal)45.1, Id = 5, Date = DateTime.Parse("2024-01-01"), Description = "test" });
            bank.Add(new Transaction() { Amount = (Decimal)45.1, Id = 4, Date = DateTime.Parse("2024-01-01"), Description = "test" });
            ReconcileTransaction.reconcile(bank, accounting, 3, result, out rate);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(5, result[0].TransIdAccounting);
            Assert.AreEqual(4, result[0].TransIdBank);
            Assert.AreEqual(100, rate);
        }

        [TestMethod()]
        public void reconcileTestTransactionCloseTo3PercentLess()
        {
            decimal rate;
            List<ReconciliationLink> result = new List<ReconciliationLink>();
            List<Transaction> bank = new List<Transaction>();
            List<Transaction> accounting = new List<Transaction>();
            accounting.Add(new Transaction() { Amount = (Decimal)43.747, Id = 5, Date = DateTime.Parse("2024-01-01"), Description = "test" });
            bank.Add(new Transaction() { Amount = (Decimal)45.1, Id = 4, Date = DateTime.Parse("2024-01-01"), Description = "test" });
            ReconcileTransaction.reconcile(bank, accounting, 3, result, out rate);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(5, result[0].TransIdAccounting);
            Assert.AreEqual(4, result[0].TransIdBank);
        }

        [TestMethod()]
        public void reconcileTestTransactionCloseTo3PercentMore()
        {
            decimal rate;
            List<ReconciliationLink> result = new List<ReconciliationLink>();
            List<Transaction> bank = new List<Transaction>();
            List<Transaction> accounting = new List<Transaction>();
            accounting.Add(new Transaction() { Amount = (Decimal)46.453, Id = 5, Date = DateTime.Parse("2024-01-01"), Description = "test" });
            bank.Add(new Transaction() { Amount = (Decimal)45.1, Id = 4, Date = DateTime.Parse("2024-01-01"), Description = "test" });
            ReconcileTransaction.reconcile(bank, accounting, 3, result, out rate);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(5, result[0].TransIdAccounting);
            Assert.AreEqual(4, result[0].TransIdBank);
            Assert.AreEqual(100, rate);
        }

        [TestMethod()]
        public void reconcileTestTransaction0Percent()
        {
            decimal rate;
            List<ReconciliationLink> result = new List<ReconciliationLink>();
            List<Transaction> bank = new List<Transaction>();
            List<Transaction> accounting = new List<Transaction>();
            accounting.Add(new Transaction() { Amount = (Decimal)45, Id = 5, Date = DateTime.Parse("2024-01-01"), Description = "test" });
            bank.Add(new Transaction() { Amount = (Decimal)45, Id = 4, Date = DateTime.Parse("2024-01-01"), Description = "test" });
            ReconcileTransaction.reconcile(bank, accounting, 0, result, out rate);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(5, result[0].TransIdAccounting);
            Assert.AreEqual(4, result[0].TransIdBank);
            Assert.AreEqual(100, rate);
        }

        [TestMethod()]
        public void reconcileTestTransactionOverTo3Percent()
        {
            decimal rate;
            List<ReconciliationLink> result = new List<ReconciliationLink>();
            List<Transaction> bank = new List<Transaction>();
            List<Transaction> accounting = new List<Transaction>();
            accounting.Add(new Transaction() { Amount = (Decimal)47.453, Id = 5, Date = DateTime.Parse("2024-01-01"), Description = "test" });
            bank.Add(new Transaction() { Amount = (Decimal)45.1, Id = 4, Date = DateTime.Parse("2024-01-01"), Description = "test" });
            ReconcileTransaction.reconcile(bank, accounting, 3, result, out rate);
            Assert.AreEqual(0, result.Count);
            Assert.AreEqual(0, rate);
        }

        [TestMethod()]
        public void reconcileTestNTransactions()
        {
            decimal rate;
            List<ReconciliationLink> result = new List<ReconciliationLink>();
            List<Transaction> bank = new List<Transaction>();
            List<Transaction> accounting = new List<Transaction>();
            accounting.Add(new Transaction() { Amount = (Decimal)45.453, Id = 5, Date = DateTime.Parse("2024-01-01"), Description = "test" });
            accounting.Add(new Transaction() { Amount = (Decimal)142, Id = 10, Date = DateTime.Parse("2024-01-01"), Description = "test" });
            accounting.Add(new Transaction() { Amount = (Decimal)253, Id = 20, Date = DateTime.Parse("2024-01-01"), Description = "test" });
            bank.Add(new Transaction() { Amount = (Decimal)45.1, Id = 4, Date = DateTime.Parse("2024-01-01"), Description = "test" });
            bank.Add(new Transaction() { Amount = (Decimal)252.1, Id = 78, Date = DateTime.Parse("2024-01-01"), Description = "test" });
            bank.Add(new Transaction() { Amount = (Decimal)10, Id = 1012, Date = DateTime.Parse("2024-01-01"), Description = "test" });
            bank.Add(new Transaction() { Amount = (Decimal)141, Id = 1012, Date = DateTime.Parse("2024-01-01"), Description = "test" });
            ReconcileTransaction.reconcile(bank, accounting, 3, result, out rate);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(5, result[0].TransIdAccounting);
            Assert.AreEqual(4, result[0].TransIdBank);
            Assert.AreEqual(20, result[1].TransIdAccounting);
            Assert.AreEqual(78, result[1].TransIdBank);
            Assert.AreEqual(10, result[2].TransIdAccounting);
            Assert.AreEqual(1012, result[2].TransIdBank);
            
            Assert.AreEqual(75, rate);
        }
    }
}