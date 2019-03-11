using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PEA1_WindowApp
{
    class ReadData
    {
        public int vertex { get; set; }

        public ReadData()
        {
            vertex = 0;
        }

        public void ReadFromFile()
        {
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

                List<string> list = new List<string>();

                foreach (object item in fileText)
                {
                    list.Add(item.ToString());
                }

                var msg = string.Join(Environment.NewLine, list.ToArray());

                MessageBox.Show(msg);
            }
        }

    }
}