using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace AdventOfCode2020
{
    class adventOfCode
    {
        public struct day1
        {
            static public int findNumbers(string numberList)
            {
                int numberOut = 0;
                string[] theList = Regex.Split(numberList, @"\n");
                for (int i = 0; i < theList.Length; i++)
                {
                    for (int j = 0; j < theList.Length; j++)
                    {
                        if (Convert.ToInt32(theList[i]) + Convert.ToInt32(theList[j]) == 2020)
                        {
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
        public struct day2
        {
            public static int tobogganCorp(string listIn)
            {
                List<List<int>> passArray = new List<List<int>>();
                int counter, counterOut = 0;
                string[] theList = Regex.Split(listIn, @"\n| |-");
                for (int i = 0; i < theList.Length; i += 4)
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
                    if (password[firstPlace - 1] == charFind ^ password[secondPlace - 1] == charFind)
                    {
                        counterOut++;
                    }

                }
                return counterOut;
            }
        }
        public struct day3
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
                double output = checkRun(theMap, 1, 1) * checkRun(theMap, 3, 1) * checkRun(theMap, 5, 1) * checkRun(theMap, 7, 1) * checkRun(theMap, 1, 2);
                return output;
            }
        }
        public struct day4
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
                                if (fields.Length != 8) { validity = false; }

                                break;
                        }
                    }
                    if (validity == true)
                    {
                        return fields;
                    }
                    else { return null; }
                }
                else
                {
                    return null;
                }
            }
            public static string validatePassports(string listIn)
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
            public static int checkPassports(string listIn)
            {
                int counter = 0, passportCounter = 0;
                bool ContainsCID = false;

                string[] theList = Regex.Split(listIn, @"\r\n\r\n");
                for (int i = 0; i < theList.Length; i++)
                {
                    string[] toSplit = Regex.Split(theList[i], @" |\r\n");
                    for (int j = 0; j < toSplit.Length; j++)
                    {
                        if (toSplit[j].Substring(0, 3) == "cid")
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
        public struct day5
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
        public struct day6
        {
            public static int countAnswers(string inputList)
            {
                int totalCount = 0;
                string[] theList = Regex.Split(inputList, @"\r\n\r\n");
                // theList contains lists of groups of answers
                for (int i = 0; i < theList.Length; i++)
                {
                    string[] answers = Regex.Split(theList[i], @"\r\n");
                    // answers contains separate answers
                    int[] answercount = new int[128];
                    for (int j = 0; j < answers.Length; j++)
                    {
                        for (int k = 0; k < answers[j].Length; k++)
                        {
                            answercount[Convert.ToInt32(answers[j][k])] = 1;

                        }


                    }
                    for (int j = 0; j < answercount.Length; j++)
                    {
                        if (answercount[j] != 0) { totalCount++; }
                    }

                }

                return totalCount;
            }
            public static int countAllAnswers(string inputList)
            {
                int totalCount = 0;
                string[] theList = Regex.Split(inputList, @"\r\n\r\n");
                // theList contains lists of groups of answers
                for (int i = 0; i < theList.Length; i++)
                {
                    string[] answers = Regex.Split(theList[i], @"\r\n");
                    // answers contains separate answers
                    int[] answercount = new int[128];
                    for (int j = 0; j < answers.Length; j++)
                    {
                        for (int k = 0; k < answers[j].Length; k++)
                        {
                            answercount[Convert.ToInt32(answers[j][k])] += 1;

                        }


                    }
                    for (int j = 0; j < answercount.Length; j++)
                    {
                        if (answercount[j] == answers.Length) { totalCount++; }
                    }

                }

                return totalCount;
            }
        }
        public struct day7
        {
            static public int checkBags(string bagListIn)
            {
                string[] theList = Regex.Split(bagListIn, @".\r\n");
                bool newBagsAdded = true;
                List<string> containsShinyBag = new List<string>();
                List<List<string>> bagList = new List<List<string>>();
                for (int i = 0; i < theList.Length; i++)
                {

                    string[] bagDetails = Regex.Split(theList[i].Substring(0, theList[i].Length), @" bags contain ");
                    List<string> insideBags = new List<string>(Regex.Split(Regex.Replace(bagDetails[1], @"[0-9] | bags| bag|\.", ""), @", "));
                    List<string> allBags = new List<string>();
                    allBags.Add(bagDetails[0]);
                    allBags.AddRange(insideBags);
                    bagList.Add(allBags);
                    if (insideBags.IndexOf("shiny gold") >= 0) { containsShinyBag.Add(bagDetails[0]); }
                }

                while (newBagsAdded == true)
                {
                    newBagsAdded = false;
                    for (int i = 0; i < bagList.Count; i++)
                    {
                        for (int j = 1; j < bagList[i].Count; j++)
                        {
                            if ((containsShinyBag.IndexOf(bagList[i][j]) >= 0) & containsShinyBag.IndexOf(bagList[i][0]) == -1)
                            {
                                containsShinyBag.Add(bagList[i][0]); newBagsAdded = true;
                            }
                        }
                    }
                }
                return containsShinyBag.Count;
            }
            static public int createBagDictionary(string listIn)
            {
                string[] theList = Regex.Split(listIn, @".\r\n");
                List<string> containsShinyBag = new List<string>();
                Dictionary<string, List<string>> bagList = new Dictionary<string, List<string>>();
                for (int i = 0; i < theList.Length; i++)
                {

                    string[] bagDetails = Regex.Split(theList[i].Substring(0, theList[i].Length), @" bags contain ");
                    List<string> insideBags = new List<string>(Regex.Split(Regex.Replace(bagDetails[1], @" bags| bag|\.", ""), @", "));
                    bagList.Add(bagDetails[0], insideBags);
                }

                return checkBagContents("shiny gold", bagList) - 1;
            }
            static public int checkBagContents(string bagIn, IDictionary<string, List<string>> bagList)
            {
                int count = 0, bagContentsNum, numOfBags;
                if (bagList[bagIn][0] != "no other")
                {
                    for (int i = 0; i < bagList[bagIn].Count; i++)
                    {
                        numOfBags = Convert.ToInt32(bagList[bagIn][i].Substring(0, 1));
                        bagContentsNum = checkBagContents(bagList[bagIn][i].Substring(2, bagList[bagIn][i].Length - 2), bagList);
                        count += (numOfBags * bagContentsNum);
                    }
                    count++;
                }
                else { return 1; }

                return count;
            }
        }
        public struct day8
        {
            static public int runCode(string codeIn)
            {
                int pointer = 0, accumulator = 0, target = 1;
                string[] theList = Regex.Split(codeIn, @"\r\n");
                List<int> readCommands = new List<int>();
                while (readCommands.IndexOf(pointer) == -1 & pointer != theList.Length)
                {
                    readCommands.Add(pointer);
                    switch (theList[pointer].Substring(0, 3))
                    {
                        case "nop":
                            pointer++;
                            break;
                        case "acc":
                            accumulator += Convert.ToInt32(theList[pointer].Substring(4, theList[pointer].Length - 4));
                            pointer++;
                            break;
                        case "jmp":
                            pointer += Convert.ToInt32(theList[pointer].Substring(4, theList[pointer].Length - 4));
                            break;
                    }
                    if (readCommands.IndexOf(pointer) != -1)
                    {
                        break;
                    }
                }
                return accumulator;
            }
            static public string[] swapCode(string[] codeIn, int pointer)
            {
                string change = codeIn[pointer].Substring(4, codeIn[pointer].Length - 4);
                string cmd = codeIn[pointer].Substring(0, 3);
                switch (cmd)
                {
                    case "nop":
                        codeIn[pointer] = "jmp " + change;
                        break;
                    case "acc":
                        break;
                    case "jmp":
                        codeIn[pointer] = "jmp " + change;
                        break;
                }
                return codeIn;
            }
            static public int runCodeBase(string[] codeIn, int toSwap)
            {
                int pointer = 0, accumulator = 0;
                List<int> readCommands = new List<int>();
                while (readCommands.IndexOf(pointer) == -1 & pointer != codeIn.Length)
                {
                    readCommands.Add(pointer);
                    switch (codeIn[pointer].Substring(0, 3))
                    {
                        case "nop":
                            if (toSwap == pointer)
                            {
                                pointer += Convert.ToInt32(codeIn[pointer].Substring(4, codeIn[pointer].Length - 4));
                            }
                            else
                            {
                                pointer++;
                            }
                            break;
                        case "acc":
                            accumulator += Convert.ToInt32(codeIn[pointer].Substring(4, codeIn[pointer].Length - 4));
                            pointer++;
                            break;
                        case "jmp":
                            if (toSwap == pointer) { pointer++; }
                            else
                            {
                                pointer += Convert.ToInt32(codeIn[pointer].Substring(4, codeIn[pointer].Length - 4));
                            }
                            break;
                    }
                    if (readCommands.IndexOf(pointer) != -1)
                    {
                        return 0;
                    }
                }
                return accumulator;
            }
            static public int runCodeEnd(string codeIn)
            {
                int pointer = 0, accumulator = 0, result;
                string[] code = Regex.Split(codeIn, @"\r\n");
                for (int i = 0; i < code.Length; i++)
                {
                    result = runCodeBase(code, i);
                    if (result != 0) { return result; }
                }
                return accumulator;

            }
        }
        public struct day9
        {
            public static double runXmas(string codeStr)
            {
                double[] numbers = Array.ConvertAll(Regex.Split(codeStr, @"\r\n"), double.Parse);
                int preamble = 25;
                for (int i = preamble; i < numbers.Length; i++)
                {
                    if (!checkXmas(numbers, i, preamble)) { return numbers[i]; }
                }
                return 0;
            }
            public static bool checkXmas(double[] numbers, int pointer, int preamble)
            {
                for (int i = pointer - preamble; i < pointer; i++)
                {
                    for (int j = pointer - preamble; j < pointer; j++)
                    {
                        if (i != j & numbers[i] + numbers[j] == numbers[pointer]) { return true; }
                    }
                }
                return false;
            }
            public static double breakXmas(string codeStr)
            {
                List<double> numbers = Array.ConvertAll(Regex.Split(codeStr, @"\r\n"), double.Parse).ToList();
                double sum = 0;
                double target = runXmas(codeStr);
                for (int i = 0; i <= numbers.IndexOf(target); i++)
                {
                    sum = 0;
                    for (int j = i; j <= numbers.IndexOf(target); j++)
                    {
                        sum += numbers[j];
                        if (sum == target)
                        {
                            return findHighLow(i, j, numbers);
                        }
                        else if (sum > target) { break; }
                    }
                }
                return 0;
            }
            public static double findHighLow(int low, int high, List<double> numbers)
            {
                double highest = 0, lowest = numbers[low];
                for (int i = low; i <= high; i++)
                {
                    if (numbers[i] > highest) { highest = numbers[i]; }
                    if (numbers[i] < lowest) { lowest = numbers[i]; }
                }

                return lowest + highest;
            }
        }
        public struct day10
        {
            static public int countJolts(string joltStr)
            {
                List<int> jolts = Array.ConvertAll(Regex.Split(joltStr, @"\r\n"), int.Parse).ToList();
                jolts.Add(0);
                jolts.Sort();
                jolts.Add(jolts[jolts.Count - 1] + 3);
                int[] joltChanges = new int[3];
                for (int i = 1; i < jolts.Count; i++)
                {
                    joltChanges[jolts[i] - jolts[i - 1] - 1]++;
                }
                return joltChanges[0] * joltChanges[2];

            }

            static public decimal checkJoltVarieties(string joltStr)
            {
                List<int> joltList = Array.ConvertAll(Regex.Split(joltStr, @"\r\n"), int.Parse).ToList();
                List<int> differences = new List<int>();
                int counter = 1;
                decimal output = 1;
                joltList.Add(0);
                joltList.Sort();
                joltList.Add(joltList[joltList.Count - 1] + 3);
                for (int i = 1; i < joltList.Count; i++)
                {
                    differences.Add(joltList[i] - joltList[i - 1]);
                }
                for (int i = 1; i < differences.Count; i++)
                {
                    //if (counter == 3)
                    //{
                    //    //output += factorial(counter * differences[i - 1]);
                    //    output = output * 2 ^ (counter - 1);
                    //    counter = 2;
                    //}
                    //else if (counter == 2)
                    //{
                    //    //output += factorial(counter * differences[i - 1]);
                    //    output = output * 2 ^ (counter - 1);

                    //}
                    if (counter > 3)
                    {
                        output = output * (Convert.ToInt32(Math.Pow(2, counter - 1)) - (counter - 3));
                    }
                    if (differences[i] == differences[i - 1] & differences[i] == 1) { counter++; }
                    else if (counter <= 3 & counter != 1)
                    {
                        output = output * Convert.ToInt32(Math.Pow(2, counter - 1));
                        counter = 1;
                    }
                    else { counter = 1; }
                }
                return output;
            }
            static private int factorial(int a)
            {
                int sumOut = a;
                for (int i = a - 1; i != 0; i--)
                {
                    sumOut = sumOut * i;
                }
                return sumOut;
            }
            // note to self, you recorded the jumps so you know what can and can't be made, 1s are easy, 3s are impossible have a good morning ::)

            // enumeratevarieties is an awful way of solving the problem and should not be used >:(, this is staying here because it's cool, not so people think they should use it
            static public decimal enumeratevarieties(int[] jolts, int enumerateFrom)
            {
                decimal joltOut = 1;
                int[] newJolts = new int[jolts.Length - 1];
                for (int i = 1; i < jolts.Length; i++)
                {
                    if (jolts[i] - jolts[i - 1] > 3) { return 0; }
                }
                // now gonna remove a jolt each time then check it again
                for (int i = enumerateFrom; i < jolts.Length - 1; i++)
                {
                    Array.Copy(jolts, 0, newJolts, 0, i);
                    Array.Copy(jolts, i + 1, newJolts, i, newJolts.Length - i);
                    joltOut += enumeratevarieties(newJolts, i);
                }
                return joltOut;
            }
        }
        public struct day11
        {
            public static int countSeats(string seatsStr)
            {
                string[] seats1D = Regex.Split(seatsStr, @"\r\n");
                string[][] oldLife = new string[seats1D.Length][];
                for (int i = 0; i < seats1D.Length; i++)
                {
                    oldLife[i] = new string[seats1D.Length];
                    for (int j = 0; j < seats1D[i].Length; j++)
                    {
                        oldLife[i][j] = Convert.ToString(seats1D[i][j]);
                    }
                }
                string[][] newLife = new String[oldLife.Length][];
                newLife = runLife(oldLife);
                while (!compareArrays(newLife, oldLife))
                {
                    newLife = runLife(oldLife);
                    oldLife = runLife(newLife);
                }

                return countFreeSeats(newLife);
            }
            private static int countFreeSeats(string[][] arrA)
            {
                int counter = 0;
                for (int i = 0; i < arrA.Length; i++)
                {
                    for (int j = 0; j < arrA[i].Length; j++)
                    {
                        if (arrA[i][j] == Convert.ToString('#')) { counter++; }
                    }
                }
                return counter;
            }
            private static bool compareArrays(string[][] arrA, string[][] arrB)
            {
                for (int i = 0; i < arrA.Length; i++)
                {
                    for (int j = 0; j < arrA[i].Length; j++)
                    {
                        if (arrA[i][j] != arrB[i][j]) { return false; }
                    }
                }
                return true;
            }
            private static string[][] runLife(string[][] seatsIn)
            {
                string[][] lifeOut = new string[seatsIn.Length][];
                for (int i = 0; i < seatsIn.Length; i++)
                {
                    lifeOut[i] = new string[seatsIn.Length];
                    Array.Copy(seatsIn[i], lifeOut[i], seatsIn[i].Length);
                    for (int j = 0; j < seatsIn[i].Length; j++)
                    {
                        if (seatsIn[i][j] == Convert.ToString('#') | seatsIn[i][j] == Convert.ToString('L'))
                        {
                            if (countOccupiedSeats(seatsIn, i, j) >= 4)
                            {
                                lifeOut[i][j] = Convert.ToString('L');
                            }
                            else if (countOccupiedSeats(seatsIn, i, j) == 0)
                            {
                                lifeOut[i][j] = Convert.ToString('#');
                            }
                        }

                    }
                }
                return lifeOut;
            }
            private static int countOccupiedSeats(string[][] seatsIn, int row, int column)
            {
                int occupiedSeats = 0;
                for (int i = row - 1; i <= row + 1; i++)
                {
                    if (i >= 0 & i != seatsIn.Length)
                    {
                        for (int j = column - 1; j <= column + 1; j++)
                        {
                            if (i != row | j != column)
                            {
                                if (j >= 0 & j != seatsIn[i].Length)
                                {
                                    if (seatsIn[i][j] == Convert.ToString('#')) { occupiedSeats++; }
                                }
                            }
                        }
                    }
                }
                return occupiedSeats;
            }

            public static int p2countSeats(string seatsStr)
            {
                string[] seats1D = Regex.Split(seatsStr, @"\r\n");
                string[][] oldLife = new string[seats1D.Length][];
                for (int i = 0; i < seats1D.Length; i++)
                {
                    oldLife[i] = new string[seats1D[0].Length];
                    for (int j = 0; j < seats1D[i].Length; j++)
                    {
                        oldLife[i][j] = Convert.ToString(seats1D[i][j]);
                    }
                }
                string[][] newLife = new String[oldLife.Length][];
                newLife = runP2Life(oldLife);
                while (!compareArrays(newLife, oldLife))
                {
                    newLife = runP2Life(oldLife);
                    oldLife = runP2Life(newLife);
                }

                return countFreeSeats(newLife);
            }
            private static string[][] runP2Life(string[][] seatsIn)
            {
                string[][] lifeOut = new string[seatsIn.Length][];
                for (int i = 0; i < seatsIn.Length; i++)
                {
                    lifeOut[i] = new string[seatsIn[0].Length];
                    Array.Copy(seatsIn[i], lifeOut[i], seatsIn[0].Length);
                    for (int j = 0; j < seatsIn[i].Length; j++)
                    {
                        if (seatsIn[i][j] == Convert.ToString('#') | seatsIn[i][j] == Convert.ToString('L'))
                        {
                            int occSeats = p2CountOccupiedSeat(seatsIn, i, j);
                            if (occSeats>= 5) { 
                                lifeOut[i][j] = Convert.ToString('L');
                            }
                            else if (occSeats == 0)
                            {
                                lifeOut[i][j] = Convert.ToString('#');
                            }
                        }
                    }
                }
                return lifeOut;
            }
            private static int p2CountOccupiedSeat(string[][] seatsIn, int row, int column)
            {
                int occupiedSeats = 0;
                for (int i = row - 1; i <= row + 1; i++)
                {
                    for (int j = column - 1; j <= column + 1; j++)
                    {
                        if (i != row | j != column)
                        {
                            if (checkOutOfBounds(seatsIn, i, j))
                            {
                                char seatSeen = Convert.ToChar(seatsIn[i][j]);
                                int k = 0, l = 0;
                                while (seatSeen == '.')
                                {
                                    k += i - row;
                                    l += j - column;
                                    if (checkOutOfBounds(seatsIn, i + k, j + l))
                                    {
                                        seatSeen = Convert.ToChar(seatsIn[i + k][j + l]);
                                    }
                                    else { break; }
                                    
                                }
                                if (seatSeen == '#') { occupiedSeats++; }
                            }
                        }
                    }
                }
                return occupiedSeats;
            }
            private static bool checkOutOfBounds(string[][] seatsIn, int row, int column)
            {
                if(row < seatsIn.Length & row >= 0) {
                    if(column < seatsIn[0].Length & column >= 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public struct day12
        {
            static public int getManhattanDistance(string codeIn)
            {
                int v = 0, h = 0, facing = 1;
                // facing 0 is north, east is 1 etc.
                string[] Instructions = Regex.Split(codeIn, @"\r\n");
                for (int i = 0; i < Instructions.Length; i++)
                {
                    string currentIn = Instructions[i];
                    switch (Convert.ToString(currentIn[0]))
                    {
                        case ("N"):
                            v += Convert.ToInt32(currentIn.Substring(1));
                            break;
                        case ("E"):
                            h += Convert.ToInt32(currentIn.Substring(1));
                            break;
                        case ("S"):
                            v -= Convert.ToInt32(currentIn.Substring(1));
                            break;
                        case ("W"):
                            h -= Convert.ToInt32(currentIn.Substring(1));
                            break;
                        case ("R"):
                            facing += Convert.ToInt32(currentIn.Substring(1)) / 90;
                            break;
                        case ("L"):
                            facing -= Convert.ToInt32(currentIn.Substring(1)) / 90;
                            break;
                        case ("F"):
                            switch (facing % 4)
                            {
                                case (0):
                                    v += Convert.ToInt32(currentIn.Substring(1));
                                    break;
                                case (1):
                                    h += Convert.ToInt32(currentIn.Substring(1));
                                    break;
                                case (2):
                                    v -= Convert.ToInt32(currentIn.Substring(1));
                                    break;
                                case (3):
                                    h -= Convert.ToInt32(currentIn.Substring(1));
                                    break;

                            }
                            break;


                    }
                }
                return Math.Abs(v) + Math.Abs(h);
            }
            static public int getP2ManhattanDistance(string codeIn)
            {
                int facing = 0;
                int[] shipCord = { 0 , 0 }, waypCord = { 10, 1 }, oldWay = new int[2];
                // [0] is x, [1] is y
                // facing 0 is north, east is 1 etc.
                string[] Instructions = Regex.Split(codeIn, @"\r\n|\n");
                for (int i = 0; i < Instructions.Length; i++)
                {
                    string currentIn = Instructions[i];
                    switch (Convert.ToString(currentIn[0]))
                    {
                        case ("N"):
                            waypCord[1] += Convert.ToInt32(currentIn.Substring(1));
                            break;
                        case ("E"):
                            waypCord[0] += Convert.ToInt32(currentIn.Substring(1));
                            break;
                        case ("S"):
                            waypCord[1] -= Convert.ToInt32(currentIn.Substring(1));
                            break;
                        case ("W"):
                            waypCord[0] -= Convert.ToInt32(currentIn.Substring(1));
                            break;
                        case ("R"):
                            for (int j = 0; j < Convert.ToInt32(currentIn.Substring(1)) / 90; j++)
                            {
                                Array.Copy(waypCord, oldWay, 2);
                                waypCord[0] = oldWay[1];
                                waypCord[1] = -oldWay[0];
                            }
                            break;
                        case ("L"):
                            for (int j = 0; j < 4 - Convert.ToInt32(currentIn.Substring(1)) / 90; j++)
                            {
                                Array.Copy(waypCord, oldWay, 2);
                                waypCord[0] = oldWay[1];
                                waypCord[1] = -oldWay[0];
                            }
                            break;
                        case ("F"):
                            facing = 0;
                            shipCord[1] += waypCord[1] * Convert.ToInt32(currentIn.Substring(1));
                            shipCord[0] += waypCord[0] * Convert.ToInt32(currentIn.Substring(1));
                            break;
                    }
                }
                return Math.Abs(shipCord[0]) + Math.Abs(shipCord[1]);
            }
        }
        public struct day13
        {
            static public int getSoonestBus(string busStr)
            {
                string[] busTimes = Regex.Split(busStr, @"\r\n");
                int leavingTime = Convert.ToInt32(busTimes[0]);
                // did all that regex from memory because I don't have wifi rn and honestly can't believe it worked
                int[] busIds = Array.ConvertAll(Regex.Split(busTimes[1], @"[,x]+,|,"), int.Parse);
                int soonestBus = busIds[0];
                for (int i = 0; i < busIds.Length; i++)
                {
                    if (waitTime(soonestBus, leavingTime) > waitTime(busIds[i], leavingTime)) { soonestBus = busIds[i]; }
                }
                return soonestBus * waitTime(soonestBus, leavingTime);
            }

            static private int waitTime(int busID, int time)
            {
                return busID - (time % busID);
            }
            static public decimal p2CheckConsecutiveBusses(string busStr)
            {
                string[] busTimes = Regex.Split(busStr, @",");
                bool timeFound = true;
                List<int[]> timeDict = new List<int[]>();
                decimal[] decBusTimes = new decimal[busTimes.Length];
                decimal[] largestTime = { Convert.ToDecimal(busTimes[0]), 1 }; // needs to store size and it's index
                // convert busTimes into decimals so there's less converting in the loop
                for(int i = 0; i < busTimes.Length; i++)
                {
                    if(busTimes[i] != "x")
                    {
                        decBusTimes[i] = Convert.ToDecimal(busTimes[i]);
                    }
                    else
                    {
                        decBusTimes[i] = 1;
                    }
                }
                for (decimal time = Convert.ToDecimal(busTimes[0]); time < decimal.MaxValue - decBusTimes[0]; time += largestTime[0])
                {
                    timeFound = true;
                    for (int i = Convert.ToInt32(largestTime[1]); i < decBusTimes.Length; i++)
                    {
                        decimal waitTime = (time + i) % decBusTimes[i];
                        if (waitTime != 0) { timeFound = false; break; }
                        else if (i >= largestTime[1]) { 
                            largestTime[0] = sumOf(decBusTimes,i + 1);
                            largestTime[1] = i;
                        }
                        
                    }
                    if (timeFound) { return time; }
                }
                return 0;
            }
            private static decimal sumOf(decimal[] timesIn, int length)
            {
                decimal sumOut = timesIn[0];
                for(int i  = 1; i < length; i++)
                {
                    sumOut = sumOut * timesIn[i];
                }
                return sumOut;
            }
        }
        public struct day14 {
            static public decimal readMasks(string maskIn)
            {
                string[] instructions = Regex.Split(maskIn, @"\r\n");
                List<int> bitMask = new List<int>();
                decimal output = 0;
                Dictionary<int, decimal> memory = new Dictionary<int, decimal>();
                for (int i = 0; i < instructions.Length; i++)
                {
                    string[] instruction = Regex.Split(instructions[i], @" = ");
                    if (instruction[0] == "mask") // mask being written
                    {
                        bitMask = new List<int>();
                        for (int j = 0; j < instruction[1].Length; j++)
                        {
                            if (instruction[1][j] == 'X')
                            {
                                bitMask.Add(-1);
                            }
                            else
                            {
                                bitMask.Add(Convert.ToInt32(Convert.ToString(instruction[1][j])));
                            }
                        }
                    }
                    // memory being written
                    else
                    {
                        string[] memWrite = toBinary(instruction[1],bitMask.Count) ;
                        for (int j = 0; j < bitMask.Count; j++)
                        { 
                            if (bitMask[j] >= 0)
                            {
                                memWrite[j] = Convert.ToString(bitMask[j]);
                            }
                        }
                        Regex regex = new Regex(@"[\d]+");
                        //Match m = regex.Match(instruction[0]);
                        int memLoc = Convert.ToInt32(regex.Match(instruction[0]).Groups[0].Value);
                        decimal memData = binaryToDecimal(memWrite) ;
                        memory[memLoc] = memData;
                    }
                }
                Dictionary<int,decimal>.ValueCollection values = memory.Values;
                foreach (decimal val in values)
                {
                    output += val;
                }
                return output; ;
            }
            static private decimal binaryToDecimal(string[] binaryIn)
            {
                decimal output = 0;
                for(int i = 0; i < binaryIn.Length; i++)
                {
                    if (Convert.ToInt32(binaryIn[i]) == 1){
                        output += Convert.ToDecimal(Math.Pow(2,binaryIn.Length - i - 1));
                    }
                }
                return output;
            }
            static private string[] toBinary(string strIn, int length)
            {
                int intIn = Convert.ToInt32(strIn);
                string binary = Convert.ToString(intIn, 2);
                string[] output = new string[length];
                for(int i = 0; i < length; i++)
                {
                    if (i < length - binary.Length)
                    {
                        output[i] = "0";
                    }
                    else
                    {
                        output[i] = Convert.ToString(binary[i - length + binary.Length]);
                    }
                }
                return output;
            }
            static public decimal p2readMasks(string instructionsStr)
            {
                string[] instructions = Regex.Split(instructionsStr, @"\r\n");
                List<int> bitMask = new List<int>();
                decimal output = 0;
                Dictionary<decimal, decimal> memory = new Dictionary<decimal, decimal>();
                for (int i = 0; i < instructions.Length; i++)
                {
                    string[] instruction = Regex.Split(instructions[i], @" = ");
                    if (instruction[0] == "mask") // mask being written
                    {
                        bitMask = new List<int>();
                        for (int j = 0; j < instruction[1].Length; j++)
                        {
                            if (instruction[1][j] == 'X')
                            {
                                bitMask.Add(-1);
                            }
                            else
                            {
                                bitMask.Add(Convert.ToInt32(Convert.ToString(instruction[1][j])));
                            }
                        }
                    }
                    // memory being written
                    else
                    {
                        Regex regex = new Regex(@"[\d]+");
                        decimal memLoc = Convert.ToDecimal(regex.Match(instruction[0]).Groups[0].Value);
                        decimal memWrite = Convert.ToDecimal(instruction[1]);
                        string[] address = toBinary(Convert.ToString(memLoc), bitMask.Count);
                        for (int j = 0; j < bitMask.Count; j++)
                        {
                            switch (bitMask[j])
                            {
                                case (1):
                                    address[j] = "1";
                                    break;
                                case (-1):
                                    address[j] = "-1";
                                    break;
                            }
                        }
                        //Match m = regex.Match(instruction[0]);
                        memory = writeAddresses(memory, address, memWrite);
                        //decimal memData = binaryToDecimal(memWrite);
                        //memory[memLoc] = memData;
                    }
                }
                Dictionary<decimal, decimal>.ValueCollection values = memory.Values;
                foreach (decimal val in values)
                {
                    output += val;
                }
                return output; ;
            }
            private static Dictionary<decimal,decimal> writeAddresses(Dictionary<decimal,decimal> memory, string[] loc, decimal toWrite)
            {
                // gonna get all addresses
                List<decimal> addresses = new List<decimal>();
                addresses = findAddresses(loc);
                for(int i = 0; i < addresses.Count; i++)
                {
                    memory[addresses[i]] = toWrite;
                }
                return memory;
            }
            private static List<decimal> findAddresses(string[] loc)
            {
                List<decimal> addresses = new List<decimal>();
                bool containsNeg = false ;
                string[] temp = new string[loc.Length];
                for (int i = 0; i < loc.Length; i++)
                {
                    if (loc[i] == "-1")
                    {
                        for(int j = 0; j < 2; j++)
                        {
                            Array.Copy(loc, temp, loc.Length);
                            temp[i] = Convert.ToString(j);
                            addresses.AddRange(findAddresses(temp));
                        }
                        containsNeg = true;
                        break;
                    }
                }
                if (containsNeg == false)
                {
                    addresses.Add(binaryToDecimal(loc));
                }
                return addresses;

            }
        }
        public struct day15 {
            public static int playNumberGame(string numbersIn, int length)
            {
                // This code is very messy and can be made a lot more elegant.
                // If this was to happen, the List<int> inside the dictionary would be made into an int[2] for the last two indexes of the number
                // This means it won't be storing 30 million values inside a dicitonary when it only needs a fraction of thatr
                string[] instruction = Regex.Split(numbersIn, @",");
                Dictionary<int, List<int>> numberList = new Dictionary<int, List<int>>(); 
                for(int i = 0; i < instruction.Length; i++)
                {
                    numberList[Convert.ToInt32(instruction[i])] = new List<int>();
                    numberList[Convert.ToInt32(instruction[i])].Add(i);
                }
                int lastNum = Convert.ToInt32(instruction[instruction.Length - 1]);
                for (int i = numberList.Count; i < length; i++)
                {
                    if(numberList[lastNum].Count <= 1)
                    {
                        if (!numberList.ContainsKey(0))
                        {
                            numberList[0] = new List<int>();
                        }
                        numberList[0].Add(i);
                        lastNum = 0;
                    }
                    else
                    {
                        if (!numberList.ContainsKey(lastNum)) 
                        {
                            numberList[lastNum] = new List<int>();
                            lastNum = 0;
                        }
                        else
                        {
                            lastNum = (i - numberList[lastNum][numberList[lastNum].Count - 2]) - 1;
                            
                        }
                        if (!numberList.ContainsKey(lastNum))
                        {
                            numberList[lastNum] = new List<int>();
                        }
                        numberList[lastNum].Add(i);
                    }
                }
                return lastNum;
            }
            private static int lastSpoke(List<int> gameMemory)
            {
                // This was used to search through the whole array but it was too slow for part 2 and has now been removed
                int numberToFind = gameMemory[gameMemory.Count - 1], length = 0;
                for (int i = 2; i < gameMemory.Count + 1; i++)
                {
                    if(gameMemory[gameMemory.Count - i] == numberToFind)
                    {
                        length = i - 1;
                        break;
                    }
                }
                return length;
            }

        }
        public struct day16 {
            // Day 16 is currently unfinished and needs a lot more work
            public static int readTickets (string listIn)
            {
                string[] instruction = Regex.Split(listIn, @"\r\n\r\n");
                List<int[]> ranges = getRanges(instruction[0]);
                MatchCollection matches = Regex.Matches(instruction[2], @"[\d]+");
                int numOut = checkMatches(matches,ranges);
                return numOut;
            }

            //p2
            public static int p2ReadTickets(string listIn)
            {
                string[] instruction = Regex.Split(listIn, @"\r\n\r\n");
                List<int[]> ranges = getRanges(instruction[0]);
                string[] tickets = Regex.Split(instruction[2], @"\r\n");
                List<int[]> validTickets = new List<int[]>();
                for(int i = 1; i < tickets.Length; i++)
                {
                    int[] ticket = Array.ConvertAll(Regex.Split(tickets[i], @","), int.Parse);
                    if (checkTicket(ticket, ranges))
                    {
                        validTickets.Add(ticket);
                    }
                }
                List<int[]> ticketRanges = getRangesOfTickets(validTickets);
                Dictionary<string,List<int[]>> ticketNames = findTicketsFields(instruction[0], validTickets);
                return 0;
            }
            //p2
            private static Dictionary<string,List<int[]>> findTicketsFields(string instruction, List<int[]> ticketRanges)
            {
                Dictionary<string, List<int[]>> dicOut = new Dictionary<string, List<int[]>>();
                string[] fields = Regex.Split(instruction, @"\r\n"); //separating instructions line by line
                bool[,,] ticketFits = new bool[ticketRanges.Count, fields.Count(), fields.Count()]; // i is each ticket line by line, j each ticket number, k is the fields it can match from fields
                //List<int> range = new List<int>();
                Dictionary<string, List<int[]>> ticketLimits = new Dictionary<string, List<int[]>>();
                foreach(string line in fields)
                {
                    ticketLimits.Add(Regex.Split(line,@":")[0], p2getRanges(line));
                }
                string[] ticketKeys = ticketLimits.Keys.ToArray();
               
                // Now we've got what each value in the ticket list matches, we can find which ones only match what.
                // p2
                bool[][] finalMatches = new bool[ticketFits.GetLength(1)][];
                for(int i = 0; i < finalMatches.Count(); i++)
                {
                    finalMatches[i] = new bool[ticketFits.GetLength(2)];
                    for(int j = 0; j < finalMatches.Count(); j++)
                    {
                        finalMatches[i][j] = true;
                    }
                }
                for (int j = 0; j < ticketFits.GetLength(1); j++)
                {
                    for (int k = 0; k < ticketFits.GetLength(2); k++)
                    {
                        for (int i = 0; i < ticketFits.GetLength(0); i++)
                        {
                            finalMatches[j][k] = finalMatches[j][k] != false ? checkTicketNumber(ticketRanges[i][j], ticketLimits[ticketKeys[k]]) : false;
                        }
                    }
                }
                // so after having looked at the output, there is always a different number of true and falses, so we can organise what's what based on that
                string strOut = "";
                foreach (bool[] ticket in finalMatches)
                {
                    strOut += "\n";
                    foreach(bool num in ticket)
                    {
                        strOut += num == true ? "#" : ".";
                    }
                    
                }

                return dicOut;
            }
            private static List<int[]> getRangesOfTickets(List<int[]> tickets)
            {
                List<int[]> ranges= new List<int[]>();
                for(int i = 0; i < tickets.Count; i++)
                {
                    int[] tempIntAr = { tickets[i][0], tickets[i][0] };
                    ranges.Add(tempIntAr);
                    for(int j = 0; j < tickets[i].Length; j++)
                    {
                       if(tickets[i][j] <= ranges[i][0])
                        {
                            ranges[i][0] = tickets[i][j];
                        }
                       else if (tickets[i][j] >= ranges[i][1])
                        {
                            ranges[i][1] = tickets[i][j];
                        }
                    }
                }
                return ranges;
            }
            private static bool checkTicket(int[] ticket, List<int[]> ranges)
            {
                bool AllValid = true, inRange;
                for(int i = 0; i < ticket.Length; i++)
                {
                    inRange = false;
                    for (int j = 0; j < ranges.Count; j++)
                    {
                        if (isBetween(ticket[i], ranges[j]))
                        {
                            inRange = true;
                        }
                    }
                    if (!inRange)
                    {
                        AllValid = false;
                    }
                }
                return AllValid;
            }
            private static int checkMatches(MatchCollection matches, List<int[]> ranges)
            {
                bool inRange;
                int numOut = 0;
                foreach (Match match in matches)
                {
                    inRange = false;
                    for (int i = 0; i < ranges.Count; i++)
                    {
                        if (isBetween(Convert.ToInt32(match.Value), ranges[i]))
                        {
                            inRange = true;
                        }
                    }
                    if (!inRange)
                    {
                        numOut += Convert.ToInt32(match.Value);
                    }
                }
                return numOut;
            }
            private static List<int[]> getRanges (string input)
            {
                List<int[]> ranges = new List<int[]>();
                MatchCollection matches = Regex.Matches(input, @"[\d]+-[\d]+");

                foreach (Match match in matches)
                {
                    ranges.Add(Array.ConvertAll(Regex.Split(match.Value, @"-"), int.Parse));
                }
                return simplifyRanges(ranges);

            }
            private static List<int[]> p2getRanges(string input)
            {
                List<int[]> ranges = new List<int[]>();
                MatchCollection matches = Regex.Matches(input, @"[\d]+-[\d]+");

                foreach (Match match in matches)
                {
                    ranges.Add(Array.ConvertAll(Regex.Split(match.Value, @"-"), int.Parse));
                }
                return ranges;

            }
            private static List<int[]> simplifyRanges(List<int[]> rangeIn)
            {
                int largestNum = 0, bottomRange = 0,topRange = 0;
                List<int[]> rangeOut = new List<int[]>();
                for (int i = 0; i < rangeIn.Count; i++)
                {
                    if (rangeIn[i][1] > largestNum)
                    {
                        largestNum = rangeIn[i][1];
                    }
                }
                int[] range = new int[largestNum + 1] ;
                for(int i = 0; i < rangeIn.Count; i++)
                {
                    for(int j = rangeIn[i][0]; j <= rangeIn[i][1]; j++)
                    {
                        range[j] = 1;
                    }
                }
                
                for (int i = 0; i < range.Length; i++)
                {
                    if(range[i] == 1)
                    {
                        bottomRange = i;
                        for(int j = i + 1; j < range.Length; j++)
                        {
                            if(range[j] == 0)
                            {
                                topRange = j - 1;
                                break;
                            }
                            else if (j == range.Length - 1)
                            {
                                topRange = j;
                            }
                        }
                        
                        int[] tmpRange = { bottomRange + 1, topRange + 1 };
                        rangeOut.Add(tmpRange);
                        i = topRange;
                    }
                }

                return rangeOut;
            }
            private static bool checkTicketNumber(int ticketNo, List<int[]> ranges)
            {
                foreach(int[] range in ranges)
                {
                    if (isBetween(ticketNo, range))
                    {
                        return true;
                    }
                }
                return false;
            }

            private static int[] rangesOverlap(int[] range1, int[] range2)
            {
                int[] rangeOut = null;
                if (isBetween(range1[0], range2))
                {
                        int[] inputArray = { range2[0], range1[1] };
                         rangeOut = inputArray;
                }
                if (isBetween(range1[1], range2))
                {
                    int[] inputArray = { range1[0], range2[1] };
                    rangeOut = inputArray;
                }
                return rangeOut;
            }


            private static bool isEncased(int[] small, int[] large)
            {
                if(small[0] >= large[1] & small[1] <= large[1])
                {
                    return true;
                }
                return false;
            }


            private static bool isBetween(int number, int[] range)
            {
                if(number >= range[0] & number <= range[1])
                {
                    return true;
                }
                else { return false; }
            }
        }
        public struct day17 {
            public static int conway4dCuber (string input)
            {
                string[] cubesIn = Regex.Split(input, @"\r\n");
                int size = cubesIn.Length;
                bool[,,,] conway = new bool[size, size, size,size];
                for (int i = 0; i < cubesIn.Length; i++)
                {
                    for (int j = 0; j < cubesIn[i].Length; j++)
                    {
                        conway[size/2,size / 2, i, j] = cubesIn[i][j] == '#';
                    }
                }
                for(int i = 0; i < 6; i++)
                {
                    conway = run4dConway(conway);
                }
                return count4dActive(conway);
            }
            private static bool[,,,] run4dConway(bool[,,,] conwayIn)
            {
                conwayIn = expand4d(conwayIn);
                int size = conwayIn.GetLength(0), neighbours;
                bool[,,,] conwayOut = new bool[size, size, size, size];
                Array.Copy(conwayIn, conwayOut, size);
                for (int h = 0; h < size; h++)
                {
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            for (int k = 0; k < size; k++)
                            {
                                neighbours = check4dNeighbours(conwayIn,h, i, j, k);
                                if (conwayIn[h,i, j, k] & neighbours != 2 & neighbours != 3)
                                {
                                    conwayOut[h,i, j, k] = false;
                                }
                                else if (conwayIn[h,i, j, k]) { conwayOut[h,i, j, k] = true; }
                                else if (!conwayIn[h,i, j, k] & neighbours == 3)
                                {
                                    conwayOut[h,i, j, k] = true;
                                }
                            }
                        }
                    }
                }
                return conwayOut;
            }
            private static int count4dActive(bool[,,,] conwayIn) 
            {
                int size = conwayIn.GetLength(0) - 1, sumOut = 0;
                for (int h = 0; h <= size; h++)
                {
                    for (int i = 0; i <= size; i++)
                    {
                        for (int j = 0; j <= size; j++)
                        {
                            for (int k = 0; k <= size; k++)
                            {
                                if (conwayIn[h,i, j, k])
                                {
                                    sumOut++;
                                }
                            }
                        }
                    }
                }
                return sumOut;
            }
            private static int check4dNeighbours(bool[,,,] conwayIn, int w, int x, int y, int z)
            {
                int neighbours = 0;
                int size = conwayIn.GetLength(0) - 1;
                int[] bottomVals = {w - 1, x - 1, y - 1, z - 1 };
                int[] topVals = {w + 1, x + 1, y + 1, z + 1 };
                for (int h = bottomVals[0]; h <= topVals[0]; h++)
                {
                    for (int i = bottomVals[1]; i <= topVals[1]; i++)
                    {
                        for (int j = bottomVals[2]; j <= topVals[2]; j++)
                        {
                            for (int k = bottomVals[3]; k <= topVals[3]; k++)
                            {
                                if (h != w | i != x | j != y | k != z)
                                {
                                    if (h >= 0 & h <= size & i >= 0 & i <= size & j >= 0 & j <= size & k >= 0 & k <= size)
                                    {
                                        if (conwayIn[h, i, j, k])
                                        {
                                            neighbours++;
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
                return neighbours;
            }
            private static bool[,,,] expand4d(bool[,,,] conwayIn)
            {
                int size = conwayIn.GetLength(0) + 2;
                bool[,,,] conwayOut = new bool[size,size, size, size]; // k = 1 is removing pieces from the array
                for (int h = 1; h <= size - 2; h++)
                {
                    for (int i = 1; i <= size - 2; i++)
                    {
                        for (int j = 1; j <= size - 2; j++)
                        {
                            for (int k = 1; k <= size - 2; k++)
                            {
                                conwayOut[h, i, j, k] = conwayIn[h - 1, i - 1, j - 1, k - 1];
                            }
                        }
                    }
                }
                return conwayOut;
            }
            public static int conwayCuber (string input)
            {
                string[] cubesIn =  Regex.Split(input, @"\r\n");
                int size = cubesIn.Length;
                bool[,,] conway = new bool[size, size, size];
                for (int i= 0; i < cubesIn.Length; i++)
                {
                    for(int j = 0; j < cubesIn[i].Length; j++)
                    {
                        conway[size/2,i,j] = cubesIn[i][j] == '#'; 
                    }
                }
                conwayWindow cWindow = showConway(expand(conway));                
                for(int i = 0; i < 6; i++)
                {
                    conway = runConway(conway);
                    cWindow.addCube(conway);
                }
                showConway(conway);
                return countActive(conway);
            }
            private static conwayWindow showConway(bool[,,] conwayIn)
            {
                conwayWindow newWin = new conwayWindow(conwayIn);
                newWin.Show();
                return newWin;
            }
            private static int countActive(bool[,,] conwayIn)
            {
                int size = conwayIn.GetLength(0) - 1, sumOut = 0;
                for(int i = 0; i <= size; i++)
                {
                    for (int j = 0; j <= size; j++)
                    {
                        for(int k = 0; k <= size; k++)
                        {
                            if (conwayIn[i, j, k])
                            {
                                sumOut++;
                            }
                        }
                    }
                }
                return sumOut;
            }
            private static bool[,,] runConway(bool[,,] conwayIn)
            {
                // checking if it needs expansion
                //if (checkForExpansion(conwayIn))
                //{
                    conwayIn = expand(conwayIn);
                
                int size = conwayIn.GetLength(0);
                int neighbours;
                bool[,,] conwayOut = new bool[size, size, size];
                Array.Copy(conwayIn, conwayOut, size);
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        for (int k = 0;  k < size; k++)
                        {
                            neighbours = checkNeighbours(conwayIn, i,j,k);
                            if (conwayIn[i, j, k] & neighbours != 2 & neighbours != 3)
                            {
                                conwayOut[i,j,k] = false;
                            }
                            else if (conwayIn[i, j, k]) { conwayOut[i, j, k] = true; }
                            else if (!conwayIn[i,j,k] & neighbours == 3)
                            {
                                conwayOut[i, j, k] = true;
                            }
                        }
                    }
                }
                return conwayOut;
            }
            private static int checkNeighbours(bool[,,] conwayIn,int x, int y, int z)
            {
                int neighbours = 0;
                int size = conwayIn.GetLength(0) - 1;
                int[] bottomVals = { x - 1, y - 1, z - 1 };
                int[] topVals = { x + 1, y + 1, z + 1 };
                //for(int i = 0; i < 3; i++)
                //{
                //    bottomVals[i] = bottomVals[i] < 0 ? 0 : bottomVals[i];
                //    topVals[i] = topVals[i] > size ? size : topVals[i];
                //}
                for (int i = bottomVals[0]; i <= topVals[0]; i++)
                {
                    for (int j = bottomVals[1]; j <= topVals[1]; j++)
                    {
                        for (int k = bottomVals[2]; k <= topVals[2]; k++)
                        {
                            if (i != x | j != y | k != z)
                            {
                                if (i >= 0 & i <= size & j >= 0 & j <= size & k >= 0 & k <= size)
                                {
                                    if (conwayIn[i, j, k])
                                    {
                                        neighbours++;
                                    }
                                }
                               
                            }
                        }
                    }
                }
                return neighbours;
            }
            private static bool[,,] expand(bool[,,] conwayIn)
            {
                int size = conwayIn.GetLength(0) + 2;
                bool[,,] conwayOut = new bool[size, size, size]; // k = 1 is removing pieces from the array
                for (int i = 1; i <= size - 2; i++)
                {
                    for (int j = 1; j <= size - 2; j++)
                    {
                        for(int k = 1; k <= size - 2; k++)
                        {
                            conwayOut[i, j, k] = conwayIn[i - 1, j -1, k-1];
                        }
                    }
                }
                return conwayOut;
            }
            private static bool checkForExpansion(bool[,,] conwayIn)
            {
                int size = conwayIn.GetLength(0) - 1;
                for (int i = 0; i < size; i++)
                {
                    for(int j = 0; j< size; j++)
                    {
                        for(int k = 0; k < size; k++)
                        {
                            if (checkEdge(i, j, k, conwayIn))
                            {
                                if (conwayIn[i, j, k])
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                return false;
            }
            private static bool checkEdge(int x, int y, int z, bool[,,] conwayIn)
            {
                int size = conwayIn.Length;
                if(x == 0 | x == size | y == 0 | y == size | z == 0 | z == size)
                {
                    return true;
                }
                return false;
            }
        }
        public struct day18 {
            public static int part1(string input)
            {
                string[] expressions = Regex.Split(input, @"\r\n");
                int sumOut = 0;
                for(int i = 0; i < expressions.Length; i++)
                {
                    sumOut += calculate(expressions[i]);
                }
                return sumOut;

            }
            public static int calculate(string expression)
            {
                MatchCollection matches = Regex.Matches(expression, @"\(([\d]+ (\*|\+) )+[\d]+\)");
                string expressionOut = expression;
                string[] expressionParts = new string[2];
                while (matches.Count != 0)
                {
                    int newInt;
                    expressionParts[0] = expressionOut.Substring(0, matches[0].Index );
                    expressionParts[1] = expressionOut.Substring(matches[0].Value.Length + matches[0].Index, expressionOut.Length - matches[0].Value.Length - matches[0].Index);
                    newInt = solveAll(matches[0].Value);
                    expressionOut = expressionParts[0] + newInt + expressionParts[1];
                    matches = Regex.Matches(expressionOut, @"\(([\d]+ (\*|\+) )+[\d]+\)");
                }
                return solveAll(expressionOut);                
            }
            private static int solveAll(string input)
            {
                List<string> expressions = new List<string>();
                MatchCollection matches = Regex.Matches(input, @"[\d]+|\*|\+");
                while (expressions.Count != matches.Count) { expressions.Add(matches[expressions.Count].Value); }
                while(expressions.Count > 1)
                {
                    List<string> toKeep = expressions.GetRange(3, expressions.Count - 3);
                    string toSolve = String.Join(" ", expressions.GetRange(0, 3));
                    expressions.Clear();
                    expressions.Add(Convert.ToString(solve(toSolve)));
                    expressions.AddRange(toKeep);
                }
                return Convert.ToInt32(expressions[0]);
            }
            private static int solve(string input)
            {
                int intOut;
                MatchCollection bracketMatches = Regex.Matches(input, @"[\d]+|\*|\+");
                if (bracketMatches[1].Value == "*")
                {
                    intOut = Convert.ToInt32(bracketMatches[0].Value) * Convert.ToInt32(bracketMatches[2].Value);
                }
                else
                {
                    intOut = Convert.ToInt32(bracketMatches[0].Value) + Convert.ToInt32(bracketMatches[2].Value);
                }
                return intOut;
            }
        }
        public struct day19 { }
        public struct day20 { }
        public struct day21 { }
        public struct day22 { }
        public struct day23 { }
        public struct day24 { }
        public struct day25 { }
    }
}
