using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using static PEA1_WindowApp.ExtensionMethod;

namespace PEA1_WindowApp
{
    class SimulatedAnnealing
    {
        public float temperature { get; set; }
        public int minCost { get; set; }
        public float time { get; set; }
        public float Cooling { get; set; }
        public List<int> minPath = new List<int>();

        private ReadData rd = new ReadData();

        public SimulatedAnnealing()
        {
//            temperature = vertex;
//            minCost = 0;
//            minPath.Clear();
        }

        public void SaAlgorithm()
        {
            Random rand = new Random();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            List<int> tempDataList = new List<int>();
            rd.ReadFromFile();
            foreach (var s in rd.list)
            {
                tempDataList.Add(int.Parse(s));
            }
           // tempDataList = rd.list.ConvertAll(int.Parse);
            tempDataList = RandomPath(tempDataList);
            int tempCost = CalculateCost(tempDataList);

            do
            {
                for (int i = 0; i < rd.vertex; i++)
                {
                    List<int> shuffledList = new List<int>();
                    shuffledList = ShuffleList(tempDataList);
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
                watch.Stop();

            } while (Math.Ceiling((double)watch.ElapsedMilliseconds * 1000) <= time);

            minPath = tempDataList;
            minCost = tempCost;

        }

        public List<int> ShuffleList(List<int> tempList)
        {
            List<int> temp = tempList;

            Random rand = new Random();

            int x = 0;
            int y = 0;

            do
            {
                x = rand.Next(0, rd.vertex);
                y = rand.Next(0, rd.vertex);

            } while (x == y);

            temp.Swap(x, y);

            return temp;
        }

        public int CalculateCost(List<int> tempList)
        {
            int cost = 0;

            for (int i = 0; i < tempList.Count - 1; i++)
            {
                cost += rd.list[tempList.ElementAt(i)][tempList.ElementAt(i + 1)];
            }
            
            cost += rd.list[tempList.ElementAt(tempList.Last() - 1)][tempList.ElementAt(0)];

            return cost;
        }

        public float Probability(int newCost, int oldCost, double currentTemperature)
        {
            float result = 0;

            result = (float) Math.Pow(Math.E, (-(newCost - oldCost) / currentTemperature));

            return result;
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