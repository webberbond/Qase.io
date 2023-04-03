using Bogus;
using Bogus.Extensions;
using Qase.Entities.Models;

namespace Qase.Entities.DataFaker;

public sealed class TestProjectModelDataFaker : Faker<TestProjectModel>
{
    public TestProjectModelDataFaker()
    {
        RuleFor(project => project.ProjectName, faker => faker.Random.String2(3, 5));
        RuleFor(project => project.ProjectCode,
            faker => faker.IndexGlobal + faker.Hacker.Abbreviation().ClampLength(4, 8).ToUpper());
        RuleFor(project => project.ProjectDescription, faker => faker.Lorem.Word());
    }
}