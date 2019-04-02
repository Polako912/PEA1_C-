using System;
using System.Collections.Generic;
using System.Linq;
using static PEA1_WindowApp.ExtensionMethod;

namespace PEA1_WindowApp
{
    class SimulatedAnnealing
    {
        public float temperature { get; set; }
        public int minCost { get; set; }
        public float time { get; set; }
        public float Cooling { get; set; }
        public List<int> minPath;

        private ReadData rd;

        public SimulatedAnnealing(ReadData rd)
        {
            minPath = new List<int>();
            this.rd = rd;
        }

        public void SaAlgorithm()
        {
            Random rand = new Random();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            List<int> tempDataList = new List<int>();
          
            tempDataList = RandomPath(tempDataList);
            int tempCost = CalculateCost(tempDataList);

            do
            {
                watch.Start();
          
                for (int i = 0; i < rd.vertex; i++)
                {
                    var shuffledList = ShuffleList(tempDataList);
                    int newCost = CalculateCost(shuffledList);

                    if (newCost < tempCost)
                    {
                        tempDataList = shuffledList;
                        tempCost = newCost;
                    }
                    else if (rand.NextDouble() < Probability(tempCost, newCost, temperature))
                    {
                        tempDataList = shuffledList;
                        tempCost = newCost;
                    }
                }

                temperature = temperature * Cooling;
               
            } while (watch.Elapsed <= TimeSpan.FromSeconds(time));

            watch.Stop();

            minPath = tempDataList;
            minCost = tempCost;

        }

        public List<int> ShuffleList(List<int> tempList)
        {
            List<int> temp = tempList;

            Random rand = new Random();

            int first = 0;
            int second = 0;

            do
            {
                first = rand.Next(0, rd.vertex);
                second = rand.Next(0, rd.vertex);

            } while (first == second);

            temp.Swap(first, second);

            return temp;
        }

        public int CalculateCost(List<int> tempList)
        {
            int cost = 0;

            for (int i = 0; i < tempList.Count - 1; i++)
            {
                cost += rd.matrix[tempList.ElementAt(i)][tempList.ElementAt(i + 1)];
            }
            
            cost += rd.matrix[tempList.ElementAt(tempList.Last())][tempList.ElementAt(tempList.First())];

            return cost;
        }

        public float Probability(int newCost, int oldCost, double currentTemperature)
        { 
            return (float)Math.Pow(Math.E, (-(newCost - oldCost) / currentTemperature)); ;
        }

        public List<int> RandomPath(List<int> tempList)
        {
            for (int i = 0; i < rd.vertex; i++)
            {
                tempList.Add(i);
            }

            tempList.Shuffle();

            return tempList;
        }
    }

}
