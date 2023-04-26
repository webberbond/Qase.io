using Bogus;
using Bogus.Extensions;
using Qase.Entities.Models;

namespace Qase.Entities.DataFaker;

public sealed class TestProjectModelDataFaker : Faker<TestProjectModel>
{
    public TestProjectModelDataFaker()
    {
        RuleFor(project => project.ProjectName, faker => faker.Random.Word().ClampLength(2,4) + "-" + faker.Random.Word().ClampLength(2,4));
        RuleFor(project => project.ProjectCode, faker => "TP" + faker.IndexGlobal + faker.Hacker.Abbreviation().ClampLength(2, 4).ToUpper());
    }
}