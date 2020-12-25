using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePracticeApp
{
    class TrieSearching
    {
        public IList<IList<string>> Execute()
        {
            string[] products = { "mobile", "mouse", "moneypot", "monitor", "mousepad" };
            string searchWord = "mouse";

            return SuggestedProducts(products, searchWord);
        }


        private IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {

            Array.Sort(products);

            Trie root = new Trie();
            IList<IList<string>> res = new List<IList<string>>();

            foreach (string p in products)
            {
                
                root.Insert(p);
            }

            StringBuilder sb = new StringBuilder();
            foreach (var c in searchWord)
            {
                sb.Append(c);
                res.Add(root.Search(sb.ToString()));
            }

            return res;


        }

        public class Trie
        {
            public Trie[] t = new Trie[26];
            public List<string> suggestions = new List<string>();

            public void Insert(string s)
            {
                Trie tt = this;
                foreach (var c in s)
                {
                    if (tt.t[c - 'a'] == null)
                        tt.t[c - 'a'] = new Trie();


                    tt = tt.t[c - 'a'];

                    if (tt.suggestions.Count < 3)
                        tt.suggestions.Add(s);


                }
            }

            public List<string> Search(string searchWord)
            {
                List<string> lst = new List<string>();

                Trie cur = this;
                foreach (var c in searchWord)
                {
                    if(cur != null)
                        cur = cur.t[c - 'a'];
                }

                if (cur != null) lst.AddRange(cur.suggestions);
                return lst;
            
            }
        }
    }
}
