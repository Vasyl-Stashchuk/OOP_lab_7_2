using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab7_2_
{
    public class DisksCollection
    {
        ArrayList diskColl;
        public ReaderWriter readerWriter;

        public DisksCollection()
        {
            readerWriter = new ReaderWriter();
            diskColl = createList();
        }
        public void setComands()
        {
            Console.WriteLine("Додавання записiв: +");
            Console.WriteLine("Редагування записiв: E");
            Console.WriteLine("Знищення записiв: -");
            Console.WriteLine("Виведення записiв: Enter");
            Console.WriteLine("Сортування за інвентарним номером: N");
            Console.WriteLine("Сортування за датою запису: D");
            Console.WriteLine("Вихiд: Esc");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.OemPlus:
                    Console.WriteLine();
                    addNew();
                    setComands();
                    break;

                case ConsoleKey.E:
                    Console.WriteLine();
                    edit();
                    setComands();
                    break;

                case ConsoleKey.OemMinus:
                    Console.WriteLine();
                    delete();
                    setComands();
                    break;

                case ConsoleKey.Enter:
                    Console.WriteLine();
                    showList();
                    setComands();
                    break;

                case ConsoleKey.N:
                    Console.WriteLine();
                    showSortByNumber();
                    setComands();
                    break;

                case ConsoleKey.D:
                    Console.WriteLine();
                    showSortByDate();
                    setComands();
                    break;

                case ConsoleKey.Escape:
                    return;
            }
        }
        public Disk parseInfo(string strInfo)
        {
            string[] words = new string[6];
            words = strInfo.Split(',');
            Disk disk = new Disk(int.Parse(words[0]),words[1], int.Parse(words[2]), words[3], DateTime.Parse(words[4]));
            return disk;
        }
        public ArrayList createList()
        {
            ArrayList arrayList = new ArrayList();
            List<string> strs = readerWriter.readDataFromFile();
            int strCount = 0;
            foreach (string s in strs)
            {
                arrayList.Add(parseInfo(s));
                strCount++;
            }
            return arrayList;
        }

        public void showList()
        {
            Console.WriteLine("{0, -15} {1, -17} {2, -12} {3, -5} {4}", "Інвент. номер","Назва альбому","Об'єм діску","Тип", "Дата запису");
            foreach (Disk d in diskColl)
                Console.WriteLine("{0, -15} {1, -17} {2, -12} {3, -5} {4}", d.Number, d.Name, d.Space, d.Type, d.Date.Date.ToString("dd/MM/yyyy"));
        }

        public void addNew()
        {
            Console.WriteLine("Введiть данi через кому:");
            try
            {
                string strInfo = Console.ReadLine();
                Disk disk = parseInfo(strInfo);
                diskColl.Add(disk);
                readerWriter.saveList(diskColl);
            }
            catch (FormatException exp)
            {
                Console.WriteLine(exp.Message);
            }        
        }

        public void delete()
        {
            Console.WriteLine("Введіть інвентарний номер: ");
            try
            {
                int count = 0;
                int num = int.Parse(Console.ReadLine());
                foreach (Disk d in diskColl)
                {
                    if (d.Number == num)
                    {
                        d.showInfo();
                        Console.WriteLine("Видалити? (Y/N)");
                        var key = Console.ReadKey().Key;
                        if (key == ConsoleKey.Y)
                        {
                            diskColl.Remove(d);
                            Console.WriteLine("Видалено успішно!");
                            break;
                        }
                    }
                    else
                        count++;
                }
                if (count == diskColl.Count)
                    Console.WriteLine("Такого диску немає в колекції дисків8");
                else
                    readerWriter.saveList(diskColl);
            }
            catch (FormatException exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        public void edit()
        {
            Console.WriteLine("Введіть інвентарний номер: ");
            try
            {
                int count = 0;
                int num = int.Parse(Console.ReadLine());
                foreach (Disk d in diskColl)
                {
                    if (d.Number == num)
                    {
                        d.showInfo();
                        Console.WriteLine("Введіть нову інформацію через кому");
                        string strInfo = Console.ReadLine();
                        Disk editedDisk = parseInfo(strInfo);
                        editedDisk.showInfo();
                        Console.WriteLine("Зберегти зміни(Y/N)");
                        var key = Console.ReadKey().Key;
                        if (key == ConsoleKey.Y)
                        {
                            diskColl.Remove(d);
                            diskColl.Add(editedDisk);
                            break;
                        }
                    }
                    else
                        count++;
                }
                if (count == diskColl.Count)
                    Console.WriteLine("Такого диску немає в колекції дисків8");
                else
                    readerWriter.saveList(diskColl);
            }
            catch (FormatException exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        public void showSortByNumber()
        {
            diskColl.Sort(new Disk.SortByNumber());
            showList();
        }
        public void showSortByDate()
        {
            diskColl.Sort(new Disk.SortByDate());
            showList();
        }
    }
}
