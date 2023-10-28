namespace GeneralAlgorithmsBenchmarks;

public static class GlobalAndIterationSetup
{
	public static void FillWithFakeTestData(System.Collections.Generic.List<ComplexPerson> list, int testRecordCount)
	{
		var fakeAddressGenerator =
			new Bogus.Faker<Address>()
			.RuleFor(x => x.City, y => y.Person.Address.City)
			.RuleFor(x => x.Street, y => y.Person.Address.Street)
			.RuleFor(x => x.ZipCode, y => y.Person.Address.ZipCode)
			;

		var fakeBirthdayGenerator =
			new Bogus.Faker<Birthday>()
			.RuleFor(x => x.Year, y => y.Person.Random.Int(1900, 2002))
			.RuleFor(x => x.Month, y => y.Person.Random.Int(1, 12))
			.RuleFor(x => x.Day, y => y.Person.Random.Int(1, 31))
			;

		var fakeComplextGenerator =
			new Bogus.Faker<ComplexPerson>()
			.RuleFor(x => x.Age, y => y.Person.Random.Int(18, 99))
			.RuleFor(x => x.Family, y => y.Person.LastName)
			.RuleFor(x => x.Name, y => y.Person.FirstName)
			.RuleFor(x => x.Nickname, y => y.Person.UserName)
			;

		int intNeededFakeRecords = testRecordCount - list.Count;

		for (int indexFakeRecords = 0; indexFakeRecords < intNeededFakeRecords; indexFakeRecords++)
		{
			var complextObject = fakeComplextGenerator.Generate();
			complextObject.Address = fakeAddressGenerator.Generate();
			complextObject.Birthday = fakeBirthdayGenerator.Generate();
			list.Add(complextObject);

			if ((indexFakeRecords + 1) % 1000 == 0)
			{
				MrTechLead.Console.WriteLine($"{System.DateTime.Now.ToString("HH:mm:ss.ms")}\t 1000 Test Records Inserted!", System.ConsoleColor.Cyan);
			}
		}

		MrTechLead.Console.WriteLine($"{System.DateTime.Now.ToString("HH:mm:ss.ms")}\t {testRecordCount} Test Records Are Ready!", System.ConsoleColor.Cyan);
	}
}
