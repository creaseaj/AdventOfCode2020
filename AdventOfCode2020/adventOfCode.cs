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
                    oldLife[i] = new string[seats1D.Length];
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
                    lifeOut[i] = new string[seatsIn.Length];
                    Array.Copy(seatsIn[i], lifeOut[i], seatsIn[i].Length);
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
                                    k += row - i;
                                    l += column - j;
                                    if (!checkOutOfBounds(seatsIn, i, j))
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
                return busID - time % busID;
            }
        }
        public struct day14 { }
        public struct day15 { }
        public struct day16 { }
        public struct day17 { }
        public struct day18 { }
        public struct day19 { }
        public struct day20 { }
        public struct day21 { }
        public struct day22 { }
        public struct day23 { }
        public struct day24 { }
        public struct day25 { }
    }
}
