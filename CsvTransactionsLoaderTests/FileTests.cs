using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsvTransactionsLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvTransactionsLoader.Tests
{
    [TestClass()]
    public class FileTests
    {
        [TestMethod()]
        public void openFileTest_FileNotFound()
        {
            Exception? myException = null;
            File myFile = new File();
            try
            {
                myFile.openFile(@"./itDoesNotExist.csv", ",");
            }
            catch (Exception e)
            {
                myException = e;
            }
            Assert.IsNotNull(myException);
            Assert.AreEqual("FileNotFoundException", myException.GetType().Name);
            
        }

        [TestMethod()]
        public void openFileTest_FileWith2Columns()
        {
            Exception? myException = null;
            File myFile = new File();
            try
            {
                myFile.openFile(@"../../../csvFiles/2columns.csv", ",");
            }
            catch (Exception e)
            {
                myException = e;
            }
            Assert.IsNotNull(myException);
            Assert.AreEqual("ArgumentException", myException.GetType().Name);
            Assert.AreEqual("Row:1 does not contain 3 columns", myException.Message);

        }

        [TestMethod()]
        public void openFileTest_FileWrongColumns()
        {
            Exception? myException = null;
            File myFile = new File();
            try
            {
                myFile.openFile(@"../../../csvFiles/wrongColumn.csv", ",");
            }
            catch (Exception e)
            {
                myException = e;
            }
            Assert.IsNotNull(myException);
            Assert.AreEqual("ArgumentException", myException.GetType().Name);
            Assert.AreEqual("File does not contain the 3 columns Date,Description and Amount", myException.Message);

        }

        [TestMethod()]
        public void openFileTest_FileWrongTypeDate()
        {
            Exception? myException = null;
            File myFile = new File();
            try
            {
                myFile.openFile(@"../../../csvFiles/wrongTypeDate.csv", ",");
            }
            catch (Exception e)
            {
                myException = e;
            }
            Assert.IsNotNull(myException);
            Assert.AreEqual("ArgumentException", myException.GetType().Name);
            Assert.AreEqual("Line:2 date cannot be parsed", myException.Message);

        }

        [TestMethod()]
        public void openFileTest_FileWrongTypeAmount()
        {
            Exception? myException = null;
            File myFile = new File();
            try
            {
                myFile.openFile(@"../../../csvFiles/wrongTypeAmount.csv", ",");
            }
            catch (Exception e)
            {
                myException = e;
            }
            Assert.IsNotNull(myException);
            Assert.AreEqual("ArgumentException", myException.GetType().Name);
            Assert.AreEqual("Line:2 amount cannot be parsed", myException.Message);

        }

        [TestMethod()]
        public void openFileTest_FileOk()
        {
            Exception? myException = null;
            File myFile = new File();
            try
            {
                myFile.openFile(@"../../../csvFiles/ok.csv", ",");
            }
            catch (Exception e)
            {
                myException = e;
            }
            Assert.IsNull(myException);
            Assert.AreEqual(2, myFile.GetTransactions().Count);

            //#1
            Assert.AreEqual(1, myFile.GetTransactions()[0].Id);
            Assert.AreEqual(DateTime.Parse("2023-01-07"), myFile.GetTransactions()[0].Date);
            Assert.AreEqual((decimal)455.46, myFile.GetTransactions()[0].Amount);
            Assert.AreEqual("bbbbb", myFile.GetTransactions()[0].Description);

            //#2
            Assert.AreEqual(2, myFile.GetTransactions()[1].Id);
            Assert.AreEqual(DateTime.Parse("2023-01-06"), myFile.GetTransactions()[1].Date);
            Assert.AreEqual((decimal)-455, myFile.GetTransactions()[1].Amount);
            Assert.AreEqual("aaaaa", myFile.GetTransactions()[1].Description);


        }

        [TestMethod()]
        public void openFileTest_FileOkOrder2()
        {
            Exception? myException = null;
            File myFile = new File();
            try
            {
                myFile.openFile(@"../../../csvFiles/okOrder2.csv", ",");
            }
            catch (Exception e)
            {
                myException = e;
            }
            Assert.IsNull(myException);
            Assert.AreEqual(2, myFile.GetTransactions().Count);

            //#1
            Assert.AreEqual(1, myFile.GetTransactions()[0].Id);
            Assert.AreEqual(DateTime.Parse("2023-01-07"), myFile.GetTransactions()[0].Date);
            Assert.AreEqual((decimal)455.46, myFile.GetTransactions()[0].Amount);
            Assert.AreEqual("bbbbb", myFile.GetTransactions()[0].Description);

            //#2
            Assert.AreEqual(2, myFile.GetTransactions()[1].Id);
            Assert.AreEqual(DateTime.Parse("2023-01-06"), myFile.GetTransactions()[1].Date);
            Assert.AreEqual((decimal)-455, myFile.GetTransactions()[1].Amount);
            Assert.AreEqual("aaaaa", myFile.GetTransactions()[1].Description);


        }
    }
}