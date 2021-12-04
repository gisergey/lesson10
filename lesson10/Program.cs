using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabricslist1;
using BuidlingLibrary;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace lesson10
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Student> students = new List<Student>();
            using (StreamReader text = new StreamReader("students.txt"))
            {
                string name;
                string group;
                while ((name = text.ReadLine()) != null)
                {
                    group = text.ReadLine();
                    students.Add(new Student(name, group));
                    students.Last().Information();
                }
            }
            bool flag = true;
            string comand;
            int counters;
            int number;
            while (flag)
            {
                Console.WriteLine("Вы можете устроить раздачу написав: розыгрышь, или завершить программу написав: выход");
                comand = Console.ReadLine();
                if (comand.Equals("розыгрышь"))
                {
                    Console.WriteLine("Введите событие");
                    string events = Console.ReadLine();
                    Console.WriteLine("Введите количество посетителей на мероприятии");
                    while(!int.TryParse(Console.ReadLine(),out counters))
                    {
                        Console.WriteLine("Вы ввели не число");
                    }
                    for(int i = 0; i < students.Count; i++)
                    {
                        Console.Write((i+1).ToString() + "  ");
                        students[i].Information();
                    }

                    List<Student> evenstudents = new List<Student>();
                    Console.WriteLine("Введите номера студентов участвующих в этом розыгрыше, когда закончите введите пустую строку");
                    string num = Console.ReadLine();

                    
                    
                    while (num != null)
                    {
                        while (!int.TryParse(num, out number) || number < 1 || number > students.Count)
                        {
                            Console.WriteLine("Ошибка ввода попробуйте еще раз");
                            num = Console.ReadLine();
                        
                        }
                        if (!evenstudents.Contains(students[number-1]))
                        {
                            evenstudents.Add(students[number-1]);
                        }
                        else
                        {
                            Console.WriteLine("Участник уже введен");
                        }
                        num = Console.ReadLine();
                        if (num == "")
                        {
                            num = null;
                        }
                    }
                    using (StreamWriter text = new StreamWriter("events.txt", true))
                    {
                        Random ran = new Random();
                        while (counters > 0)
                        {
                            int i = ran.Next(0,evenstudents.Count());
                            if (evenstudents[i].Lucky >= ran.Next(0, 4))
                            {
                                text.Write(DateTime.Now.ToString()+" ; ");
                                text.Write(events+" ; ");
                                text.WriteLine(evenstudents[i].Info());
                                evenstudents[i].Lucky = 0;
                                evenstudents.RemoveAt(i);
                                counters -= 1;
                            }
                          

                        }
                        foreach(Student st in students)
                        {
                            if (st.Lucky < 3)
                            {
                                    st.Lucky += 1;
                            }
                        }


                    }



                }
                else if (comand.Equals("выход"))
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("неопознаная команда попробуйте ввести еще раз");
                }
            }
            



            
            Excel.Application excelApp = new Excel.Application();


            if (excelApp == null)
            {
                Console.WriteLine("Excel is not installed!!");
                return;
            }

            Excel.Workbook excelBook = excelApp.Workbooks.Open(@"C:\Users\User\source\repos\lesson10\lesson10\bin\Debug\1.XLSX");
            Excel.Worksheet excelSheet = excelBook.Sheets[1];
            Excel.Range excelRange = excelSheet.UsedRange;

            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;
            Dictionary<string, string> xl1 = new Dictionary<string, string>();
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    xl1[excelRange.Cells[i, 1].Value2.ToString()] = excelRange.Cells[i, 2].Value2.ToString();
                }
            }
           
            excelApp.Quit();
            Marshal.ReleaseComObject(excelApp);
            Marshal.ReleaseComObject(excelBook);
            Marshal.ReleaseComObject(excelSheet);
            Marshal.ReleaseComObject(excelRange);

            excelApp = new Excel.Application();


            if (excelApp == null)
            {
                Console.WriteLine("Excel is not installed!!");
                return;
            }

             excelBook = excelApp.Workbooks.Open(@"C:\Users\User\source\repos\lesson10\lesson10\bin\Debug\2.XLSX");
             excelSheet = excelBook.Sheets[1];
             excelRange = excelSheet.UsedRange;

           rows = excelRange.Rows.Count;
           cols = excelRange.Columns.Count;
            Dictionary<string, string> xl2 = new Dictionary<string, string>();
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    xl2[excelRange.Cells[i, 2].Value2.ToString()] = excelRange.Cells[i, cols].Value2.ToString();
                }
            }

            excelApp.Quit();
            Marshal.ReleaseComObject(excelApp);
            Marshal.ReleaseComObject(excelBook);
            Marshal.ReleaseComObject(excelSheet);
            Marshal.ReleaseComObject(excelRange);
            excelApp = new Excel.Application();


            if (excelApp == null)
            {
                Console.WriteLine("Excel is not installed!!");
                return;
            }

            excelBook = excelApp.Workbooks.Open(@"C:\Users\User\source\repos\lesson10\lesson10\bin\Debug\3.xlsx");
            excelSheet = excelBook.Sheets[1];
            excelRange = excelSheet.UsedRange;


            List<string> kk =new List<string>();
            List<string> a = new List<string>();
            foreach(string str in xl2.Keys)
            {
                a.Add(str);
            }

            foreach (string str in a)
            {
                bool flag1 = true;
                foreach (string strin in xl1.Keys)
                {
                    if (xl2[str].Contains(strin))
                    {
                        xl2[str] = xl1[strin];
                        kk.Add(str);
                        flag1 = false;
                    }

                }
                if (flag1)
                {
                    xl2[str] = "нет";
                    kk.Add(str);
                }
            }
            
            for (int i = 1; i <= a.Count; i++)
            {
                excelRange.Cells[i, 1] = String.Format(kk[i-1], i, 1);
                excelRange.Cells[i, 2] = String.Format(xl2[kk[i-1]], i, 2);
            }

            excelApp.Quit();
            Marshal.ReleaseComObject(excelApp);
            Marshal.ReleaseComObject(excelBook);
            Marshal.ReleaseComObject(excelSheet);
            Marshal.ReleaseComObject(excelRange);








       
     

        }
    }
}
