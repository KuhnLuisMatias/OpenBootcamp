using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenBootcamp_LINQ   
{
    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars = {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Sean León"
            };

            var carList = from car in cars select car;

            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

        }
        static public void LinqNumbers()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var processedNumberList = numbers.
                                            Select(num => num * 3)
                                            .Where(num => num != 9)
                                            .OrderBy(num => num);
        }
        static public void SearchExamples()
        {
            List<string> textList = new List<string>
                    {
                        "a",
                        "bx",
                        "c",
                        "d",
                        "e",
                        "cj",
                        "f",
                        "c"
                    };

            var first = textList.First(text => text.Equals("c"));
            var jText = textList.First(text => text.Contains("j"));
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z"));
            var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z"));

            var uniqueTexts = textList.Single();
            var uniqueOrDefaultTexts = textList.SingleOrDefault();
            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6 };

            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers);
        }
        static public void MultipleSelects()
        {
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3"
            };

            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(','));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id=1,
                            Name="Matin",
                            Email="matin@imaginagroup.com",
                            Salary= 3000M
                        },
                        new Employee{
                            Id=5,
                            Name = "Maria",
                            Email = "maria@imaginagroup.com",
                            Salary = 1500M
                        },
                        new Employee
                        {
                            Id=6,
                            Name="Marta",
                            Email="marta@imaginagroup.com",
                            Salary = 4000M
                        }
                    }
                }
            };

            var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees);
            bool hasEnterprises = enterprises.Any();
            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());
            bool hasEmployeeWithSalaryMoraThan1000 = enterprises.Any(enterprise => enterprise.Employees.Any(employee => employee.Salary > 1000));
        }
        static public void LinqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };

            var commonResult2 = firstList.Join(
                secondList,
                element => element,
                secondElement => secondElement,
                (element, secondElement) => new { element, secondElement });

            var rightOuterJoin = from secondElement in secondList
                                 join element in firstList
                                 on secondElement equals element
                                 into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where secondElement != temporalElement
                                 select new { Element = secondElement };

            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            var leftOuterJoin2 = from element in firstList
                                 from secondElement in secondList.Where(s=> s == element).DefaultIfEmpty()
                                 select new { Element = secondElement };

            var unionList = leftOuterJoin.Union(rightOuterJoin);
        }

        static public void SkipTakeLinq()
        {
            var myList = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var skipTwoFirstValues = myList.Skip(2);
            //var skipLastTwoValues = myList.SkipLast(2);
            var skipWhile = myList.SkipWhile(num => num < 4);
            var takeFirstTwoValues = myList.Take(2);
            //var takeLastTwoValues = myList.TakeLast(2);
            var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4);
        }
    }
}