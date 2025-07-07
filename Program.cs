using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Advanced_Algorithms2
{
    internal class Program
    {
        // array take elements and sorting ascending thats why at binary search can find the true index 
        static int LinearSearch(int[] Arr, int x)
        {
            int ArrLength = Arr.Length;
            for (int i = 0; i < ArrLength; i++)
            {
                if (Arr[i] == x)
                {
                    return i;
                }
            }


            return -1;
        }
        public static void LinearSearchInMain()
        {
            int[] MyArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            int SearchedNumber = 5;
            int FoundedIndex = LinearSearch(MyArr, SearchedNumber);

            if (FoundedIndex == -1)
            {
                Console.WriteLine("Element Not Found");
            }
            else { Console.WriteLine("Element founded at index" + FoundedIndex); }

        }
        public static void BinarySearchMain()
        {
            int[] MyArr = { 1, 34, 54, 67, 98, 765, 890, 900, 910, 934 };

            int[] MyArr2 = { 53, 643, 4542, 56, 6643, 5543, 5653 };
            int SearchedNumber = 900;
            int SearchedNumber2 = 56;
            int FoundedIndex2 = BinarySearch(MyArr2, SearchedNumber2);
            Console.WriteLine("Elements at first array");
            foreach (int item in MyArr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            int FoundedIndex = BinarySearch(MyArr, SearchedNumber);

            if (FoundedIndex == -1)
            {
                Console.WriteLine("Element not found");
            }
            else
            {
                Console.WriteLine("Elemnet Found at index " + FoundedIndex);
            }
            Console.WriteLine("Elemnts at second array");
            foreach (int item in MyArr2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            if (FoundedIndex2 == -1)
            {
                Console.WriteLine("Element 2 not founded");
            }
            else
            {
                Console.WriteLine("Element 2 found at index " + FoundedIndex2);
            }
        }
        static int BinarySearch(int[] Arr, int x)
        {
            int Trial = 0;
            int start = 0, End = Arr.Length - 1;
            while (start <= End)
            {
                Trial++;
                int Middle = start + (End - start) / 2;
                if (Arr[Middle] == x)
                {
                    Console.WriteLine("Total Trials= " + Trial);
                    return Middle;

                }
                if (x > Arr[Middle])
                {
                    start = Middle + 1;



                }
                else
                {
                    End = Middle - 1;
                }



            }

            return -1;
        }

        static void BubbleSort(int[] Arr)
        {

            // this method is too slow it takes o n square time 
            // dont use this method at all it just to learn
            int n = Arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (Arr[j] > Arr[j + 1])
                    {
                        int temp = Arr[j];
                        Arr[j] = Arr[j + 1];
                        Arr[j + 1] = temp;

                    }

                }

            }

        }

        public static void BubbleSortMain()
        {
            int[] MyArr = { 1, 64, 765, 7, 74, 334, 7654, 56 };

            Console.WriteLine("All Elements at Array");

            foreach (int i in MyArr)
            {

                Console.Write(i + ",");

            }
            BubbleSort(MyArr);
            Console.WriteLine("\nAll eLemnts after bubble sort");
            foreach (int i in MyArr)
            {

                Console.Write(i + ",");
            }
            Console.ReadKey();
        }
        static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;


                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }
        static void SelectionSortAsc(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[minIndex])
                        minIndex = j;

                int temp = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = temp;
            }
        }

        public static class CoinChange
        {
            static List<int> Coins = new List<int> { 1, 5, 10, 20, 50, 10 };
            static int Amount = 33;

            public static void OverView()
            {
                List<int> Result = MinResult(Coins, Amount);
                Console.WriteLine("All Coins ");
                int totalCoins = 0;
                foreach (var coin in Result)
                {

                    Console.Write(coin + " ");
                    totalCoins++;
                }
                Console.WriteLine("\nTotal Given coins: " + totalCoins);
                Console.ReadKey();


            }

            static List<int> MinResult(List<int> Coins, int Amount)
            {
                Coins.Sort((a, b) => b.CompareTo(a)); // this for descending and not repeating
                List<int> Result = new List<int>();

                foreach (var coin in Coins)
                {
                    while (Amount >= coin)
                    {
                        Result.Add(coin);
                        Amount -= coin;
                    }
                }


                return Result;
            }



        }

        public static class ActivitySelection
        {
            public class Activity
            {
                public int Start { get; set; }
                public int End { get; set; }
                public Activity(int start, int end)
                {
                    Start = start;
                    End = end;
                }

            }

            static public void Overview()
            {
                List<Activity> Activities = new List<Activity> {

                    new Activity(4,7),
                    new Activity(5,8),
                    new Activity(6,9),
                    new Activity(7,10),
                    new Activity(5,11),

                };

                Console.WriteLine("Activities List");
                foreach (var a in Activities)
                {
                    Console.WriteLine($"Activity({a.Start},{a.End})");
                }

                var SelectedActivities = SelectActivities(Activities);

                Console.WriteLine("Selected Activities");
                foreach (Activity a in SelectedActivities)
                {
                    Console.WriteLine($"Activity({a.Start},{a.End})");

                }
                Console.ReadKey();


            }

            static List<Activity> SelectActivities(List<Activity> Activities)
            {
                Activities.Sort((a, b) => a.End.CompareTo(b.End));

                List<Activity> Result = new List<Activity>();

                Activity LastSelectedActivity = null;
                foreach (Activity a in Activities)
                {

                    if (LastSelectedActivity == null || a.Start >= LastSelectedActivity.End)
                    {
                        Result.Add(a);
                        LastSelectedActivity = a;
                    }
                }

                return Result;
            }
        }

        public static class Queoue_Stack_Problems
        {

            public static void BrowserBackButton()
            {
                Stack<string> Pages = new Stack<string>();

                Pages.Push("Page1");
                Pages.Push("Page2");
                Pages.Push("Page3");

                Console.WriteLine("Previous Page " + Pages.Pop());
                Console.WriteLine("Current Page " + Pages.Peek());



            }
            public static string ConvertDecimalToBinary(int Number)
            {
                Stack<int> Binary = new Stack<int>();

                while (Number > 0)
                {

                    Binary.Push(Number % 2);

                    Number /= 2;

                }
                return string.Join("", Binary);


            }

            public static void UndoCalculator()
            {
                Stack<int> stack = new Stack<int>();

                stack.Push(1);
                stack.Push(2);
                stack.Push(3);
                Console.WriteLine("Current is: " + stack.Peek());
                stack.Pop();
                Console.WriteLine("Undo Current succeseed  ");
                Console.WriteLine("Current is: " + stack.Peek());
            }

            public static void TraficSimulation()
            {

                Queue<string> Queue = new Queue<string>();

                Queue.Enqueue("Car 1");
                Queue.Enqueue("Truck 1");
                Queue.Enqueue("Bike 1");
                Queue.Enqueue("Bus 1");

                Console.WriteLine("Traffic Signal Simulation Started");

                while (Queue.Count > 0)
                {
                    Console.WriteLine(Queue.Peek() + " has Passed The Signal ");
                    Queue.Dequeue();
                    if (Queue.Count > 0)
                    {
                        Console.WriteLine("Vehicles Waiting: " + string.Join(",", Queue));
                    }
                    if (Queue.Count == 0)
                    {
                        Console.WriteLine("No Vehicles Waiting");
                    }

                }
                Console.WriteLine("Traffic Signal Simulation Ended");
            }

            public static void TicketsSimulation()
            {
                Queue<int> Queue = new Queue<int>();

                for (int i = 101; i <= 105; i++)
                {
                    Console.WriteLine("Ticket: " + i + " Issued.");
                    Queue.Enqueue(i);
                }

                Console.WriteLine("Ticket Simulation Started");
                while (Queue.Count > 0)
                {

                    Console.WriteLine("Processing: " + Queue.Peek());
                    Queue.Dequeue();
                    if ((Queue.Count != 0))
                    {
                        Console.WriteLine("Remaining Tickets: " + string.Join(",", Queue));

                    }
                    else
                    {
                        Console.WriteLine("No Remaining Tickets");
                    }




                }


            }

            public static void SimpleBacktracking()
            {
                Stack<string> Duties = new Stack<string>();

                Duties.Push("Start");
                Duties.Push("Go To Gas Station");
                Duties.Push("Go To Supermarket");
                Duties.Push("Go To Work");
                Duties.Push("Go to Cafe");
                Duties.Push("Go To Home");


                Console.WriteLine(string.Join("->", Duties.ToArray().Reverse()));
                while (Duties.Count > 0)
                {
                    Console.WriteLine("->" + Duties.Pop());
                }
                Console.ReadKey();
            }

            public static void TaskScheduling()
            {
                Queue<string> Tasks = new Queue<string>();

                Tasks.Enqueue("Task 1");
                Tasks.Enqueue("Task 2");
                Tasks.Enqueue("Task 3");
                Tasks.Enqueue("Task 4");

                while (Tasks.Count > 0)
                {

                    string CurrentTask = Tasks.Dequeue();

                    Console.WriteLine("Proccesing -> " + CurrentTask);
                }
            }

            public static Queue<int> ReversingQueuo(Queue<int> Q)
            {
                Stack<int> S = new Stack<int>();
                while (Q.Count > 0)
                {
                    S.Push(Q.Dequeue());
                }
                while (S.Count > 0)
                {

                    Q.Enqueue(S.Pop());
                }

                return Q;

                //Queue<int> intsQ = new Queue<int>(new[] { 1, 2, 3, 4, 5 });

                //Console.WriteLine(string.Join(",", intsQ));

                //Queue<int> ReversedQueoe = ReversingQueuo(intsQ);

                //Console.WriteLine(string.Join(",", ReversedQueoe));
            }

            public static bool IsQueoePalindrome(Queue<int> Q)
            {

                Stack<int> S = new Stack<int>(Q);


                if (S.Pop() == Q.Dequeue())
                {
                    return true;
                }



                return false;






            }

            public static void GenerateBinaryFromNumber(int number)
            {

                Queue<string> Q = new Queue<string>();
                Q.Enqueue("1");
                for (int i = 0; i < number; i++)
                {

                    string Binary = Q.Dequeue();
                    Console.WriteLine($"{Binary}");
                    Q.Enqueue(Binary + "0");
                    Q.Enqueue(Binary + "1");

                }

            }

            public static void SortElemnts(Queue<int> Q)
            {

                List<int> L = new List<int>(Q);

                L.Sort();

                Console.WriteLine(string.Join(",", L));
            }

            public static void InterLeaveElements(Queue<int> Q)
            {
                int halfSize = Q.Count / 2;

                Stack<int> S = new Stack<int>(Q);

                for (int i = 0; i <= halfSize; i++)
                {
                    S.Push(Q.Dequeue());

                }
                while (S.Count > 0)
                {
                    Q.Enqueue(S.Pop());
                }

                for (int i = 0; i < halfSize; i++)
                {
                    Q.Enqueue(Q.Dequeue());
                }

                for (int i = 0; i < halfSize; i++)
                {
                    S.Push(Q.Dequeue());
                }

                while (S.Count > 0)
                {
                    Q.Enqueue(S.Pop());
                    Q.Enqueue(Q.Dequeue());
                }


            }

            public static Queue<int> RotateQueue(Queue<int> Q, int K)
            {
                for (int i = 0; i < K; i++)
                {
                    Q.Enqueue(Q.Dequeue());
                }
                return Q;
            }

            public static Queue<int> MergeQueues(Queue<int> q1, Queue<int> q2)

            {
                Queue<int> Merged = new Queue<int>();
                while (q1.Count > 0 && q2.Count > 0)
                {
                    if (q1.Peek() <= q2.Peek())
                    {
                        Merged.Enqueue(q1.Dequeue());
                    }
                    else
                    {
                        Merged.Enqueue(q2.Dequeue());
                    }
                }
                while (q1.Count > 0)
                {
                    Merged.Enqueue(q1.Dequeue());
                }
                while (q2.Count > 0)
                {
                    Merged.Enqueue(q2.Dequeue());
                }
                return Merged;
            }

            public static void FindFirstNonRepeating(string stream)
            {
                Dictionary<char, int> dict = new Dictionary<char, int>();
                Queue<char> Q = new Queue<char>();

                foreach (char c in stream)
                {
                    if (!dict.ContainsKey(c))
                    {
                        dict[c] = 0;
                    }

                    dict[c]++;
                    Q.Enqueue(c);
                    while (Q.Count > 0 && dict[Q.Peek()] > 1)
                    {
                        Q.Dequeue();
                    }
                    Console.WriteLine(Q.Count > 0 ? Q.Peek() : '-');
                }
            }

            class MyQ
            {
                static Stack<int> S1 = new Stack<int>();
                static Stack<int> S2 = new Stack<int>();

                public static void Enqueue(int x)
                {
                    S1.Push(x);
                }
                public static bool IsEmpty()
                {
                    return S1.Count == 0 && S2.Count == 0;
                }
                public static int Dequeue()
                {
                    if (S2.Count == 0)
                    {
                        while (S1.Count > 0)
                        {
                            S2.Push(S1.Pop());
                        }
                    }
                    return S2.Pop();
                }



            }

            public static Queue<int> RearrangeAlternatly(Queue<int> queue)
            {
                List<int> list = new List<int>(queue);
                Queue<int> Result = new Queue<int>();
                int n = list.Count;

                for (int i = 0; i < n / 2; i++)
                {
                    Result.Enqueue(list[i]);
                    Result.Enqueue(list[i - 1 - n]);
                }
                if (n % 2 != 0)
                {
                    Result.Enqueue(list[n / 2]);
                }


                return Result;

            }

            class ProrityQueue
            {
                SortedDictionary<int, Queue<int>> queue = new SortedDictionary<int, Queue<int>>();

                public void Enquee(int value, int Priority)
                {
                    if (!queue.ContainsKey(Priority))
                    {
                        queue[Priority] = new Queue<int>();
                    }
                    queue[Priority].Enqueue(value);
                }
                public int Dequee()
                {
                    if (queue.Count == 0) { return 0; }

                    int HighestPriority = queue.Keys.Min();
                    int Value = queue[HighestPriority].Dequeue();
                    if (queue[HighestPriority].Count == 0)
                    {
                        queue.Remove(HighestPriority);
                    }
                    return Value;
                }
            }

            public static Queue<int> RearrangeEvenAndOdd(Queue<int> Q)
            {
                Queue<int> Q_Odd = new Queue<int>();
                Queue<int> Q_Even = new Queue<int>();
                Queue<int> Q_Result = new Queue<int>();



                while (Q.Count > 0)
                {
                    int n = Q.Dequeue();
                    if (n % 2 == 0)
                        Q_Even.Enqueue(n);
                    else
                        Q_Odd.Enqueue(n);


                }
                while (Q_Even.Count > 0)
                {
                    Q.Enqueue(Q_Even.Dequeue());

                }
                while (Q_Odd.Count > 0)
                {
                    Q.Enqueue(Q_Odd.Dequeue());

                }

                return Q;
            }

            public static Queue<int> CloneQueue(Queue<int> q)
            {

                if (q.Count == 0) { return null; }

                Queue<int> Clone = CloneQueue(q);

                int front = q.Dequeue();

                q.Enqueue(front);
                Clone.Enqueue(front);



                return Clone;

            }

            public static int FindMiddleElementAtQueue(Queue<int> q)
            {
                List<int> list = new List<int>();
                return list[list.Count / 2];

            }

            public static string ReverseString(string s)
            {
                Stack<char> stack = new Stack<char>();
                string ReversedWord = "";
                foreach (char c in s)
                {
                    stack.Push(c);

                } while (stack.Count > 0)
                {
                    ReversedWord += stack.Pop();
                }
                return ReversedWord;

            }

            public static bool checkBalancedParenthes(string input)
            {
                Stack<char> stack = new Stack<char>();


                foreach (char c in input)
                {
                    if (c == '(' || c == '{' || c == '[')
                    {
                        stack.Push(c);
                    }
                    else if (c == ')' || c == '}' || c == ']')
                    {
                        if (stack.Count == 0)
                            return false;


                        char top = stack.Pop();


                        if ((c == ')' && top != '(') ||
                            (c == '}' && top != '{') ||
                            (c == ']' && top != '['))
                        {
                            return false;
                        }
                    }
                }


                return stack.Count == 0;




            }

            public static bool IsPalindrome(string input)
            {
                Stack<char> S = new Stack<char>();
                foreach (char c in input)
                {
                    S.Push(c);

                }
                foreach (char c in input)
                {
                    if (c != S.Pop())
                    {
                        return false;
                    }
                }
                return true;




            }

            public static int EvaluatePostfix(string input)
            {
                Stack<int> stack = new Stack<int>();

                foreach (char c in input)
                {
                    if (char.IsDigit(c))
                    {
                        stack.Push(c - '0');
                    }
                    else
                    {
                        int b = stack.Pop();
                        int a = stack.Pop();
                        switch (c)
                        {
                            case '+': stack.Push(a + b); break;
                            case '*': stack.Push(a * b); break;
                            case '-': stack.Push(a - b); break;
                            case '/': stack.Push(a / b); break;


                        }
                    }
                }
                return stack.Pop();
            }
        }

        public static class Dictionary_Hashset_Problems
        {
            public static void RetriveStudentGrade()
            {
                Dictionary<string, int> StudentGrade = new Dictionary<string, int>();

                StudentGrade["Ahmet"] = 56;

                StudentGrade["Abdullah"] = 90;

                if (StudentGrade.ContainsKey("Ahmet"))
                {
                    Console.WriteLine("Ahmet Grade is: " + StudentGrade["Ahmet"]);
                }
            }

            public static void StoreBookInformation()
            {
                Dictionary<string, (string Title, string Author)> Book = new Dictionary<string, (string, string)>()
                {
                    {"978-3-16-148410-0",("The Great Gatsby", "F. Scott Fitzgerald") },
                    {"123-456-789-123-4",("Hello World","Ahmet Abdullah") }
                };

                foreach (var B in Book)
                {

                    Console.WriteLine($"ISBN: {B.Key} , Author: {B.Value.Author} , Title: {B.Value.Title} ");
                }


            }

            public static void TranslateWords()
            {
                Dictionary<string, string> Translate = new Dictionary<string, string>()
                {
                    {"Hello","Hola" }, {"Good Bye", "Adios"}

                };

                foreach (var B in Translate)
                {
                    Console.WriteLine($"English: {B.Key} => Spanish {B.Value}");
                }

            }

            public static void CountFrequencies()
            {
                string Text = "hello World hello Me";
                Dictionary<string, int> WordCounter = new Dictionary<string, int>();



                foreach (var word in Text.Split(' '))
                {
                    if (WordCounter.ContainsKey(word))
                    {
                        WordCounter[word]++;
                    }
                    else
                    {
                        WordCounter[word] = 1;
                    }

                }

                foreach (var WC in WordCounter)
                {

                    Console.WriteLine($"Word is: {WC.Key} Repeated {WC.Value} Time");
                }
            }

            public static void DuplicatedEntries()
            {
                HashSet<string> DataEntries = new HashSet<string>();


                string[] Entries = { "A", "B", "C", "D", "A", "B" };
                foreach (string Entry in Entries)
                {

                    if (!DataEntries.Contains(Entry))
                    {

                        DataEntries.Add(Entry);
                    }
                    else
                    {
                        Console.WriteLine($"{Entry} is Repeated");
                    }



                }
                foreach (string Entry in DataEntries)
                {

                    Console.Write("\n" + Entry + " not ");
                }
                Console.ReadKey();
            }

            public static void DynamicSkillMatching()
            {
                HashSet<string> JopRequirements = new HashSet<string>() { "C#", "JS", "React" };
                HashSet<string> CandidateSkills = new HashSet<string>() { "SQL", "JS", "C#" };

                CandidateSkills.IntersectWith(JopRequirements);



                Console.WriteLine(string.Join(",", CandidateSkills));

            }

            public static void CharacterFrequency(string Input)
            {
                Dictionary<char, int> charFreq = new Dictionary<char, int>();

                foreach (char c in Input)
                {
                    if (charFreq.ContainsKey(c))
                    {
                        charFreq[c]++;
                    }
                    else
                    {
                        charFreq[c] = 1;
                    }
                }

                Console.WriteLine("Word is: " + Input);

                foreach (var c in charFreq)
                {

                    Console.WriteLine($"{c.Key}: {c.Value}; ");
                }

            }

            public static int MajorityElement(int[] ints)
            {
                Dictionary<int, int> Counts = new Dictionary<int, int>();

                int MajorityCount = ints.Length / 2;


                foreach (int num in ints)
                {

                    if (!Counts.ContainsKey(num))
                        Counts[num] = 0;

                    Counts[num]++;

                    if (Counts[num] > MajorityCount)
                        return num;

                }
                return -1;
            }

            public static void FindDuplicate(int[] nums)
            {
                Dictionary<int, int> Counts = new Dictionary<int, int>();
                List<int> Duplicates = new List<int>();

                foreach (int num in nums)
                {
                    if (Counts.ContainsKey(num))

                        Counts[num]++;
                    else

                        Counts[num] = 1;
                    if (Counts[num] == 2)
                    {
                        Duplicates.Add(num);
                    }


                }

                Console.WriteLine("All Ints Are " + string.Join(",", nums));
                Console.WriteLine("Duplicates Are: " + string.Join(",", Duplicates));
            }

            public static void FindUnique(int[] nums)
            {
                Dictionary<int, int> Counts = new Dictionary<int, int>();
                List<int> Unique = new List<int>();

                foreach (int num in nums)
                {
                    if (!Counts.ContainsKey(num))
                    {
                        Counts[num] = 0;
                    }

                    Counts[num]++;
                }

                foreach (var kvp in Counts)
                {
                    if (kvp.Value == 1)
                        Unique.Add(kvp.Key);
                }
                Console.WriteLine("all uniqe is: " + string.Join(" ", Unique));
            }

            public static int FindMissingNumber(int[] nums)
            {

                HashSet<int> NumsInSet = new HashSet<int>(nums);
                int n = nums.Length;

                for (int i = 0; i <= n; i++)
                {
                    if (!NumsInSet.Contains(i)) return i;
                }

                return -1;
            }

        }

        public static class SortedSet_Problems
        {
            public static void FindAllElementsInGivenRange(int[] nums)
            {
                SortedSet<int> nums_in_Set = new SortedSet<int>(nums);

                var Range = nums_in_Set.GetViewBetween(2, 4);

                Console.WriteLine(string.Join(" ", Range));




            }

            public static void FindMaxAndMin(int[] nums)
            {
                SortedSet<int> nums_in_set = new SortedSet<int>(nums);

                int max = nums_in_set.Max();
                int min = nums_in_set.Min();

                Console.WriteLine($"Max: {max} && Min: {min}");

            }

            public static void CountNumbersGreaterThan(int[] nums, int num)
            {
                SortedSet<int> nums_in_set = new SortedSet<int>(nums);

                var numsGreaterThanValue = nums_in_set.GetViewBetween(num + 1, int.MaxValue);

                Console.WriteLine("Number Greater than value: " + string.Join(",", numsGreaterThanValue));
            }

            public static void RemoveAllElementsWithInRange(int[] nums, int num1, int num2)
            {
                SortedSet<int> nums_in_Set = new SortedSet<int>(nums);
                var NumberInRange = nums_in_Set.GetViewBetween(num1, num2);
                Console.WriteLine("Numbers In Range");
                Console.WriteLine(string.Join(",", NumberInRange));
                NumberInRange.Clear();
                Console.WriteLine("Numbers Out of Range");
                Console.WriteLine(string.Join(",", nums_in_Set));

            }
        }

        public static void DynamicListOfStudentsUsingObservableCollectionsNotifaiction()
        {
            ObservableCollection<string> Students = new ObservableCollection<string>();

            Students.CollectionChanged += (sender, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add) { Console.WriteLine($"New Student Added: {e.NewItems[0]}"); }
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove) { Console.WriteLine($"Student Removed: {e.OldItems[0]}"); }
            };
            Students.Add("Ahmet");
            Students.Add("Zeynep");
            Students.Add("Merve");
            Students.Remove("Zeynep");
        }

        public static class JaggedArray_Problems
        {

            public static void StudentsGrade()
            {
                int[][] StudentsGrades = new int[][]
                {
                    new int[] {20,53,76}, new int[] {34,64,32}, new int[] {64,98,59 }


                };

                for (int i = 0; i < StudentsGrades.Length; i++)
                {

                    Console.WriteLine("Student: " + (i + 1));
                    Console.WriteLine(string.Join(",", StudentsGrades[i]));
                }
            }

            public static void ClassRoomSeats()
            {
                int[][] ClassSeats = new int[3][];

                ClassSeats[0] = new int[] { 1, 2, 3 };
                ClassSeats[1] = new int[] { 4, 5, 6 };
                ClassSeats[2] = new int[] { 7, 8, 9 };

                for (int i = 0; i < ClassSeats.Length; i++)
                {

                    Console.Write("Row" + (i + 1) + ": ");
                    foreach (int j in ClassSeats[i])
                    {
                        Console.Write(j + " ");
                    }
                    Console.WriteLine();

                }

            }

            public static void FlightSeatResevations()
            {
                bool[][] FlightSeats = new bool[2][];

                FlightSeats[0] = new bool[] { true, false, false };
                FlightSeats[1] = new bool[] { false, true, false };

                for (int i = 0; i < FlightSeats.Length; i++)
                {

                    Console.Write("Flight: " + (i + 1) + ": ");
                    foreach (bool F in FlightSeats[i])
                    {
                        Console.Write(F ? "Available " : "Occupaid ");

                    }
                    Console.WriteLine();
                    Console.ReadKey();

                }


            }
        }

        public static class Tuples_Problems
        {
            public static class ReturnMultipleValueFromFunction
            {
                static (string Name, int Age, double Grade) GetStudentDetails()
                {
                    return ("Ahmet", 22, 94.2);

                }
                public static void Overview()
                {
                    var StudentDetails = GetStudentDetails();

                    Console.WriteLine($"Student Name: {StudentDetails.Name} Student Age: {StudentDetails.Age} Student Grade: {StudentDetails.Grade}");
                }

            }

            public static void SoccerStates()
            {
                var Player = (Name: "Ronaldo", Health: 100, Score: 2000);

                Console.WriteLine($"States: Name: {Player.Name} Health: {Player.Health} Score: {Player.Score}");
            }

            public static (bool Success, int Result) ReturnFailureOrPass(int Value)
            {
                bool Success = Value >= 50 ? true : false;
                return (Success, Value);

            }
        }

        public static class BitArray_Problems
        {
            public static void LightsOffAndOn()
            {
                BitArray Lights = new BitArray(8, false); // 8 lights off

                Lights[0] = true;
                Lights[5] = true;

                Console.WriteLine($"Light 1 is {Lights[0]} & Light 6 is {Lights[5]} ");

                // Lights.SetAll(false);
                int Light = 1;
                foreach (var item in Lights)
                {
                    Console.WriteLine("Light[" + Light + "] is: " + item + " ");
                    Light++;
                }


            }

            public static void SurveyResponses()
            {
                BitArray SurveyResponses = new BitArray(5);
                SurveyResponses[0] = true;
                SurveyResponses[1] = false;
                SurveyResponses[2] = true;
                SurveyResponses[3] = false;
                SurveyResponses[4] = true;



                for (int i = 0; i < SurveyResponses.Length; i++)
                {
                    Console.WriteLine($"User {i + 1} Question {i + 1} Answer is {SurveyResponses[i]} ");
                }
            }

            public static void WeekDays()
            {

                BitArray WeekDays = new BitArray(7, false);

                WeekDays[5] = true;
                WeekDays[6] = true;

                for (int i = 0; i < WeekDays.Length; i++)
                {
                    if (WeekDays[i] == true)
                    {

                        Console.WriteLine($"Day {i + 1} is free ");
                    }
                  

                }

            }

            public static void PasswordStrengthChecker()
            {
                string Password = "ahmet";
                BitArray Checker = new BitArray(4, false);
                foreach (char i in Password) {
                    if (char.IsLetter(i)) { Checker[0] = true; }
                    if(char.IsLower(i)) { Checker[1] = true; }
                    if (char.IsDigit(i)) { Checker[2] = true; }
                    if(!char.IsLetterOrDigit(i)) { Checker[3] = true; }



                }
                Console.WriteLine($"Checks {Checker[0]}, {Checker[1]}, {Checker[2]}, {Checker[3]}");

            }

            public static void PasswordPolicy()
            {
                string password = "Ahmet123%132";
                BitArray Policy = new BitArray(5);

                if(password.Length > 8) Policy[0] = true;
                if(password.Any(char.IsUpper)) Policy[1] = true;
                if(password.Any(char.IsLower)) Policy[2] = true;
                if(password.Any(char.IsDigit)) Policy[3] = true;
                if(password.Any(ch => "!$%&/?".Contains(ch))) Policy[4] = true;
                bool IsValid = Policy.Cast<bool>().All(x => x);

                Console.WriteLine("Password Validation is: "+ IsValid);



            }

            public static void CoutntVoteYes() {


                BitArray Votes = new BitArray(8);
                Votes[0] = true;
                Votes[1] = true;
                    
                Votes[2] = true;
                Votes[3] = true;
                Votes[4] = true;
                Votes[5] = true;
                Votes[6] = false;
                Votes[7] = true;

                int YesVotes = 0;
                for (int i = 0; i < Votes.Length; i++) {

                    if (Votes[i] == true) YesVotes++;

                } 
                Console.WriteLine("Total Yes Votes: "+ YesVotes);   
            }
           
        }

        public static class HashTable_SortedList_SortedSet_Problems
        {
            public static void CopyHashTableToAnother()
            {
                Hashtable hashtable1 = new Hashtable();
                hashtable1.Add("Ahmet", 22);
                hashtable1.Add("Kerem", 13);
                Hashtable hashtable2 = new Hashtable(hashtable1);

                Console.WriteLine("Copied From Hashtable 1");
                foreach (DictionaryEntry entry in hashtable1)
                {
                    Console.WriteLine(entry.Key + " Age is " + entry.Value);
                }
            }
            public static void FindMissingNumber()
            {

                SortedSet<int> ints = new SortedSet<int>(new int[] { 0, 1, 2, 3, 4, 5, 6 });

                for (int i = 0; i < ints.Count; i++)
                {
                    if (!ints.Contains(i))
                    {
                        Console.WriteLine($"Not Contains {i}");
                    }
                }
            }


            public static void ActiveUsersTime()
            {
                SortedSet<DateTime> ActiveUsers = new SortedSet<DateTime>();

                ActiveUsers.Add(new DateTime(2025, 07, 07, 01, 02, 01));
                ActiveUsers.Add(new DateTime(2003, 07, 07, 12, 00, 00));

                foreach (var dt in ActiveUsers)
                {
                    Console.WriteLine(dt);
                }
            }

            public static class AutoCompleteSuggestions
            {

                public static void Overview()
                {
                    SortedSet<string> Words = new SortedSet<string> {
                    "apple", "application", "appreciate", "banana", "band", "bandwidth", "cat", "cater"
                    };
                    Console.WriteLine("Enter a Prefix");
                    string Prefix = Console.ReadLine();
                    var Suggestions = GetSuggestions(Prefix, Words);
                    Console.WriteLine("Suggestions");
                    foreach (var suggestion in Suggestions)
                    {
                        Console.WriteLine(suggestion + " ");
                    }


                }
                static IEnumerable<string> GetSuggestions(string Prefix, SortedSet<string> Words)
                {

                    foreach (var word in Words)
                    {

                        if (word.StartsWith(Prefix, StringComparison.OrdinalIgnoreCase))
                        {
                            yield return word;
                        }
                    }
                }
            }

            public static class Priority
            {
                class Task : IComparable<Task>
                {
                    public int Priority { get; set; }
                    public string Description { get; set; }

                    public int CompareTo(Task other)
                    {
                        int Result = this.Priority.CompareTo(other.Priority);
                        if(Result == 0)
                        {
                           Result=  this.Description.CompareTo(other.Description);
                        }
                        return Result;
                    }

                }
                public static void Overview()
                {
                    SortedSet<Task> tasks = new SortedSet<Task>();
                    tasks.Add(new Task { Priority = 1, Description = "Open The PC" });
                    tasks.Add(new Task { Priority = 1, Description = "Fix Bugs" });
                    tasks.Add(new Task { Priority = 2, Description = "Report Bugs" });
                    tasks.Add(new Task { Priority = 3, Description = "Take a Coffe" });
                   

                    foreach (var task in tasks)
                    {
                        Console.WriteLine( task.Priority + " " + task.Description);
                    }
                }
            }
        }

        public static class Trees_Problems
        {
            public static class FileSystemOrganization
            {
                class FileNode
                {
                    public string Name { get; set; }
                    public bool isFile {  get; set; }

                    public int Size { get; set; }
                    public List<FileNode> Children { get; set; } = new List<FileNode>();
                    public enum enType { Directory, File}

                    public FileNode(string Name, enType fType, int Size) { 
                    
                        this.Name = Name;
                        this.isFile = fType == enType.File? true: false; 
                        this.Size = Size;
                    }

                    public int CalculateTotalSize()
                    {

                        int TotalSize = this.Size;
                        foreach(var child in Children)
                        {
                            TotalSize += child.CalculateTotalSize();
                        }

                        return TotalSize;
                    }

                    public void Print(string indent = "") { 
                    

                        Console.WriteLine(indent + (isFile? "File":"Directory") + Name );

                        foreach (var child in Children) { 
                            
                            child.Print(indent + "  ");
                        }
                    }
                }
                public static void Overview()
                {
                    var Root = new FileNode("MyFile",FileNode.enType.Directory,0);

                    var Documents = new FileNode(" Documents", FileNode.enType.Directory,0);
                    var Photos = new FileNode(" Photos", FileNode.enType.Directory, 0);

                    Documents.Children.Add(new FileNode(" PDF",FileNode.enType.File,100));
                    Documents.Children.Add(new FileNode(" Downloads", FileNode.enType.File,200));

                    Photos.Children.Add(new FileNode(" MyPhotos", FileNode.enType.File,1000));
                    Photos.Children.Add(new FileNode(" Screenshots", FileNode.enType.File,700));

                    Root.Children.Add(Documents);
                    Root.Children.Add(Photos);
                    Console.WriteLine("File System \n");
                    Root.Print();
                    Console.WriteLine("Total Size: "+ Root.CalculateTotalSize() );
                }

            }

            public static class PriorityScheduling 
            {
                class Task
                {
                    public int Priority { get; set; }
                    public string Name {  get; set; }

                    public Task(string name, int priority )
                    {
                        Priority = priority;
                        Name = name;
                    }
                    public override string ToString() {
                        return ($"Name: {Name} Priority: {Priority}");
                    }
                }

                class MinHeap {
                    private List<Task> heap = new List<Task>();


                    public void Insert(Task task)
                    {
                        heap.Add(task);
                        HeapifyUp(heap.Count - 1);
                    }


                    public Task ExtractMin()
                    {
                        if (heap.Count == 0) return null;


                        var minTask = heap[0];
                        heap[0] = heap[heap.Count - 1];
                        heap.RemoveAt(heap.Count - 1);
                        HeapifyDown(0);


                        return minTask;
                    }


                    private void HeapifyUp(int index)
                    {
                        while (index > 0 && heap[index].Priority < heap[(index - 1) / 2].Priority)
                        {
                            Swap(index, (index - 1) / 2);
                            index = (index - 1) / 2;
                        }
                    }


                    private void HeapifyDown(int index)
                    {
                        int smallest = index;
                        int left = 2 * index + 1;
                        int right = 2 * index + 2;


                        if (left < heap.Count && heap[left].Priority < heap[smallest].Priority)
                            smallest = left;


                        if (right < heap.Count && heap[right].Priority < heap[smallest].Priority)
                            smallest = right;


                        if (smallest != index)
                        {
                            Swap(index, smallest);
                            HeapifyDown(smallest);
                        }
                    }


                    private void Swap(int i, int j)
                    {
                        var temp = heap[i];
                        heap[i] = heap[j];
                        heap[j] = temp;
                    }

                    public bool IsEmpty()
                    {
                        return heap.Count == 0;
                    }

                }

                public static void Overview()
                {
                    var scheduler = new MinHeap();

                   
                    scheduler.Insert(new Task("Task A", 3));
                    scheduler.Insert(new Task("Task B", 1));
                    scheduler.Insert(new Task("Task C", 2));
                    Console.WriteLine("Tasks entered in this order: Task A, Task B, Task C.\n");

               
                    Console.WriteLine("Executing tasks in priority order:");
                    while (!scheduler.IsEmpty())
                    {
                        Console.WriteLine(scheduler.ExtractMin());
                    }

                }
            }
        }
        static void Main(string[] args)
            {
               Trees_Problems.FileSystemOrganization.Overview();

            }
    }
}
