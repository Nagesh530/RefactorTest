using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Billing
{
    public class HarryPotterCalculator
    {
        #region Variables
        static Stack<int> s = new Stack<int>();

        decimal costPerBook = Common.BookPrice;
        #endregion

        #region Methods
        public void CalculateCost(int[] bookQuantities, string path, string name, string address)
        {
            CalculateHarryPotter(bookQuantities, path, name, address);
        }

        private void CalculateHarryPotter(int[] bookQuantities, string path, string name, string address)
        {
            var costs = new HashSet<int[]>(new EqualityComparer());

            for (int N = 1; CanBuyHarryPotter(bookQuantities, N); ++N)
            {
                s.Push(N);
                costs.UnionWith(CalculateBuyHarryPotter(bookQuantities, N, 0m));
                s.Pop();
            }


            Tuple<decimal, int[]> result = FindMinimumCost(costs);

            Debug.WriteLine("=============================");
            Debug.WriteLine($"Books: {string.Join(",", result.Item2)} = {result.Item1}");
            Debug.WriteLine("=============================");

            WriteToFile(path, name, address, result.Item2, result.Item1);
        }

        private Tuple<decimal, int[]> FindMinimumCost(HashSet<int[]> costs)
        {
            decimal minFee = decimal.MaxValue;
            int[] minBooks = null;

            foreach (var quantity in costs)
            {
                decimal quantityCost = CalculateQuantityCost(quantity);

                if (quantityCost < minFee)
                {
                    minFee = quantityCost;
                    minBooks = quantity;
                }
                Debug.WriteLine($"Books: {string.Join(",", quantity)} = {quantityCost}");
            }

            return Tuple.Create(minFee, minBooks);
        }

        private decimal CalculateQuantityCost(int[] quantity)
        {
            decimal quantityCost = 0;

            for (var n = 1; n <= Common.MaxBooks; ++n)
            {

                decimal discount = Common.GetDiscount(n);

                quantityCost += quantity[n] * n * costPerBook * (1m - discount);
            }

            return quantityCost;
        }

        private void WriteToFile(string path, string name, string address, int[] minBooks, decimal minFee)
        {
            using (var fs = File.OpenWrite(path))
            {
                var dateInfo = Encoding.ASCII.GetBytes($"Date: {DateTime.Now.ToShortDateString()}\r\nName: {name}\r\nAddress: {address}\r\n\r\n");
                fs.Write(dateInfo, 0, dateInfo.Length);

                var headerInfo = Encoding.ASCII.GetBytes("Description\t\t\t\t\tQuantity\tPrice\r\n");
                fs.Write(headerInfo, 0, headerInfo.Length);

                for (var n = 1; n <= Common.MaxBooks; ++n)
                {
                    if (minBooks[n] > 0)
                    {
                        decimal discount = Common.GetDiscount(n);

                        var bookInfo = string.Format("{0} Harry Potter books\t\t{1}\t\t\t{2}\r\n", n, minBooks[n], n * Common.BookPrice * (1m - discount));
                        var bookInfoBytes = Encoding.ASCII.GetBytes(bookInfo);
                        fs.Write(bookInfoBytes, 0, bookInfoBytes.Length);
                    }
                }

                var totalInfo = string.Format("Total: {0}\r\n", minFee, null);
                var totalInfoBytes = Encoding.ASCII.GetBytes(totalInfo);
                fs.Write(totalInfoBytes, 0, totalInfoBytes.Length);
            }
        }

        private HashSet<int[]> CalculateBuyHarryPotter(int[] bookQuantities, int n, decimal f)
        {
            decimal discount = Common.GetDiscount(n);

            int[] books = bookQuantities.Select(x => x).ToArray();


            f += n * costPerBook * (1m - discount);
            BuyHarryPotter(ref books, n);


            if ((books.Sum(x => x)) == 0)
            {
                int[] quantities = new int[6];
                s.ToArray().GroupBy(x => x).ToList().ForEach(x =>
                {
                    quantities[x.Key] = x.Count();
                });

                return new HashSet<int[]>(new EqualityComparer()) { quantities };
            }

            HashSet<int[]> costs = new HashSet<int[]>(new EqualityComparer());
            for (int N = 1; CanBuyHarryPotter(books, N); ++N)
            {
                s.Push(N);
                costs.UnionWith(CalculateBuyHarryPotter(books, N, f));
                s.Pop();
            }

            return costs;

        }

        private bool CanBuyHarryPotter(int[] bookQuantities, int N)
        {
            if (N > Common.MaxBooks)
                return false;

            int[] books = bookQuantities.Select(x => x).ToArray();

            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] > 0)
                {
                    books[i]--;
                    N--;
                }

                if (N == 0)
                    return true;
            }

            return false;
        }

        private void BuyHarryPotter(ref int[] books, int N)
        {
            if (N == 0 || N > books.Length) return;

            var orderedBooks = books.Select((count, id) => new { Count = count, Id = id + 1 })
                                   .OrderByDescending(b => b.Count)
                                   .ToArray();

            foreach (var book in orderedBooks.Take(N))
            {
                int index = book.Id - 1;
                --books[index];

                if (books[index] < 0)
                {
                    throw new Exception();
                }
            }
        }
        #endregion
    }
}