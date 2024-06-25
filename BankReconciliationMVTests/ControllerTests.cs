using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankReconciliationMV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankReconciliationMV.Tests
{
    [TestClass()]
    public class ControllerTests
    {
        [TestMethod()]
        public void openBankTransactionTest()
        {
            Controller myController = new Controller();
            myController.openBankTransaction(@"../../../csvFiles/bank_transactions.csv");

            Assert.AreEqual(1000,myController.BankTransactions.Count);
        }

        [TestMethod()]
        public void openAccountingTransactionTest()
        {
            Controller myController = new Controller();
            myController.openAccountingTransaction(@"../../../csvFiles/accounting_transactions.csv");

            Assert.AreEqual(1000, myController.AccountingTransactions.Count);
        }

        [TestMethod()]
        public void reconcileTest()
        {
            Controller myController = new Controller();
            myController.openBankTransaction(@"../../../csvFiles/bank_transactions.csv");
            myController.openAccountingTransaction(@"../../../csvFiles/accounting_transactions.csv");
            decimal rate;
            myController.reconcile(3,out rate);
            Assert.AreEqual(93,rate);

            Assert.IsTrue(myController.AccountingTransactions.Count > 0);
            Assert.IsTrue(myController.BankTransactions.Count > 0);
            Assert.AreEqual(41, myController.AccountingTransactions[0].ReconciledWith);
            Assert.AreEqual(11, myController.BankTransactions[0].ReconciledWith);
        }
    }
}