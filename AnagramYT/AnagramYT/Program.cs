using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramYT
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "limes", "plum", "miles", "pears", "smiles", "parse", "tacos", "livers",
            "silver", "coast", "spare", "taste", "bake", "bean", "soil", "silo", "oils", "olive", "lump"};

            List<string> result = new List<string>();
            bool match = false;

            //trim all spaces
            for (int i = 0; i < words.Count(); i++)
                words[i] = words[i].Trim();

            //loop through array starting with first word
            for (int i = 0; i < words.Count() - 1; i++)
            {
                result.Add(words[i]);
                //loop through array starting with the next word in line
                for (int c = i + 1; c < words.Count(); c++)
                {
                    //only see if words match, if number of letters matches
                    if (words[i].Length == words[c].Length && words[i] !="")
                    {
                        //convert both words to charArray
                        char[] a = words[i].ToUpper().ToCharArray();
                        char[] b = words[c].ToUpper().ToCharArray();
                        
                        Array.Sort(a);
                        Array.Sort(b);

                        match = false;
                        int counter = 0;
                        //loop throu each letter in both words
                        foreach(char x in a)
                        {
                            if (x == b[counter])
                                match = true;
                            else
                            {
                                match = false;
                                break;
                            }
                            counter++;
                        }
                        //if all letters match, add the words to the list
                        if (match)
                        {
                            result.Add(words[c]);
                            words[c] = "";
                        }
                        
                    }
                }

                //if list is equal to 1, no match was found
                if (result.Count() > 1 && result[0] != "" )
                {
                    Console.Write("Anagrams: ");
                    foreach (string s in result)
                        Console.Write(s + " ");

                    Console.WriteLine();
                }
            
                //reset the list
                result.Clear();
            }
            Console.ReadKey();
        }
    }
}
