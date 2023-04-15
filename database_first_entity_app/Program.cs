using database_first_entity_app;
using System;

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

        var member = new Member(12, "Jane", "Doe", 100);
        dbContext.Members.Add(member);
        dbContext.SaveChanges();

        dbContext.Trainers.Remove(new Trainer(10, "Greg", "Jackson"));
        dbContext.SaveChanges();

        dbContext.TrainingGroups.Add(new TrainingGroup(110, 110));
        dbContext.SaveChanges();

        dbContext.Trainings.Add(new Training(100, new TimeSpan(18, 0, 0), 10, 10));
        dbContext.SaveChanges();

        Console.WriteLine("\n\n\n\n\n\nLatest data: \n");
        databaseTools.PrintAllTrainers(dbContext);
        databaseTools.PrintAllMembers(dbContext);
        databaseTools.PrintAllGroups(dbContext);
    }
}

