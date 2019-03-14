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
    class SimulatedAnnealing : ReadData
    {
        public int temperature;
        public int minCost;
        public List<int> minPath = new List<int>();

        public SimulatedAnnealing()
        {
            temperature = vertex;
            minCost = 0;
            minPath.Clear();
        }

        public void SaAlgorithm()
        {
            
        }

        public List<int> ShuffleList(List<int> tempList)
        {
            List<int> temp = tempList;

            Random rand = new Random();

            int x = 0;
            int y = 0;

            do
            {
                x = rand.Next(0, vertex);
                y = rand.Next(0, vertex);

            } while (x == y);

            temp.Swap(x, y);

            return temp;
        }

        public int CalculateCost(List<int> tempList)
        {
            int cost = 0;

            for (int i = 0; i < tempList.Count - 1; i++)
            {
                cost += list[tempList.ElementAt(i)][tempList.ElementAt(i + 1)];
            }
            
            cost += list[tempList.ElementAt(tempList.Last() - 1)][tempList.ElementAt(0)];

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
            for (int i = 0; i < vertex; i++)
            {
                tempList.Add(i);
            }

            tempList.Shuffle();

            return tempList;
        }
    }

}
