using System;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace database_first_app
{
    public class DatabaseManagmentTools
    {
        public void PrintAllTrainers(gymDatabaseEntities dbContext)
        {
            var listOfTrainers = dbContext.Trainers.ToList();
            Console.WriteLine("Trainers: ");
            foreach (var item in listOfTrainers)
            {
                Console.WriteLine(item.id + " " + item.first_name + " " + item.last_name);
            }
        }

        public void PrintAllMembers(gymDatabaseEntities dbContext)
        {
            var listOfMembers = dbContext.Members.ToList();
            Console.WriteLine("\nMembers: ");
            foreach (var item in listOfMembers)
            {
                Console.WriteLine(item.id + " " + item.first_name + " " + item.last_name);
            }
        }

        public void PrintAllGroups(gymDatabaseEntities dbContext)
        {
            var listOfGroups = dbContext.TrainingGroups.ToList();
            Console.WriteLine("\nTraining groups: ");
            foreach (var item in listOfGroups)
            {
                Console.WriteLine("ID: " + item.id + " Trainer ID: " + item.trainer_id + "\n");
            }
        }
    }
}