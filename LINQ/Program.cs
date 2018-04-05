using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public string team { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
        }
        static List<Student> students = new List<Student>
        {
           new Student {team="a",First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
           new Student {team="a",First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
           new Student {team="a",First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
           new Student {team="b",First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
           new Student {team="b",First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
           new Student {team="b",First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
           new Student {team="b",First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
           new Student {team="c",First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
           new Student {team="c",First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
           new Student {team="c",First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
           new Student {team="d",First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
           new Student {team="e",First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91} }
        };
        static void Main(string[] args)
        {
            var endsInA = from s in students
                          where s.Last.EndsWith("a")
                          select s;
            foreach(var student in endsInA)
            {
                Console.WriteLine(student.First + " " + student.Last);
            }
            Console.ReadLine();

            var groups = from s in students
                         group s by s.team into studentGroup
                         select new
                         {
                             Team = studentGroup.Key,
                             IdSum = studentGroup.Sum(x => x.ID),
                             ScoreSum = studentGroup.Sum(x=> x.Scores.Sum())
                         };
            foreach(var g in groups)
            {
                Console.WriteLine("Team: " + g.Team + " ID SUM: " + g.IdSum+ " ScoreSum: "+ g.ScoreSum);
            }
            Console.ReadLine();


            using (MssqlDataContext dc = new MssqlDataContext())
            {
                var customers = from c in dc.Customers
                                where c.LastName=="Vessa" select c;

                foreach(var c in customers)
                {
                    Console.WriteLine("Name: " + c.FirstName + " " + c.LastName);
                    c.FirstName = "Bob";

                }
                dc.SubmitChanges();
            }
            Console.ReadLine();
        }
    }
}
