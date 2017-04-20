using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace wmc.module.components.WordList
{
    class WordList
    {
        public List<String> GoodList;
        public List<String> TopicalList;
        public List<String> BadList;

        public WordList(string pathToWordListCSV)
        {
            GoodList = new List<String>();
            TopicalList = new List<String>();
            BadList = new List<String>();

            interpret(pathToWordListCSV);
        }

        //interpret() will read through the CSV and sort the good, profilic, and bad words
        private Boolean interpret(string path)
        {
            using (TextFieldParser parser = new TextFieldParser(@path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //for each column
                    int csvCounter = 0;
                    //Processing row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        switch (csvCounter)
                        {
                            //Good Column
                            case 0:
                                csvCounter++;
                                GoodList.Add(field);
                                //VERBOSE: Console.Write("Row Parsed: " + field);
                                break;
                            //Topical Column
                            case 1:
                                csvCounter++;
                                TopicalList.Add(field);
                                //VERBOSE: Console.Write("," + field);
                                break;
                            //Bad Column
                            case 2:
                                csvCounter = 0;
                                BadList.Add(field);
                                //VERBOSE: Console.WriteLine("," + field);
                                break;
                        }
                    }
                }
            }

            //cleanup
            Predicate<String> emptyEntry = (String s) => { return s == ""; };
            GoodList.RemoveAll(emptyEntry);
            TopicalList.RemoveAll(emptyEntry);
            BadList.RemoveAll(emptyEntry);

            return true;
        }

        public override String ToString()
        {
            String outString = "";

            outString = outString + "Good: ";

            foreach (string s in GoodList)
            {
                outString = outString + s + ", ";
            }

            outString = outString + "\nTopical: ";
            foreach (string s in TopicalList)
            {
                outString = outString + s + ", ";
            }

            outString = outString + "\nBad: ";
            foreach (string s in BadList)
            {
                outString = outString + s + ", ";
            }

            return outString;
        }
    }
}
