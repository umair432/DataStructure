using System;

namespace DataStructurePracticeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TrieSearching ts = new TrieSearching();
            string[] products = { "mobile", "mouse", "moneypot", "monitor", "mousepad" };
            string searchWord = "mouse";

            ts.SuggestedProducts(products, searchWord);
            Console.WriteLine("Hello World!");
        }
    }
}
