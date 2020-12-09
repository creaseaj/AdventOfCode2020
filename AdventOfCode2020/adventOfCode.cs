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

        static public class day4
        {
            static public string[] validatePassport(string passportIn)
            {
                bool validity = true, containsCID = false;
                string[] fields = Regex.Split(passportIn, @" |\r\n| \r\n|\r\n ");
                if (fields.Length >= 7)
                {

                    for (int i = 0; i < fields.Length; i++)
                    {
                        if (validity == false) { break; }
                        string[] field = Regex.Split(fields[i], @":");
                        switch (field[0])
                        {
                            case "byr":
                                if (Convert.ToInt32(field[1]) > 2002 | Convert.ToInt32(field[1]) < 1920) { validity = false; }
                                break;

                            case "iyr":
                                if (Convert.ToInt32(field[1]) > 2020 | Convert.ToInt32(field[1]) < 2010) { validity = false; }
                                break;

                            case "eyr":
                                if (Convert.ToInt32(field[1]) > 2030 | Convert.ToInt32(field[1]) < 2020) { validity = false; }
                                break;

                            case "hgt":
                                if ((field[1].Substring(field[1].Length - 2, 2) != "cm") & (field[1].Substring(field[1].Length - 2, 2) != "in"))
                                { validity = false; }

                                else if (field[1].Substring(field[1].Length - 2, 2) == "cm")
                                {
                                    try
                                    {
                                        if (Convert.ToInt32(field[1].Substring(0, 3)) > 193 | Convert.ToInt32(field[1].Substring(0, 3)) < 150) { validity = false; }
                                    }
                                    catch { return null; }
                                }

                                else if (field[1].Substring(field[1].Length - 2, 2) == "in")
                                {
                                    if (Convert.ToInt32(field[1].Substring(0, 2)) > 76 | Convert.ToInt32(field[1].Substring(0, 2)) < 59) { validity = false; }

                                }
                                break;
                            case "hcl":
                                if (!Regex.IsMatch(field[1], @"^#[0-9a-f]{6}$"))
                                {
                                    validity = false;
                                }
                                break;
                            case "ecl":
                                if (field[1] != "amb" & field[1] != "blu" & field[1] != "brn" & field[1] != "gry" & field[1] != "grn"
                                    & field[1] != "hzl" & field[1] != "oth") { validity = false; }
                                break;
                            case "pid":
                                if (!Regex.IsMatch(field[1], @"^[0-9]{9}$"))
                                {
                                    validity = false;
                                }
                                break;
                            case "cid":
                                if(fields.Length != 8) { validity = false; }

                                break;
                        }
                    }
                   if (validity == true) { 
                        return fields; }
                    else { return null; }
                }
                else
                {
                    return null;
                }
            }

            public static string validatePassports( string listIn)
            {
                int passportCounter = 0;
                string outputText = "";
                string[] theList = Regex.Split(listIn, @"\r\n\r\n");
                for (int i = 0; i < theList.Length; i++)
                {
                        string[] passport = validatePassport(theList[i]);
                    if (passport != null)
                    {
                        passportCounter++;
                        for (int j = 0; j < passport.Length; j++)
                        {
                            outputText += passport[j];
                            outputText += ", ";
                        }
                        outputText += "\n";
                    }
                }
                return Convert.ToString(passportCounter) + "\n" + outputText;
            }
            public static int checkPassports( string listIn)
            {
                int counter = 0, passportCounter = 0 ;
                bool ContainsCID = false;
                
                string[] theList = Regex.Split(listIn, @"\r\n\r\n");
                for(int i = 0; i < theList.Length; i++)
                {
                    string[] toSplit = Regex.Split(theList[i], @" |\r\n");
                    for(int j = 0; j < toSplit.Length; j++)
                    {
                        if(toSplit[j].Substring(0,3) == "cid")
                        {
                            ContainsCID = true;
                            if (toSplit.Length == 8)
                            {
                                passportCounter++;
                            }
                            break;
                        }
                    }
                    if (ContainsCID == false & toSplit.Length == 7)
                    {
                        passportCounter++;
                    }
                    ContainsCID = false;

                }
                return passportCounter;

            }
        }

        static public class day5
        {

            static public int getHighestID(string seatList)
            {
                string[] theList = Regex.Split(seatList, @"\n");
                int highestID = 0, seatID;
                for (int i = 0; i < theList.Length; i++)
                {
                    int rowLow = 0, rowHigh = 127, columnLow = 0, columnHigh = 7;
                    for (int j = 0; rowLow != rowHigh; j++)
                    {
                        if (theList[i][j] == 'B')
                        {
                            rowLow = rowHigh - ((rowHigh - rowLow + 1) / 2) + 1;
                        }
                        else
                        {
                            rowHigh = rowLow + ((rowHigh - rowLow + 1) / 2) - 1;
                        }
                    }
                    for (int j = 0; columnLow != columnHigh; j++)
                    {
                        if (theList[i][j + 7] == 'R')
                        {
                            columnLow = columnHigh - ((columnHigh - columnLow + 1) / 2) + 1;
                        }
                        else
                        {
                            columnHigh = columnLow + ((columnHigh - columnLow + 1) / 2) - 1;
                        }
                    }
                    seatID = (rowHigh) * 8 + columnHigh;
                    if (seatID > highestID) { highestID = seatID; }
                }

                return highestID;
            }


            static private int getSeatID(string seatCode)
            {
                int rowLow = 0, rowHigh = 127, columnLow = 0, columnHigh = 7;
                for (int j = 0; rowLow != rowHigh; j++)
                {
                    if (seatCode[j] == 'B')
                    {
                        rowLow = rowHigh - ((rowHigh - rowLow + 1) / 2) + 1;
                    }
                    else
                    {
                        rowHigh = rowLow + ((rowHigh - rowLow + 1) / 2) - 1;
                    }
                }
                for (int j = 0; columnLow != columnHigh; j++)
                {
                    if (seatCode[j + 7] == 'R')
                    {
                        columnLow = columnHigh - ((columnHigh - columnLow + 1) / 2) + 1;
                    }
                    else
                    {
                        columnHigh = columnLow + ((columnHigh - columnLow + 1) / 2) - 1;
                    }
                }
                return (rowHigh) * 8 + columnHigh;
            }
            static public int findEmptySeat(string seatList)
            {
                string[] theList = Regex.Split(seatList, @"\n");
                List<int> newSeatList = new List<int>();
                for (int i = 0; i < theList.Length; i++)
                {
                    newSeatList.Add(getSeatID(theList[i]));
                }
                int lastCount = 0, newCount = 0;
                newSeatList.Sort();
                for (int i = 0; i < newSeatList.Count; i++)
                {
                    if (newSeatList[i] + 1 != newSeatList[i + 1])
                    {
                        return newSeatList[i] + 1;
                    }
                }
                return 0;
            }
        }

        static public class day6
        {
            public static int countAnswers(string inputList)
            {
                int totalCount = 0;
                string[] theList = Regex.Split(inputList, @"\r\n\r\n");
                // theList contains lists of groups of answers
                for(int i = 0; i < theList.Length; i++)
                {
                    string[] answers = Regex.Split(theList[i], @"\r\n");
                    // answers contains separate answers
                    int[] answercount = new int[128];
                    for(int j = 0; j < answers.Length; j++)
                    {
                        for(int k = 0; k < answers[j].Length; k++)
                        {
                            answercount[Convert.ToInt32(answers[j][k])] = 1;

                        }


                    }
                    for(int j = 0; j < answercount.Length; j++)
                    {
                        if(answercount[j] != 0) { totalCount++; }
                    }

                }

                return totalCount;
            }
        }
    }
}
