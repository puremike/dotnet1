using System;

namespace DataStructures
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nUSING ARRAYS AND LIST.......\n");
            // First way to declare an array - a little bit old way
            //string[] topic = new string[3];
            //topic[0] = "Learn";
            //topic[1] = "Earn";
            //topic[2] = "Enjoy"
            //Console.WriteLine(topic[0] + ", " + topic[1] + ", " + topic[2]);

            // Second way to declare an array - most preferred
            string[] topics = ["Array", "Dictionary", "Maps"];

            Console.WriteLine($"Topics in data structures are - {String.Join(", ", topics[0..3])} ");
            Console.WriteLine($"The first topic is {topics[0]}");
            Console.WriteLine($"The first topic is {topics[1]}");
            Console.WriteLine($"The first topic is {topics[2]}");

            //  using a list
            // first way is by initiaiting a new instance of the list
            List<string> otherUnrelatedTopics = new List<string>();
            otherUnrelatedTopics.Add("Math");
            otherUnrelatedTopics.Add("Physics");
            Console.WriteLine(otherUnrelatedTopics[0] + ", " + otherUnrelatedTopics[1]);

            // second way is more direct and modern - most preferred
            List<string> sportTopics = ["BasketBall", "Football", "Swimming"];
            Console.WriteLine(sportTopics[0] + ", " + sportTopics[1] + ", " + sportTopics[2]);
            sportTopics.Add("VolleyBall");
            Console.WriteLine(sportTopics[3]);
            Console.WriteLine($"Length of the list: {sportTopics.Count()}"); // length of elements in the list or array

            // list for number type - creating a new instance of list and appending elements directly
            List<int> ascendingNumbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine(String.Join(", ", ascendingNumbers));

            Console.WriteLine("\nUSING IENUMERABLE WITH LIST ......\n");

            // IEnumerable are immutable
            IEnumerable<string> sportTopicsEnumerable = sportTopics; //IEnumerable
            Console.WriteLine(sportTopicsEnumerable.ElementAt(3));

            // Convert an IEnumerable to a list or an array
            //List<string> sportTopicsIEnumerableToList = sportTopicsEnumerable.ToArray();
            List<string> sportTopicsIEnumerableToList = sportTopicsEnumerable.ToList();
            Console.WriteLine("ConvertedSportTopicsIEnumerableToList: " + sportTopicsIEnumerableToList[3]);

            Console.WriteLine("\nMultidimentional Array .....\n");

            int[,] twoLevelMultArray = { { 1, 2, 3 }, { 5, 2, 1 } }; 

            int[,,] threeLevelMultArray = { { { 1, 2 }, { 3, 4 }, { 5, 6 } }, { { 7, 8 }, { 9, 10 }, { 11, 12 } } };

            Console.WriteLine(twoLevelMultArray[0, 2]); // Output: 3

            Console.WriteLine(threeLevelMultArray[0, 2, 1]); // Output: 6


            Console.WriteLine("\nUSING DICTIONARY .....\n");

            Dictionary<string, string> countryCity = new Dictionary<string, string>();
            countryCity["Nigeria"] = "FCT Abuja";
            countryCity["India"] = "Mumbai";


            Dictionary<int, bool> checkEvenNumbers = new Dictionary<int, bool>();
            checkEvenNumbers[2] = true;
            checkEvenNumbers[3] = false;

            // dict can take array
            Dictionary<string, int[]> oddEvenNumbers = new Dictionary<string, int[]>();
            oddEvenNumbers["Odd Numbers"] = new int[]{1, 3, 5, 7, 9 }; // one way
            oddEvenNumbers["Even Numbers"] = [2, 4, 6, 8, 10]; // another way

            Console.WriteLine($"Nigeria: {countryCity["Nigeria"]}");
            Console.WriteLine(checkEvenNumbers[2]);
            Console.WriteLine($"Odd Number from 1 - 10: {String.Join(", ", oddEvenNumbers["Odd Numbers"])}");
            Console.WriteLine($"Even Numbers from 1 - 10: {String.Join(", ", oddEvenNumbers["Even Numbers"])}");


        }
    }
}
