using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PEA1_WindowApp
{
    class ReadData
    {
        public int vertex { get; set; }
        public List<string> list = new List<string>();

        public List<List<int>> matrix = new List<List<int>>();

        public ReadData()
        {
 
        }

        public void ReadFromFile()
        {
            list.Clear();
            string path;
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                FileStream f = File.OpenRead(path);
                StreamReader reader = new StreamReader(f);
                string str = reader.ReadLine();

                str = File.ReadLines(path).First();
                vertex = Int32.Parse(str);

                var fileText = File.ReadAllLines(path).Skip(1);

                var arrayLists = fileText.ToArray();

                

                for(var y = 0; y < arrayLists.Length; y++)
                    matrix.Add(new List<int>());

                for (var i = 0; i < arrayLists.Length; i++)
                {
                    var intArray = arrayLists[i].Split(' ');
                    foreach (var x in intArray)
                    {
                        matrix[i].Add(Int32.Parse(x));
                    }
                }

                foreach (object item in fileText)
                {
                    list.Add(item.ToString());
                }
            }
        }
    }
}
