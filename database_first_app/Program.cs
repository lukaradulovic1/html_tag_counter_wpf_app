using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace database_first_app
{
    public class Program : DatabaseManagmentTools
    {
        static void Main(string[] args)
        {
            gymDatabaseEntities dbContext = new gymDatabaseEntities();
            var databaseTools = new DatabaseManagmentTools();

            Console.WriteLine("Welcome to gym database app!\nHere is the sample data:\n");
            databaseTools.PrintAllTrainers(dbContext);
            databaseTools.PrintAllMembers(dbContext);
            databaseTools.PrintAllGroups(dbContext);

            var member = new Member(10, "John", "Smith", 10);
            dbContext.Members.Add(member);

            dbContext.Trainers.Add(new Trainer(10, "Greg", "Jackson"));

            dbContext.TrainingGroups.Add(new TrainingGroup(10, 10));

            dbContext.Trainings.Add(new Training(10, new TimeSpan(18,9,9), 10, 10));
            Console.WriteLine("Latest data: \n");
            databaseTools.PrintAllTrainers(dbContext);
            databaseTools.PrintAllMembers(dbContext);
            databaseTools.PrintAllGroups(dbContext);
        }
    }
}
