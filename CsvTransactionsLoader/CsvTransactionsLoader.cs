using System.Globalization;
using System.IO;
using Corpus;
using DataProvider;
using Microsoft.VisualBasic.FileIO;

namespace CsvTransactionsLoader
{
    /// <summary>
    /// Manage CSV file open and parse
    /// </summary>
    public class File : ITransactionsProvider
    {

        private List<Transaction>? _transactions;


        /// <summary>
        /// Open, parse file and fill GetTransactions 
        /// </summary>
        /// <param name="iFilePath">file to open</param>
        /// <param name="iDelimiter">delimiter to use to split line</param>
        /// <exception cref="ArgumentException">throw if file does not contain the 3 columns Date,Description and Amount</exception>
        /// <exception cref="IOException">File not found ...</exception>
        public void openFile(string iFilePath, string iDelimiter)
        {
            using (TextFieldParser textFieldParser = new TextFieldParser(iFilePath))
            {
                textFieldParser.TextFieldType = FieldType.Delimited;
                textFieldParser.SetDelimiters(iDelimiter);
                int lineNb = 1;
                int indexDate = -1;
                int indexDesciption = -1;
                int indexAmount = -1;
                _transactions = new List<Transaction>();

                while (!textFieldParser.EndOfData)
                {
                    string[]? rows = textFieldParser.ReadFields();
                    if (rows == null || rows.Length != 3)
                    {
                        throw new ArgumentException("Row:" + lineNb + " does not contain 3 columns");
                    }

                    if (lineNb == 1)
                    {
                        for (int i = 0; i < rows.Length; i++)
                        {
                            switch (rows[i]) { 
                                case "Date": indexDate = i; 
                                    break; 
                                case "Description": 
                                    indexDesciption = i; 
                                    break; 
                                case "Amount": 
                                    indexAmount = i; 
                                    break; }
                        }
                        if (indexAmount == -1 || indexDesciption == -1 || indexDate == -1)
                        {
                            throw new ArgumentException("File does not contain the 3 columns Date,Description and Amount");
                        }
                    }
                    else
                    {
                        Transaction t = new Transaction();
                        t.Id = lineNb-1;
                        DateTime d;
                        if (!DateTime.TryParse(rows[indexDate], out d))
                        {
                            throw new ArgumentException("Line:" + lineNb + " date cannot be parsed");
                        }
                        t.Date = d;

                        decimal amount;
                        if (!decimal.TryParse(rows[indexAmount], out amount) && !decimal.TryParse(rows[indexAmount], System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"),out amount))
                        {
                            throw new ArgumentException("Line:" + lineNb + " amount cannot be parsed");
                        }
                        t.Amount = amount;

                        t.Description = rows[indexDesciption];
                        _transactions.Add(t);
                    }
                    lineNb++;
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"> throw an exception if no file was opened</exception>
        public List<Transaction> GetTransactions()
        {
            if (_transactions == null) { throw new InvalidOperationException("File not Open"); }
            return _transactions;
        }

    }
}