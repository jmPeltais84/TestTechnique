using System.ComponentModel;
using System;
using Corpus;
using BankReconciliationMV;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using CsvTransactionsLoader;
using System.Data.Common;
using System.Security.Cryptography;

namespace SubjectTestTechnique
{
    public partial class Form1 : Form
    {
        private bool _muteSelection = false;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _controller = new Controller();
            dataGridViewBank.DataSource = _controller.BankTransactions;
            dataGridViewAccounting.DataSource = _controller.AccountingTransactions;
        }

        private void buttonImportBank_Click(object sender, EventArgs e)
        {
            openFileDialogCSV.Title = "Open Bank Transactions CSV file";
            openFileDialogCSV.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialogCSV.RestoreDirectory = true;

            if (openFileDialogCSV.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                var filePath = openFileDialogCSV.FileName;
                try
                {
                    _controller.openBankTransaction(filePath);
                }
                catch (Exception ex)
                {
                    toolTipError.Show(ex.Message, buttonImportBank);
                }
                
            }

        }

        private void buttonImportAccounting_Click(object sender, EventArgs e)
        {
            openFileDialogCSV.Title = "Open Accounting Transactions CSV file";
            openFileDialogCSV.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialogCSV.RestoreDirectory = true;

            if (openFileDialogCSV.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                var filePath = openFileDialogCSV.FileName;
                try
                {
                    _controller.openAccountingTransaction(filePath);
                }
                catch (Exception ex)
                {
                    toolTipError.Show(ex.Message, buttonImportAccounting);
                }
            }
        }

        private void buttonReconcile_Click(object sender, EventArgs e)
        {
            Decimal rate;
            decimal percentage;

            if (!decimal.TryParse(textBoxReconcile.Text, out percentage))
            {

                toolTipError.Show("It must be decimal", textBoxReconcile);
            }

            _controller.reconcile(percentage, out rate);

            labelReconcileResult.Text = rate.ToString();

            dataGridViewAccounting.Refresh();
            dataGridViewBank.Refresh();
        }

        private void dataGridViewBank_SelectionChanged(object sender, EventArgs e)
        {
            if (_muteSelection) return;
            _muteSelection = true;
            dataGridViewAccounting.ClearSelection();

            TransactionWithLink t = (TransactionWithLink)dataGridViewBank.CurrentRow.DataBoundItem;
            if (t.ReconciledWith != null)
            {
                dataGridViewAccounting.Rows
                .OfType<DataGridViewRow>()
                 .Where(x => (int)x.Cells["Id"].Value == t.ReconciledWith)
                 .ToArray<DataGridViewRow>()[0]
                 .Selected = true;
            }
            _muteSelection = false;

        }

        private void dataGridViewAccounting_SelectionChanged(object sender, EventArgs e)
        {
            if (_muteSelection) return;
            _muteSelection = true;
            dataGridViewBank.ClearSelection();
            TransactionWithLink t = (TransactionWithLink)dataGridViewAccounting.CurrentRow.DataBoundItem;
            if (t.ReconciledWith != null)
            {
                dataGridViewBank.Rows
                .OfType<DataGridViewRow>()
                 .Where(x => (int)x.Cells["Id"].Value == t.ReconciledWith)
                 .ToArray<DataGridViewRow>()[0]
                 .Selected = true;
            }

            _muteSelection = false;
        }

        
    }
}