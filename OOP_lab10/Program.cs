using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace OOP_lab10
{
    class Program
    {
        class Student
        {
            public string Name { get; set; }
            public int Course { get; set; }
            public string Speciality { get; set; }
            public Student(string name, int course, string speciality)
            {
                Name = name;
                Course = course;
                Speciality = speciality;
            }
            public override string ToString()
            {
                return "Name: " + Name + "\tCourse: " + Course + "\tSpeciality: " + Speciality;
            }
        }
        abstract class Car
        {
            public int YearOfCreation { get; set; }
            public string CountryOfCreation { get; set; }
            public int Speed { get; set; }

        }
        class Transformer : Car
        {
            public string Name { get; set; }
            public int NumberOfGuns { get; set; }
            public bool IsPreparedForBattle { get; set; }
            public Transformer (int yearofcreation, string countryofcreation, int speed, string name, int numberofguns, bool ispreparedforbattle)
            {
                YearOfCreation = yearofcreation;
                CountryOfCreation = countryofcreation;
                Speed = speed;
                Name = name;
                NumberOfGuns = numberofguns;
                IsPreparedForBattle = ispreparedforbattle;
            }
            public override string ToString()
            {
                return "Name:  " + Name+ "\nYear of creation: " + YearOfCreation + "\nContry in which transformer was made: " + CountryOfCreation + "\nNumber of guns: " + NumberOfGuns;
            }
        }
        static void Main(string[] args)
        {
            //1 задание
            ArrayList GCollection = new ArrayList(); //a. заполняем коллецию 5 случайными целыми числами
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                GCollection.Add(random.Next(40, 99));
            }

            GCollection.Add("Строковый тип — тип данных, значениями которого является произвольная последовательность символов алфавита."); //b. добавляем строку

            Student student1 = new Student("Ангелина Драгуть", 2, "ДЭиВИ"); //c. добавляем объект типа Student
            GCollection.Add(student1);

            GCollection.RemoveAt(2); //d. удаляем заданный элемент

            Console.WriteLine("Коллекция: "); //e. выводим коллекцию на консоль
            foreach (object obj in GCollection)
            {
                if (obj is Student)
                {
                    Console.WriteLine(obj.ToString());
                }
                else
                    Console.WriteLine(obj);
            }

            Console.WriteLine($"Количество элементов в коллекции ArrayList: {GCollection.Count}"); //e. выводим количество элементов в коллекции

            Console.WriteLine($"\nСодержится ли в коллекции объект типа Student: {GCollection.Contains(student1)}"); //f. выполняем поиск
            Console.WriteLine($"Содержится ли в коллекции число 26: {GCollection.Contains(50)}");

            //2 задание
            HashSet<long> FirstCollection = new HashSet<long>();
            for (long i = 0; i < 20; i++)
            {
                FirstCollection.Add(i);
            }

            Console.WriteLine("Первая коллекция: ");
            foreach (long i in FirstCollection)
            {
                Console.WriteLine(i);
            }
            bool IsOdd(long i)
            {
                return ((i % 2) == 1);
            }
            FirstCollection.RemoveWhere(IsOdd); //удаляем нечетные числа
           
            Console.WriteLine("\nПервая коллекция после удаления: ");
            foreach (long i in FirstCollection)
            {
                Console.Write(i + " ");
            }
            FirstCollection.Add(5);

            LinkedList<long> SecondCollection = new LinkedList<long>(); //инициализируем вторую коллекцию
            foreach (long i in FirstCollection) //заполняем ее данными из первой коллекции
            {
                SecondCollection.AddLast(i);
            }
            Console.WriteLine("\nВторая коллекция: ");
            foreach (long i in SecondCollection)
            {
                Console.WriteLine(i); 
            }
            Console.WriteLine($"\nСодержится ли во второй коллекции 0: {SecondCollection.Contains(0)}");
            Console.WriteLine($"Содержится ли во второй коллекции 5: {SecondCollection.Contains(5)}");
            //3 задание
            Transformer transformer1 = new Transformer(1976, "Japan", 200, "Heroku", 4, true);
            Transformer transformer2 = new Transformer(1977, "USA", 300, "Jim", 3, true);
            Transformer transformer3 = new Transformer(1978, "Vietnam", 400, "Hauseo", 2, false);
            Transformer transformer4 = new Transformer(1979, "Italy", 500, "Alberto", 1, false);
            Transformer transformer5 = new Transformer(1980, "Belarus", 600, "Ivan", 500, true);
            HashSet<Transformer> TransformerSet = new HashSet<Transformer>();
            TransformerSet.Add(transformer1);
            TransformerSet.Add(transformer2);
            TransformerSet.Add(transformer3);
            TransformerSet.Add(transformer4);
            TransformerSet.Add(transformer5);
            Console.WriteLine("\nКоллекция HashSet с типом Transformer: \n");
            foreach (Transformer i in TransformerSet)
            {
                Console.WriteLine(i.ToString());
            }

            TransformerSet.Remove(transformer4);

            LinkedList<Transformer> TransformerLinkedList = new LinkedList<Transformer>();
            foreach (Transformer i in TransformerSet)
            {
                TransformerLinkedList.AddFirst(i);
            }
            Console.WriteLine("\nКоллекция LinkedList с типом Transformer: \n");
            foreach (Transformer i in TransformerLinkedList)
            {
                Console.Write(i.ToString());
            }
            Console.WriteLine($"\nПроверяем на наличие transformer3: {TransformerLinkedList.Contains(transformer3)}");

            //задание 4
            ObservableCollection<Transformer> OCTrasformer = new ObservableCollection<Transformer>();
            OCTrasformer.CollectionChanged += CollectionChanged;
            OCTrasformer.Add(transformer1);
            OCTrasformer.Add(transformer2);
            OCTrasformer.Add(transformer3);
            OCTrasformer.Add(transformer4);
        
            OCTrasformer.RemoveAt(3);

            void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    Transformer addTransformer = e.NewItems[0] as Transformer;
                    Console.WriteLine($"Добавлен новый объект: {addTransformer.ToString()}\n");
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    Transformer removeTransformer = e.OldItems[0] as Transformer;
                    Console.WriteLine($"Удален объект: {removeTransformer.Name}");
                }
            }

            Console.ReadKey();
        }
    }
}
