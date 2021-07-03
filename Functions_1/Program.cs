using System;
using System.Text.RegularExpressions;

namespace Functions_1
{
    class Program
    {
       static public void AddDossier(ref string[] fullNamesArray, ref string[] positionEmployeesArray)
        {
            Console.WriteLine("Введите фио сотрудника, которого хотите добавить");
            string inputFullNamesArray = Console.ReadLine();
            Regex regex = new Regex(@"^[А-яЁёA-z]* [А-яЁёA-z]* [А-яЁёA-z]*$");
            Match match = regex.Match(inputFullNamesArray);
            while (!match.Success)
            {
                Console.WriteLine("Некорректное ФИО! Введите еще раз");
                inputFullNamesArray=Console.ReadLine();
                match = regex.Match(inputFullNamesArray);
            }

            Console.WriteLine("Введите должность сотрудника, которого хотите добавить");
            string inputPositionEmployeesArray = Console.ReadLine();
            regex = new Regex(@"^[А-яЁёA-z][А-яЁёA-z]*$");
            match = regex.Match(inputPositionEmployeesArray);
            while (!match.Success)
            {
                Console.WriteLine("Некорректная должность! Введите еще раз");
                inputPositionEmployeesArray = Console.ReadLine();
                match = regex.Match(inputPositionEmployeesArray);
            }
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
            Console.WriteLine("Досье добавлено!\n");
        }

        static public void CheckDossier( string[] fullNamesArray,  string[] positionEmployeesArray)
        {
            if (fullNamesArray.Length==0)
            { Console.WriteLine("Нет ни одного досье!\n"); }
            else for (int i = 0; i < fullNamesArray.Length; i++)
                Console.WriteLine($"Досье номер {i}\t ФИО: {fullNamesArray[i]}, должность: {positionEmployeesArray[i]}\n");
        }

        static public void DeleteDossier(ref string[] fullNamesArray, ref string[] positionEmployeesArray)
        {
            if (fullNamesArray.Length == 0)
            { Console.WriteLine("Нет досье для удаления!\n"); }
            else
            {
                Console.WriteLine("Введите фамилию человека, которого хотите удалить");
                string surname = Console.ReadLine();
                Regex regex = new Regex($@"{surname}+\s");
                int count = 0;

                for (int i = 0; i < fullNamesArray.Length; i++)
                {
                    if (regex.IsMatch(fullNamesArray[i]))
                    {
                            count++;                                            
                            Console.WriteLine($"Досье под номером {i} удалено!\n");
                            string[] newFullNamesArray = new string[fullNamesArray.Length - 1];
                            for (int j = 0; j < i; j++)
                                newFullNamesArray[j] = fullNamesArray[j];
                            for (int j = i+1; j < fullNamesArray.Length; j++)
                                newFullNamesArray[j-1] = fullNamesArray[j];
                            fullNamesArray = newFullNamesArray;

                            string[] positionEmployeesArrayNew = new string[positionEmployeesArray.Length - 1];
                            for (int j = 0; j < i; j++)
                                positionEmployeesArrayNew[j] = positionEmployeesArray[j];
                            for (int j = i+1; j < positionEmployeesArray.Length ; j++)
                                positionEmployeesArrayNew[j-1] = positionEmployeesArray[j];
                            positionEmployeesArray = positionEmployeesArrayNew;
                            break;

                        

                    }
                }
                if (count == 0)
                    Console.WriteLine("Человек с такой фамилией не найден!\n");

            }

        }

        static public void FindDossier(ref string[] fullNamesArray, ref string[] positionEmployeesArray)
        {
            Console.WriteLine("Введите фамилию человека, которого хотите найти ");
            string surname = Console.ReadLine();
            Regex regex = new Regex($@"{surname}+\s");
            int count = 0;

            for (int i = 0; i < fullNamesArray.Length; i++)
            {
                if (regex.IsMatch(fullNamesArray[i]))
                {
                    Console.WriteLine($"ФИО: {fullNamesArray[i]}, должность: {positionEmployeesArray[i]}\n");
                    count++;
                }
            }
            if(count == 0)
                Console.WriteLine("Человек с такой фамилией не найден!\n");
        }

        static void Main(string[] args)
        {
            string[] fullNamesArray = new string[] { };
            string[] positionEmployeesArray = new string[] { };
            int caseSwitch;

            while (true)
            {
                Console.WriteLine("Выберите номер действия:\n" +
                    "1 - добавить досье\n" +
                    "2 - вывести все досье\n" +
                    "3 - удалить досье\n" +
                    "4 - поиск по фамилии\n" +
                    "5 - очистить консоль\n" +
                    "0 - выход\n");

                while (!int.TryParse(Console.ReadLine(), out caseSwitch) || caseSwitch < 0 || caseSwitch > 5)
                    Console.WriteLine("Неудовлетворяющий ключ, введите еще раз");
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
                    case 5:
                        Console.Clear();
                        break;
                    case 0:
                        return;
                }

            }
        }
    }
}

