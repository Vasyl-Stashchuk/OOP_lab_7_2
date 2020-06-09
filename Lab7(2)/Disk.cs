using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_2_
{
    public class Disk
    {
        private int number;
        private string albomName;
        private int diskSpace;
        private string type;
        private DateTime recordDate;

        public int Number { get { return number; } set { number = value; } }
        public string Name { get { return albomName; } set { albomName = value; } }
        public int Space { get { return diskSpace; } set { diskSpace = value; } }
        public string Type { get { return type; } set { type = value; } }

        public DateTime Date { get { return recordDate; } set { recordDate = value; } }

        public Disk(int numb, string aName, int space, string type, DateTime date)
        {
            number = numb;
            albomName = aName;
            diskSpace = space;
            this.type = type;
            recordDate = date;
        }
        virtual public void showInfo()
        {
            Console.WriteLine("Номер: " + number);
            Console.WriteLine("Альбом: " + albomName);
            Console.WriteLine("Об'єм диску: " + diskSpace);
            Console.WriteLine("Тип: " + type);
            Console.WriteLine("Дата запису: " + recordDate.Date.ToString("dd/MM/yyyy"));
        }
        public class SortByNumber : IComparer
        {
            public int Compare(object d1, object d2)
            {
                Disk disk1 = (Disk)d1;
                Disk disk2 = (Disk)d2;
                if (disk1.number > disk2.number) return 1;
                if (disk1.number < disk2.number) return -1;
                return 0;
            }
        }

        public class SortByDate : IComparer
        {
            public int Compare(object d1, object d2)
            {
                Disk disk1 = (Disk)d1;
                Disk disk2 = (Disk)d2;
                if (disk1.recordDate > disk2.recordDate) return 1;
                if (disk1.recordDate < disk2.recordDate) return -1;
                return 0;
            }
        }
    }
}
