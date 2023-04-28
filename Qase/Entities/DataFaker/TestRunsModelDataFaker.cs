using Bogus;
using Qase.Entities.Models;

namespace Qase.Entities.DataFaker;

public sealed class TestRunsModelDataFaker : Faker<TestRunsModel>
{
    public TestRunsModelDataFaker()
    {
        RuleFor(testRun => testRun.Title, faker => faker.Person.Website);
        RuleFor(testRun => testRun.Description, faker => faker.Lorem.Word());
    }
}