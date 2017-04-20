using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wmc.module.commands.slant;
using wmc.module.components.WordList;

namespace wmc
{
    class Program
    {
        static void Main(string[] args)
        {
            /*for (int i = 0; i < args.Length; i++)
            {
                //wmc WordList
                if (args[i] == "WordList")
                {
                    try
                    {
                        if (args[i + 1] == "-WL")
                        {
                            if (args[i + 2] != "")
                            {
                                WordList wordlist = new WordList(args[i + 2]);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("[ERROR] Improper usage of WordList debug command.");
                        throw;
                    }
                }
                
            }*/

            //WORDLIST debug
            //WordList wordlist = new WordList(args[0]);
            //Console.Write(wordlist.ToString());

            //slant/Corpus debug
            Corpus corpus = new Corpus(args[1]);
            //slant/Corpus/CorpusSegment debug
            //Console.WriteLine(corpus.CorpusSegments[0].filename + "\t" + corpus.CorpusSegments[0].contentM);

            //slant calc debug
            Console.WriteLine(Slant.determineSlant(corpus, new WordList(args[2])));

            Console.ReadKey();
        }

        static void printHelp()
        {
            Console.WriteLine("<insert help>");
        }
    }
}
