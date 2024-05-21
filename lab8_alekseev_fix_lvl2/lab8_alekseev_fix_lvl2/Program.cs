﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7_alekseev_fix_lvl2
{
    class Person
    {
        private string _name;
        protected int _markMath;
        protected int _markPhys;
        protected int _markRus;
        private double _avgMark;
        private bool _isPastExm;

        public Person(string name, int markmat, int markphys, int markrus)
        {
            _name = name;
            _markMath = markmat;
            _markPhys = markphys;
            _markRus = markrus;
            _avgMark = (_markMath + _markPhys + _markRus) / 3.0;
            _isPastExm = (_markMath >= 3 && _markPhys >= 3 && _markRus >= 3);

        }

        public string Name => _name;      
        public double AvgMark => _avgMark;
        public bool IsPastExm => _isPastExm;

        public virtual void Print()
        {
            Console.WriteLine($"{Name,15} | {Math.Round(AvgMark),10} | ");
        }

    }

    class Student : Person
    {
        protected static int _nextid = 1;
        private string _id;
        public Student(string name, int markmat, int markphys, int markrus) : base(name, markmat, markphys, markrus)
        {
            _id = $"{_nextid}";
            _nextid++;
        }

        public string Id => _id;

        public override void Print()
        {
            Console.WriteLine($"{Name,15} | {Math.Round(AvgMark),10} | ID: {_id}");
        }
    }


    class Program
    {
        static void Main()
        {
            Student[] students = new Student[]
            {
                new Student("Иван", 3, 5, 5 ),
                new Student("Сергей", 3, 3, 3),
                new Student("Колян", 3, 4, 2),
                new Student("Сеня", 3, 4, 4),
                new Student("ВВП", 5, 5, 5),
                new Student("Ждан", 3, 4, 4)

            };

            var passedStudent = students.Where(s => s.IsPastExm).ToArray();


            //InsertionSort(passedStudent);

            var sortedStudent = passedStudent.OrderByDescending(s => s.AvgMark).ToArray();

            Console.WriteLine($"{"Имя",15}  {"Средняя оценка",10}  {"ID",5}");


            foreach (var student in sortedStudent)
            {
                student.Print();
            }
            Console.ReadKey();
        }

        //static void InsertionSort(Person[] per)
        //{
        //    for(int i = 1; i < per.Length; i++)
        //    {
        //        Person key = per[i];
        //        int j = i - 1; 

        //        while (j >= 0 && per[j].AvgMark < key.AvgMark)
        //        {
        //            per[j + 1] = per[j];
        //            j = j - 1;
        //        }
        //        per[j + 1] = key;
        //    }
        //}
    }
}