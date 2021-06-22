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
       static public void AddDossier(ref string[] fullNamesArray, ref string[] positionEmployeesArray)
        {
            Console.WriteLine("Введите фио сотрудника, которого хотите добавить");
            string inputFullNamesArray = Console.ReadLine();
            Console.WriteLine("Введите должность сотрудника, которого хотите добавить");
            string inputPositionEmployeesArray = Console.ReadLine();
            string[] newFullNamesArray = new string[fullNamesArray.Length+1] ;
           
            for (int i = 0; i < fullNamesArray.Length; i++)
                newFullNamesArray[i] = fullNamesArray[i];          
            string[] newPositionEmployeesArray = new string[positionEmployeesArray.Length + 1];
            
            for (int i = 0; i < positionEmployeesArray.Length; i++)
                newPositionEmployeesArray[i] = positionEmployeesArray[i];
                       fullNamesArray = newFullNamesArray;
            fullNamesArray[fullNamesArray.Length-1] = inputFullNamesArray;
            positionEmployeesArray = newPositionEmployeesArray;
            positionEmployeesArray[positionEmployeesArray.Length-1] = inputPositionEmployeesArray;

        }

        static public void CheckDossier( string[] fullNamesArray,  string[] positionEmployeesArray)
        {
            for (int i = 0; i < fullNamesArray.Length; i++)
                Console.WriteLine($"Досье номер {i}\t ФИО: {fullNamesArray[i]}, должность: {positionEmployeesArray[i]}");         
        }

        static public void DeleteDossier(ref string[] fullNamesArray, ref string[] positionEmployeesArray)
        {         
            string[] newFullNamesArray = new string[fullNamesArray.Length - 1];
            for (int i = 0; i < newFullNamesArray.Length; i++)
                newFullNamesArray[i] = fullNamesArray[i];
            fullNamesArray = newFullNamesArray;
            string[] position_new = new string[positionEmployeesArray.Length - 1];
            
            for (int i = 0; i < position_new.Length; i++)
                position_new[i] = positionEmployeesArray[i];
            positionEmployeesArray = position_new;
        }

        static public void FindDossier(ref string[] fullNamesArray, ref string[] positionEmployeesArray)
        {
            Console.WriteLine("Введите фамилию человека, которого хотите найти ");
            string surname = Console.ReadLine();
            Regex regex = new Regex($@"\s*{surname}\s*");

            for (int i = 0; i < fullNamesArray.Length; i++)
            {              
                if (regex.IsMatch(surname))              
                    Console.WriteLine($"ФИО: {fullNamesArray[i]}, должность: {positionEmployeesArray[i]}");                         
            }
         
        }

        static void Main(string[] args)
        {
            string[] fullNamesArray = new string[] { };
            string[] positionEmployeesArray = new string[] { }; 
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
                        AddDossier(ref fullNamesArray, ref positionEmployeesArray);
                        break;
                    case 2:
                        CheckDossier(fullNamesArray, positionEmployeesArray);
                        break;
                    case 3:
                        DeleteDossier(ref fullNamesArray, ref positionEmployeesArray);
                        break;
                    case 4:
                        FindDossier(ref fullNamesArray, ref positionEmployeesArray);
                        break;
                    case 0:
                        return;
                     
                }
            }
        }
    }
}
