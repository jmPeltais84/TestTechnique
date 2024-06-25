using Corpus;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using System.Diagnostics;
using Reconcile;

namespace BankReconciliationMV
{
    public class TransactionWithLink : Transaction
    {
        public TransactionWithLink(Transaction iTransaction) { _t = iTransaction; }
        private Transaction _t;
        private int? _reconciledWith;

        public override int Id { get => _t.Id; set => _t.Id = value; }
        public override string Description { get => _t.Description; set => _t.Description = value; }
        public override decimal Amount { get => _t.Amount; set => _t.Amount = value; }
        public override DateTime Date { get => _t.Date; set => _t.Date = value; }
        public int? ReconciledWith { get => _reconciledWith; set => _reconciledWith = value; }


    }

    public class Controller
    {
        public Controller() {
            _bankTransactions = new BindingList<TransactionWithLink>();
            _accountingTransactions = new BindingList<TransactionWithLink>();
        }

        private BindingList<TransactionWithLink> _bankTransactions;

        private BindingList<TransactionWithLink> _accountingTransactions;

        public BindingList<TransactionWithLink> BankTransactions { get => _bankTransactions; set => _bankTransactions = value; }
        public BindingList<TransactionWithLink> AccountingTransactions { get => _accountingTransactions; set => _accountingTransactions = value; }

        private static void _loadTransactoin(string iPath, BindingList<TransactionWithLink> oTransaction)
        {
            oTransaction.Clear();
            CsvTransactionsLoader.File tl = new CsvTransactionsLoader.File();
            tl.openFile(iPath, ",");
            foreach (var trans in tl.GetTransactions())
            {
                oTransaction.Add(new TransactionWithLink(trans));
            }
        }

        public void openBankTransaction(string iPath)
        {
            _loadTransactoin(iPath, _bankTransactions);
        }

        public void openAccountingTransaction(string iPath)
        {
            _loadTransactoin(iPath, _accountingTransactions);
        }

        public void reconcile(decimal iPercentage, out Decimal rate)
        {
            //clear link
            foreach (var bt in _bankTransactions)
            {
                bt.ReconciledWith = null;
            }
            foreach (var bt in _accountingTransactions)
            {
                bt.ReconciledWith = null;
            }

            List<ReconciliationLink> links = new List<ReconciliationLink>();
                
            ReconcileTransaction.reconcile(_bankTransactions.Cast<Transaction>().ToList(),_accountingTransactions.Cast<Transaction>().ToList(), iPercentage, links, out rate);

            //Update _bankTransactions
            var joinBank = from t in _bankTransactions join l in links on t.Id equals l.TransIdBank select new{t,l};
            foreach (var item in joinBank)
            {
                item.t.ReconciledWith = item.l.TransIdAccounting;
            }

            //update _accountingTransactions
            var joinAccounting = from t in _accountingTransactions join l in links on t.Id equals l.TransIdAccounting select new { t, l };
            foreach (var item in joinAccounting)
            {
                item.t.ReconciledWith = item.l.TransIdBank;
            }
        }
    }
}