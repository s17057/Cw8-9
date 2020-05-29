using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqConsoleApp
{
    public class LinqSamples
    {
        public static IEnumerable<Emp> Emps { get; set; }
        public static IEnumerable<Dept> Depts { get; set; }

        public LinqSamples()
        {
            LoadData();
        }

        public void LoadData()
        {
            var empsCol = new List<Emp>();
            var deptsCol = new List<Dept>();

            #region Load depts
            var d1 = new Dept
            {
                Deptno = 1,
                Dname = "Research",
                Loc = "Warsaw"
            };

            var d2 = new Dept
            {
                Deptno = 2,
                Dname = "Human Resources",
                Loc = "New York"
            };

            var d3 = new Dept
            {
                Deptno = 3,
                Dname = "IT",
                Loc = "Los Angeles"
            };

            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            Depts = deptsCol;
            #endregion
            #region Load emps
            var e1 = new Emp
            {
                Deptno = 1,
                Empno = 1,
                Ename = "Jan Kowalski",
                HireDate = DateTime.Now.AddMonths(-5),
                Job = "Backend programmer",
                Mgr = null,
                Salary = 2000
            };

            var e2 = new Emp
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Anna Malewska",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "Frontend programmer",
                Mgr = e1,
                Salary = 4000
            };

            var e3 = new Emp
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Marcin Korewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 5000
            };

            var e4 = new Emp
            {
                Deptno = 2,
                Empno = 3,
                Ename = "Paweł Latowski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Frontend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e5 = new Emp
            {
                Deptno = 2,
                Empno = 4,
                Ename = "Michał Kowalski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e6 = new Emp
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Katarzyna Malewska",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Manager",
                Mgr = null,
                Salary = 8000
            };

            var e7 = new Emp
            {
                Deptno = null,
                Empno = 6,
                Ename = "Andrzej Kwiatkowski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "System administrator",
                Mgr = null,
                Salary = 7500
            };

            var e8 = new Emp
            {
                Deptno = 2,
                Empno = 7,
                Ename = "Marcin Polewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Mobile developer",
                Mgr = null,
                Salary = 4000
            };

            var e9 = new Emp
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Władysław Torzewski",
                HireDate = DateTime.Now.AddMonths(-9),
                Job = "CTO",
                Mgr = null,
                Salary = 12000
            };

            var e10 = new Emp
            {
                Deptno = 2,
                Empno = 9,
                Ename = "Andrzej Dalewski",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Database administrator",
                Mgr = null,
                Salary = 9000
            };

            empsCol.Add(e1);
            empsCol.Add(e2);
            empsCol.Add(e3);
            empsCol.Add(e4);
            empsCol.Add(e5);
            empsCol.Add(e6);
            empsCol.Add(e7);
            empsCol.Add(e8);
            empsCol.Add(e9);
            empsCol.Add(e10);
            Emps = empsCol;

            #endregion

        }


        /*
            Celem ćwiczenia jest uzupełnienie poniższych metod.
         *  Każda metoda powinna zawierać kod C#, który z pomocą LINQ'a będzie realizować
         *  zapytania opisane za pomocą SQL'a.
         *  Rezultat zapytania powinien zostać wyświetlony za pomocą kontrolki DataGrid.
         *  W tym celu końcowy wynik należy rzutować do Listy (metoda ToList()).
         *  Jeśli dane zapytanie zwraca pojedynczy wynik możemy je wyświetlić w kontrolce
         *  TextBox WynikTextBox.
        */

        
        public void Przyklad1()
        {
            
            //1. Query syntax (SQL)
            var res = from emp in Emps
                      where emp.Job == "Backend programmer"
                      select new
                      {
                          Empno = emp.Empno,
                          Ename = emp.Ename,
                          Job = emp.Job,
                          Salary = emp.Salary,
                          HireDate = emp.HireDate,
                          Deptno = emp.Deptno,
                          Mgr = emp.Mgr
                      };


            //2. Lambda and Extension methods
            var res2 = Emps.Where(emp => 
                emp.Job.Equals("Backend programmer")).Select(emp => new
                {
                    Empno = emp.Empno,
                    Ename = emp.Ename,
                    Job = emp.Job,
                    Salary = emp.Salary,
                    HireDate = emp.HireDate,
                    Deptno = emp.Deptno,
                    Mgr = emp.Mgr
                }).ToList();
            foreach(var emp in res2)
            {
                Console.WriteLine(emp);
            }


        }

        public void Przyklad2()
        {
            var res = Emps.Where(emp =>
                emp.Job.Equals("Backend programmer") && emp.Salary > 1000).OrderByDescending(emp => emp.Ename).Select(emp => new
                {
                    Empno = emp.Empno,
                    Ename = emp.Ename,
                    Job = emp.Job,
                    Salary = emp.Salary,
                    HireDate = emp.HireDate,
                    Deptno = emp.Deptno,
                    Mgr = emp.Mgr
                }).ToList();
            foreach (var emp in res)
            {
                Console.WriteLine(emp);
            }
        }

            public void Przyklad3()
        {
            var res = Emps.Max(emp => emp.Salary);
            Console.WriteLine("Najwyzsza stawka: " + res);
        }

       
        public void Przyklad4()
        {
            var res = Emps.Where(emp =>
                emp.Salary.Equals(Emps.Max(emp => emp.Salary))).Select(emp => new
                {
                    Empno = emp.Empno,
                    Ename = emp.Ename,
                    Job = emp.Job,
                    Salary = emp.Salary,
                    HireDate = emp.HireDate,
                    Deptno = emp.Deptno,
                    Mgr = emp.Mgr
                }).ToList();
            Console.WriteLine("Pracownicy z najwyższą stawką:");
            foreach (var emp in res)
            {
                Console.WriteLine(emp);
            }
        }

        public void Przyklad5()
        {
            var res = Emps.Select(emp => new
                {
                    Nazwisko = emp.Ename,
                    Praca = emp.Job
                }).ToList();
            foreach (var emp in res)
            {
                Console.WriteLine(emp);
            }

        }

        
        public void Przyklad6()
        {
            var res = Emps.Join(Depts, emp => emp.Deptno, dept => dept.Deptno, (emp, dept) => new
            {
                emp.Ename,
                emp.Job,
                dept.Dname
            });
            foreach (var emp in res)
            {
                Console.WriteLine(emp);
            }
        }

        
        public void Przyklad7()
        {
            var res = Emps.GroupBy(emp => emp.Job).Select(group => new
            {
                Praca = group.Key,
                Count = group.Count()
            }).ToList();
            foreach (var emp in res)
            {
                Console.WriteLine(emp);
            }
        }

               public void Przyklad8()
        {
            var param = "Backend programmer";
            var res = Emps.IsWorkingAs(emp => emp.Job.Equals(param));
            Console.WriteLine("Czy pracuje u nas " + param);
            Console.WriteLine(res);
        }

        public void Przyklad9()
        {
            var res = Emps.Where(emp => emp.Job.Equals("Backend programmer")).OrderByDescending(emp => emp.HireDate).FirstOrDefault();
            Console.WriteLine(res);

        }

        
        public void Przyklad10()
        {
            var res = Emps.Union(new List<Emp> { new Emp
                {
                    Ename = "Brak warotści",
                    Job = null,
                    HireDate = null
                }
            }).Select(emp => new
            {
                emp.Ename,
                emp.Job,
                emp.HireDate

            }).ToList();
            foreach (var emp in res)
            {
                Console.WriteLine(emp);
            }
        }

      
        public void Przyklad11()
        {
            var res = Emps.Aggregate((emp1, emp2) => emp1.Salary > emp2.Salary ? emp1 : emp2);
            Console.WriteLine(res);
        }

        public void Przyklad12()
        {
            var res = Emps.SelectMany(emp => Depts.Select(dept => new
            {
                emp.Ename,
                emp.Job,
                dept.Deptno,
                dept.Dname
            })).ToList();
            foreach (var emp in res)
            {
                Console.WriteLine(emp);
            }
        }
    }
}
