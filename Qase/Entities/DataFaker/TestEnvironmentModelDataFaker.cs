using Bogus;
using Qase.Entities.Models;

namespace Qase.Entities.DataFaker;

public sealed class TestEnvironmentModelDataFaker : Faker<TestEnvironmentModel>
{
    public TestEnvironmentModelDataFaker()
    {
        RuleFor(testEnvironment => testEnvironment.EnvironmentTitle, faker => faker.Random.Word());
        RuleFor(testEnvironment => testEnvironment.EnvironmentSlug, faker => faker.Company.CompanyName());
        RuleFor(testEnvironment => testEnvironment.EnvironmentDescription, faker => faker.Lorem.Sentence());
        RuleFor(testEnvironment => testEnvironment.EnvironmentHost, faker => faker.Commerce.Department());
    }
}