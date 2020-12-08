using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace AdventOfCode2020
{
    static class adventOfCode
    {
        static public class day1
        {
            static public int findNumbers(string numberList)
            {
                int numberOut = 0;
                string[] theList = Regex.Split(numberList, @"\n");
                for (int i = 0; i < theList.Length; i++)
                {
                    for (int j = 0; j < theList.Length; j++)
                    {
                        if (Convert.ToInt32(theList[i]) + Convert.ToInt32(theList[j]) == 2020){
                            numberOut = Convert.ToInt32(theList[i]) * Convert.ToInt32(theList[j]);
                            break;
                        }
                    }
                }
                return numberOut;
            }
            
            static public int find3Numbers(string NumberList)
            {
                int numberOut = 0;
                Regex regexObj = new Regex(@"\n");
                Match matchResults = regexObj.Match(NumberList);
                string[] theList = Regex.Split(NumberList, @"\n");
                for (int i = 0; i < theList.Length; i++)
                {
                    for (int j = 0; j < theList.Length; j++)
                    {
                        for (int k = 0; k < theList.Length; k++)
                        {
                            if (Convert.ToInt32(theList[i]) + Convert.ToInt32(theList[j]) + Convert.ToInt32(theList[k]) == 2020)
                            {
                                numberOut = Convert.ToInt32(theList[i]) * Convert.ToInt32(theList[j]) * Convert.ToInt32(theList[k]);
                                break;
                            }
                        }
                    }
                }
                return numberOut;
            }
        }

        static public class day2
        {
            public static int tobogganCorp(string listIn)
            {
                List<List<int>> passArray = new List<List<int>>();
                int counter,counterOut = 0;
                string[] theList = Regex.Split(listIn, @"\n| |-");
                for(int i = 0; i < theList.Length; i += 4)
                {
                    counter = 0;
                    int rangeLow = Convert.ToInt32(theList[i]);
                    int rangeHigh = Convert.ToInt32(theList[i + 1]);
                    char charFind = theList[i + 2][0];
                    string password = theList[i + 3];
                    for (int j = 0; j < password.Length; j++)
                    {
                        if (password[j] == charFind)
                        {
                            counter++;
                        }

                    }
                    if (rangeLow <= counter & counter <= rangeHigh)
                    {
                        counterOut++;
                    }
                }
                return counterOut;
            }
            public static int tobogganCorpIndex(string listIn)
            {
                List<List<int>> passArray = new List<List<int>>();
                int counter, counterOut = 0;
                string[] theList = Regex.Split(listIn, @"\n| |-");
                for (int i = 0; i < theList.Length; i += 4)
                {
                    counter = 0;
                    int firstPlace = Convert.ToInt32(theList[i]);
                    int secondPlace = Convert.ToInt32(theList[i + 1]);
                    char charFind = theList[i + 2][0];
                    string password = theList[i + 3];
                    if (password[firstPlace - 1] == charFind ^ password[secondPlace- 1] == charFind)
                    {
                        counterOut++;
                    }

                }
                return counterOut;
            }
        }

        static public class day3
        {
            private static int checkRun(string theMap, int right, int down)
            {
                int numberOut = 0, horizPos = 0;
                string[] theList = Regex.Split(theMap, @"\n");
                for (int i = 0; i < theList.Length; i += down)
                {
                    if (theList[i][horizPos] == Convert.ToChar("#"))
                    {
                        numberOut++;
                    }
                    horizPos += right;
                    if (horizPos >= theList[i].Length - 1)
                    {
                        horizPos -= theList[i].Length - 1;
                    }
                }
                return numberOut;
            }
            public static int firstPathTrees(string theMap)
            {
                return checkRun(theMap, 3, 1);
            }
            public static double secondPathTrees(string theMap)
            {
                double output =  checkRun(theMap,1,1) * checkRun(theMap,3,1) * checkRun(theMap,5,1) * checkRun(theMap,7,1) * checkRun(theMap,1,2);
                return output;
            }
        }
    }
}
