using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Functions_1
{
    class Program
    {
       static public void AddDossier(ref string[] FIO, ref string[] position)
        {
            Console.WriteLine("Введите фио сотрудника, которого хотите добавить");
            string fio = Console.ReadLine();
            Console.WriteLine("Введите должность сотрудника, которого хотите добавить");
            string pos = Console.ReadLine();

            //изменение размера массива через ссылку на другой массив
            string[] FIO_new = new string[FIO.Length+1] ;
            for (int i = 0; i < FIO.Length; i++)
                FIO_new[i] = FIO[i];          
            string[] position_new = new string[position.Length + 1];
            for (int i = 0; i < position.Length; i++)
                position_new[i] = position[i];
            FIO = FIO_new;
            FIO[FIO.Length-1] = fio;
            position = position_new;
            position[position.Length-1] = pos;

        }

        static public void CheckDossier( string[] FIO,  string[] position)
        {
            for (int i = 0; i < FIO.Length; i++)
                Console.WriteLine($"Досье номер {i}\t ФИО: {FIO[i]}, должность: {position[i]}");         
        }

        static public void DeleteDossier(ref string[] FIO, ref string[] position)
        {

            //изменение размера массива через ссылку на другой массив
            string[] FIO_new = new string[FIO.Length - 1];
            for (int i = 0; i < FIO_new.Length; i++)
                FIO_new[i] = FIO[i];
            FIO = FIO_new;
            string[] position_new = new string[position.Length - 1];
            for (int i = 0; i < position_new.Length; i++)
                position_new[i] = position[i];
            position = position_new;
        }
        static public void FindDossier(ref string[] FIO, ref string[] position)
        {
            Console.WriteLine("Введите фамилию человека, которого хотите найти ");
            string surname = Console.ReadLine();
            Regex regex = new Regex($@"\s*{surname}\s*");//регулярное выражение

            for (int i = 0; i < FIO.Length; i++)
            {              
                if (regex.IsMatch(surname)) //соответствие регулярному выражению              
                    Console.WriteLine($"ФИО: {FIO[i]}, должность: {position[i]}");                         
            }
         
        }
        static void Main(string[] args)
        {
            string[] FIO = new string[] { };
            string[] position = new string[] { };
    

           
            int caseSwitch = -1; 
            while (caseSwitch != 0)
            {
                Console.WriteLine("Выберите номер действия:\n" +
                    "1 - добавить досье\n" +
                    "2 - вывести все досье\n" +
                    "3 - удалить досье\n" +
                    "4 - поиск по фамилии\n" +
                    "0 - выход\n");
                caseSwitch = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (caseSwitch)
                {
                    case 1:
                        AddDossier(ref FIO, ref position);
                        break;
                    case 2:
                        CheckDossier(FIO, position);
                        break;
                    case 3:
                        DeleteDossier(ref FIO,ref position);
                        break;
                    case 4:
                        FindDossier(ref FIO, ref position);
                        break;
                    case 0:
                        return;
                     
                }
            }
        }
    }
}
