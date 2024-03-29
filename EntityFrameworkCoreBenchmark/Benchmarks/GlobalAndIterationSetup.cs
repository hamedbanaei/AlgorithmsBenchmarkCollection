﻿using Microsoft.EntityFrameworkCore;

namespace Benchmarks;

public static class GlobalAndIterationSetup
{
    public static void FillDatabaseWithFakeTestData(int testFatherCount, bool ignoreCheckIfDatabaseHasData)
    {
        int intDbFathersCount = 0;

        if (ignoreCheckIfDatabaseHasData == false)
        {
            using var InitialCheckDbContext = new Model.DatabaseContext();

            intDbFathersCount = InitialCheckDbContext.Fathers.Count();

            if (intDbFathersCount >= testFatherCount) return;
        }

        var fakeFatherGenerator =
            new Bogus.Faker<Model.Father>()
            .RuleFor(x => x.Name, y => y.Person.FullName)
            .RuleFor(x => x.NickName, y => y.Person.FirstName)
            .RuleFor(x => x.Phone, y => y.Person.Phone)
            .RuleFor(x => x.Email, y => y.Person.Email)
            .RuleFor(x => x.Website, y => y.Person.Website)
            .RuleFor(x => x.State, y => y.Person.Address.State)
            .RuleFor(x => x.City, y => y.Person.Address.City)
            .RuleFor(x => x.Street, y => y.Person.Address.Street)
            .RuleFor(x => x.ZipCode, y => y.Person.Address.ZipCode)
            .RuleFor(x => x.CarModel, y => y.Vehicle.Model())
            ;

        var fakeChildrenGenerator =
            new Bogus.Faker<Model.Child>()
            .RuleFor(x => x.Name, y => y.Person.FirstName)
            .RuleFor(x => x.Avatar, y => y.Person.Avatar)
            .RuleFor(x => x.Description, y => y.Person.Random.Words(3))
            ;

        var random = new System.Random();
        int intNeededFatherRecords = testFatherCount - intDbFathersCount;
        for (int indexFather = 0; indexFather < intNeededFatherRecords; indexFather++)
        {
            using var dbContext = new Model.DatabaseContext();

            var father = fakeFatherGenerator.Generate();
            dbContext.Fathers.Add(father);
            dbContext.SaveChanges();

            int intChildrenCount = random.Next(0, 5);

            Model.Child child = null;
            for (int indexChildren = 0; indexChildren < intChildrenCount; indexChildren++)
            {
                child = fakeChildrenGenerator.Generate();
                child.FatherId = father.Id;
                dbContext.Add(child);
            }

            dbContext.SaveChanges();

            if ((indexFather + 1) % 1000 == 0)
            {
                MrTechLead.Console.WriteLine($"{System.DateTime.Now.ToString("HH:mm:ss.ms")}\t 1000 Father Records Inserted!\tTotal Father Records Untill Now: {dbContext.Fathers.Count().ToString("#,##0")}", System.ConsoleColor.Cyan);
            }
        }

        using var reportResultContext = new Model.DatabaseContext();
        MrTechLead.Console.WriteLine($"All Needed Father Records ({intNeededFatherRecords.ToString("#,##0")}) Inserted at {System.DateTime.Now.ToString("HH: mm:ss.ms")}!", ConsoleColor.DarkGreen);
        MrTechLead.Console.WriteLine("Current Test Database Avaiable Records:", ConsoleColor.Green);
        MrTechLead.Console.WriteLine($"Total Father Records: {reportResultContext.Fathers.Count().ToString("#,##0")}", ConsoleColor.DarkGreen);
        MrTechLead.Console.WriteLine($"Total Children Records: {reportResultContext.Children.Count().ToString("#,##0")}", ConsoleColor.DarkGreen);
    }
}
