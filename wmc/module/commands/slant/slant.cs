using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wmc.module.components.WordList;

namespace wmc.module.commands.slant
{
    class Slant
    {
        //determine slant for the article within the corpus
        public static double determineSlant(CorpusSegment cs, WordList wl)
        {
            //the ToLower() gets rid of any character case issues
            int positiveCount = wl.GoodList.Count(s => cs.contentM.ToLower().Contains(s.ToLower()));
            int topicalCount = wl.TopicalList.Count(s => cs.contentM.ToLower().Contains(s.ToLower()));
            int badCount = wl.BadList.Count(s => cs.contentM.ToLower().Contains(s.ToLower()));

            //int slantScore = positiveCount + topicalCount + badCount;
            //cs = slantScore;

            //print to console stats
            Console.WriteLine(writeKslant(positiveCount, badCount, topicalCount));

            return calcKSlant(positiveCount, badCount, topicalCount);
        }

        //determine slant for the entire corpus

        public static double determineSlant(Corpus c, WordList wl)
        {
            //the ToLower() gets rid of any character case issues
            int positiveCount = 0;
            int topicalCount = 0;
            int badCount = 0;

            foreach (CorpusSegment cs in c.CorpusSegments)
            {
                int positiveCountCS = wl.GoodList.Count(s => cs.contentM.ToLower().Contains(s.ToLower()));
                int topicalCountCS = wl.TopicalList.Count(s => cs.contentM.ToLower().Contains(s.ToLower()));
                int badCountCS = wl.BadList.Count(s => cs.contentM.ToLower().Contains(s.ToLower()));

                //commit the slant score for the article into the article object
                cs.slant = positiveCountCS + topicalCountCS + badCountCS;
                //add to the corpus sum
                positiveCount = positiveCount + positiveCountCS;
                topicalCount = topicalCount + topicalCountCS;
                badCount = badCount + badCountCS;
            }

            /*
            //DEBUG
            Console.WriteLine("\n-----CORPUS SLANT EVALUATION-----");
            Console.WriteLine("Positive Slant Value: " + positiveCount);
            Console.WriteLine("Topical        Value:  " + topicalCount);
            Console.WriteLine("Negative Slant Value: " + badCount);
            //int slantScore = positiveCount + /*topicalCount*/ /*- badCount;*/
            /*
            Console.WriteLine("k-Slant Score:    " + calcKSlant(positiveCount, badCount, topicalCount));
            Console.WriteLine("---------------------------------\n");*/

            //consolidated printing
            Console.WriteLine(writeKslant(positiveCount, badCount, topicalCount));

            return calcKSlant(positiveCount, badCount, topicalCount);
        }

        //consolidated and standardized print method
        public static String writeKslant(double good, double bad, double profilic)
        {
            string toPrint = "\n-----CORPUS SLANT EVALUATION-----" + "\n" +
                "Positive Slant Value: " + good + "\n" +
                "Topical        Value:  " + profilic + "\n" +
                "Negative Slant Value: " + bad + "\n" +
                "k-Slant Score:    " + calcKSlant(good, bad, profilic) + "\n" +
                "---------------------------------\n";
            return toPrint;
        }

        //algorithm to determine slant of the corpus
        public static double calcKSlant(double good, double bad, double profilic)
        {
            double sum = good + bad + profilic;

            double positiveFactor = (good + profilic);
            double negativeFactor = (bad + profilic);
            double kFactor = (positiveFactor - negativeFactor)/(positiveFactor + negativeFactor);

            return (kFactor * 100);
        }
    }
}
