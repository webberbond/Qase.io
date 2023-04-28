using Bogus;
using Qase.Entities.Models;

namespace Qase.Entities.DataFaker;

public sealed class TestPlanModelDataFaker : Faker<TestPlanModel>
{
    public TestPlanModelDataFaker()
    {
        RuleFor(plan => plan.PlanTitle, faker => faker.Person.Website);
        RuleFor(plan => plan.PlanDescription, faker => faker.Lorem.Sentence());
    }
}