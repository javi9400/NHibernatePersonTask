using ExampleNhibernate.Entities;
using ExampleNhibernate.Services;
using ExampleNhibernate.SessionFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleNhibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionStringName = "DbConnection";
            var sessionFactory = SessionFactoryBuilder.BuildSessionFactory(connectionStringName, true, true);
            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var person1 = new Person
                    {
                        Id=1,
                        Name = "Shimmy"
                    };

                    var person2 = new Person
                    {
                        Id = 2,
                        Name = "Tiger"
                    };

                    var person3 = new Person
                    {
                        Id = 3,
                        Name = "Javier"
                    };

                    var task1 = new Entities.Task
                    {

                        Id=1,
                        Title = "Regimen Sancionatorio",
                        State = TaskState.Open,
                        AssignedTo = person1

                    };


                    var task2 = new Entities.Task
                    {
                        Id = 2,
                        Title = "Reproceso Masivo",
                        State = TaskState.Close,
                        AssignedTo = person2

                    };


                    var task3 = new Entities.Task
                    {
                        Id = 3,
                        Title = "NHibernate Masivo",
                        State = TaskState.Close,
                        AssignedTo = person3

                    };

                    //this will save all via cascading
                    session.SaveOrUpdate(task1);
                    session.SaveOrUpdate(task2);
                    session.SaveOrUpdate(task3);
                    transaction.Commit();


                }


                using (var session2 = sessionFactory.OpenSession())
                {
                    //retrieve all tasks

                    using (session2.BeginTransaction())
                    {
                        var tasks = session.CreateCriteria(typeof(Entities.Task)).List<Entities.Task>();
                        foreach (var task in tasks)
                        {
                            TaskService.GetTaskInfo(task);
                        }
                    }
                }

                Console.ReadKey();
            }



        }
    }
}
