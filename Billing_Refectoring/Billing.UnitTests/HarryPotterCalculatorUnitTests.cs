using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Billing.UnitTests
{
    [TestClass]
    public class HarryPotterCalculatorUnitTests
    {
        #region Variables
        private HarryPotterCalculator calculator;
        private const string InvoiceFilePath = "Invoice.txt";
        #endregion

        #region Test Cases
        [TestInitialize]
        public void Initialize()
        {
            calculator = new HarryPotterCalculator();
            DeleteInvoiceFile();
        }

        [TestMethod]
        private void BuyBooksAndAssertLength(int[] bookQuantities, int expectedLength)
        {
            calculator.CalculateCost(bookQuantities, InvoiceFilePath, "Joe Customer", "London");
            Assert.AreEqual(expectedLength, GetInvoiceFileLength());
        }

        [TestMethod]
        public void Buy5Books()
        {
            int[] bookQuantities = { 1, 1, 1, 1, 1 };
            BuyBooksAndAssertLength(bookQuantities, 136);
        }

        [TestMethod]
        public void Buy7Books()
        {
            int[] bookQuantities = { 2, 3, 2, 0, 2 };
            BuyBooksAndAssertLength(bookQuantities, 165);
        }

        [TestMethod]
        public void Buy8Books()
        {
            int[] bookQuantities = { 2, 2, 2, 1, 1 };
            BuyBooksAndAssertLength(bookQuantities, 136);
        }

        [TestMethod]
        public void Buy8BooksP1()
        {
            int[] bookQuantities = { 1, 2, 2, 2, 1 };
            BuyBooksAndAssertLength(bookQuantities, 136);
        }

        [TestMethod]
        public void Buy8BooksP2()
        {
            int[] bookQuantities = { 1, 2, 2, 1, 2 };
            BuyBooksAndAssertLength(bookQuantities, 136);
        }

        [TestMethod]
        public void Buy8BooksP3()
        {
            int[] bookQuantities = { 1, 2, 1, 2, 2 };
            BuyBooksAndAssertLength(bookQuantities, 136);
        }

        [TestMethod]
        public void Buy8BooksP4()
        {
            int[] bookQuantities = { 2, 1, 1, 2, 2 };
            BuyBooksAndAssertLength(bookQuantities, 136);
        }

        [TestMethod]
        public void Buy8BooksP5()
        {
            int[] bookQuantities = { 1, 1, 2, 2, 2 };
            BuyBooksAndAssertLength(bookQuantities, 136);
        }

        [TestMethod]
        public void Buy9BooksP1()
        {
            int[] bookQuantities = { 1, 2, 3, 2, 1 };
            BuyBooksAndAssertLength(bookQuantities, 165);
        }

        private void DeleteInvoiceFile()
        {
            if (File.Exists("Invoice.txt"))
                File.Delete("Invoice.txt");
        }

        private long GetInvoiceFileLength()
        {
            return File.OpenRead(InvoiceFilePath).Length;
        }
        #endregion
    }
}
