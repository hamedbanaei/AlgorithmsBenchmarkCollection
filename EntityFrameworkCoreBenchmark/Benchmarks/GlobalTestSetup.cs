using Microsoft.EntityFrameworkCore;

namespace Benchmarks;

public static class GlobalTestSetup
{
    public static void FillDatabaseWithFakeTestData(int fatherCount, bool ignoreCheckIfDatabaseHasData)
    {
        var start = System.DateTime.Now;

        if (ignoreCheckIfDatabaseHasData == false)
        {
            using var dbContext = new Model.DatabaseContext();

            bool blnHasDatabaseFilledAlready = false;
            blnHasDatabaseFilledAlready =
                dbContext.Fathers.Any();

            if (blnHasDatabaseFilledAlready) return;
        }

        var fakeFatherGenerator =
            new Bogus.Faker<Model.Father>()
            .RuleFor(x => x.Name, y => y.Person.FullName)
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

        for (int indexFather = 0; indexFather < fatherCount; indexFather++)
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
        }

        var end = System.DateTime.Now;

        var elapsedTime = end - start;

        var outPut = $"ElapsedTime: {elapsedTime.Hours}:{elapsedTime.Minutes}:{elapsedTime.Seconds}.{elapsedTime.Milliseconds}";

        System.Diagnostics.Trace.WriteLine(outPut);
    }
}
