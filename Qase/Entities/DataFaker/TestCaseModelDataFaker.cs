using Bogus;
using Qase.Entities.Models;

namespace Qase.Entities.DataFaker;

public sealed class TestCaseModelDataFaker : Faker<TestCaseModel>
{
    public TestCaseModelDataFaker()
    {
        RuleFor(testCase => testCase.Title, faker => faker.Vehicle.Manufacturer());
        RuleFor(testCase => testCase.Description, faker => faker.Lorem.Sentence());
        RuleFor(testCase => testCase.PreConditions, faker => faker.Company.CompanyName());
        RuleFor(testCase => testCase.PostConditions, faker => faker.Commerce.Department());
    }
}