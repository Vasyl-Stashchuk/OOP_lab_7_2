using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_2_
{
    public class ReaderWriter
    {
        public List<string> readDataFromFile()
        {
            List<string> lines = new List<string>();
            string line;
            StreamReader file = new StreamReader("disk.txt", Encoding.GetEncoding(1251));
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }

            file.Close();
            return lines;
        }

        public void saveList(ArrayList diskCol)
        {
            using (StreamWriter save = new StreamWriter("disk.txt", false, Encoding.GetEncoding(1251)))
            {
                string str = null;

                foreach (Disk disk in diskCol)
                {
                    str = disk.Number +","+ disk.Name + "," + disk.Space + "," + disk.Type + "," + disk.Date.ToString("dd/MM/yyyy");
                    save.WriteLine(str);
                }
            }
        }
    }
}
