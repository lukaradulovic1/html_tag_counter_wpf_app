using database_first_entity_app;
using System;
using System.Linq;

public class DatabaseManagmentTools
{
    public void PrintAllTrainers(gymDatabaseEntities dbContext)
    {
        var listOfTrainers = dbContext.Trainers.ToList();

        foreach (var trainer in listOfTrainers)
        {
            Console.WriteLine("Trainer ID: " + trainer
                .id + "Trainer name: " + trainer
                .first_name + " " + trainer
                .last_name);
        }
    }
    public void PrintAllMembers(gymDatabaseEntities dbContext)
    {
        var listOfMembers = dbContext.Members.ToList();
        foreach (var member in listOfMembers)
        {
            Console.WriteLine("Member ID: " + member
                .id + "Trainer name: " + member
                .first_name + " " + member
                .last_name);
        }
    }
    public void PrintAllGroups(gymDatabaseEntities dbContext)
    {
        var listOfTrainingGroups = dbContext.TrainingGroups.ToList();
        foreach (var group in listOfTrainingGroups)
        {
            Console.WriteLine("Group ID: " + group.id);
        }
    }
    public void PrintAllTrainining(gymDatabaseEntities dbContext)
    {
        var listOfTrainingSlots = dbContext.Trainings.ToList();
        foreach (var slot in listOfTrainingSlots)
        {
            Console.WriteLine("Training slot ID: " + slot
                .id + "Trainer ID: " + slot
                .trainer + "Session time: " + slot
                .training_time );
        }
    }
}