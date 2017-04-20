using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace wmc.module.commands.slant
{
    class Corpus
    {
        public List<CorpusSegment> CorpusSegments;
        public String path;

        //class is instantiated
        public Corpus(String p)
        {

            //instantiate the corpus collection
            CorpusSegments = new List<CorpusSegment>();
            path = p;
            //put into the list the filenames
            indexFiles();

        }

        //indexfiles will fill the CorpusSegments with 
        private Boolean indexFiles()
        {
            int i = 0;
            //pasta from Microsoft
            try
            {
                var files = from file in Directory.EnumerateFiles(path, "*.txt", SearchOption.AllDirectories)
                            //from line in File.ReadLines(file)
                            //where line.Contains("")
                            select new
                            {
                                File = file,
                                //Line = line
                            };

                foreach (var f in files)
                {
                    //Console.WriteLine("{0}\t{1}", f.File, f.Line);
                    //Console.WriteLine("{0}\t", f.File);
                    i++;
                    CorpusSegments.Add(new CorpusSegment(f.File, File.ReadAllLines(f.File)));
                    Console.WriteLine("[Corpus] Processing Segment\t" + i + "\t of \t" + files.Count());
                }
                Console.WriteLine("[Corpus] {0} files found.", files.Count().ToString());
            }
            catch (UnauthorizedAccessException UAEx)
            {
                Console.WriteLine("[EXCEPTION] " + UAEx.Message);
            }
            catch (PathTooLongException PathEx)
            {
                Console.WriteLine("[EXCEPTION] " + PathEx.Message);
            }

            return true;
        }
    }

    //subclass for each file of the corpus
    class CorpusSegment
    {
        public String filename;
        public String[] content;
        public String contentM;
        public int slant = 0;

        public CorpusSegment(String fn, String[] c)
        {
            filename = fn;
            content = c;
            //content without lines
            contentM = "";

            //DEBUG
            Console.WriteLine("[Corpus Segment] File \t" + filename + "\tLines: \t" + content.Length);
            int i = 0;

            //this consolidates all the lines into one 
            /*foreach (String s in content)
            {
                contentM = contentM + " " + s;
                i++;
                Console.WriteLine("Corpus Lines Progress: " + i + " / " + content.Length);
            }*/

            //threaded to make it faster
            Parallel.ForEach(content, s =>
            {
                contentM = contentM + " " + s;
                //DEBUG counter
                i++;
                Console.WriteLine("[Corpus Segment] Consolidation Progress: \t" + i + " \t/\t" + content.Length + "\t Thread: \t" + Thread.CurrentThread.ManagedThreadId);
            }
            );

        }

        public static implicit operator CorpusSegment(int v)
        {
            throw new NotImplementedException();
        }
    }
}
