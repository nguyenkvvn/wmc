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
            //if no arguments are entered
            if (args.Length == 0)
            {
                printHelp();
            }
            for (int i = 0; i < args.Length; i++)
            {
                //wmc slant
                if (args[i] == "slant")
                {
                    //directory slant calc
                    if (args[i + 1] == "-dir")
                    {
                        if (args[i + 2] != "")
                        {
                            Corpus c = new Corpus(args[i + 2]);

                            if (args[i + 3] != "")
                            {
                                WordList wl = new WordList(args[i + 3]);
                                //not printing the value bc writeKslant will be called in determining kSlant
                                Slant.determineSlant(c, wl);
                            }
                        }
                    }
                    //file slant calc
                    else if (args[i + 1] == "-file")
                    {
                        //TO-DO
                    }
                }
                //wmc version
                else if (args[i] == "version")
                {
                    Console.WriteLine("wmc Version " + typeof(Program).Assembly.GetName().Version);
                }
                
            }

            //WORDLIST debug
            //WordList wordlist = new WordList(args[0]);
            //Console.Write(wordlist.ToString());

            //slant/Corpus debug
            //Corpus corpus = new Corpus(args[1]);
            //slant/Corpus/CorpusSegment debug
            //Console.WriteLine(corpus.CorpusSegments[0].filename + "\t" + corpus.CorpusSegments[0].contentM);

            //slant calc debug
            //Console.WriteLine(Slant.determineSlant(corpus, new WordList(args[2])));

            //only for debugging
            //Console.ReadKey();
        }

        static void printHelp()
        {
            Console.WriteLine("No arguments entered. \nPlease see http://github.com/nguyenkvvn/wmc for documentation.");
        }
    }
}
