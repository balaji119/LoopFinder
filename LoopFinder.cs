using System;
using System.Collections.Generic;
using System.Linq;

namespace LoopFinder
{
    class LoopFinder
    {
        static void Main(string[] args)
        {
            // Get the number of test cases.
            int testCases = 0;
            try
            {
                testCases = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter valid input for number of test cases.");
                return;

            }

            // Get the test cases and print the loop count.
            try
            {
                for (int i = 0; i < testCases; i++)
                {
                    Loop loop = new Loop();
                    var cities = Console.ReadLine().Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    foreach (var city in cities)
                    {
                        loop.AddCity(city);
                    }
                    Console.WriteLine(loop.LoopCount);
                }
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }

        }
    }

    /// <summary>
    /// Class to represent loops
    /// </summary>
    class Loop
    {
        /// <summary>
        /// Add a city to list of cities.
        /// If a loop is formed, remove the cities in the loop and increment the loop count.
        /// </summary>
        /// <param name="city">Name of the city.</param>
        public void AddCity(string city)
        {
            if (!char.IsLetter(char.Parse(city))) throw new Exception("No a valid city.");
            if (_Cities.Contains(city))
            {
                var index = _Cities.IndexOf(city);
                _Cities.RemoveRange(index, _Cities.Count - index);
                _LoopCount++;
            }
            _Cities.Add(city);
        }

        /// <summary>
        /// Represent list of city travelled.
        /// </summary>
        public List<string> Cities { get { return _Cities; } }
        List<string> _Cities = new List<string>();

        /// <summary>
        /// Counter to keep track of the number of loops formed.
        /// </summary>
        public int LoopCount { get { return _LoopCount; } }
        int _LoopCount = 0;
    }
}
