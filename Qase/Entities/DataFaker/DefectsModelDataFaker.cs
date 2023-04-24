using Bogus;
using Qase.Entities.Models;

namespace Qase.Entities.DataFaker;

public sealed class DefectsModelDataFaker : Faker<DefectsModel>
{
    public DefectsModelDataFaker()
    {
        RuleFor(defects => defects.DefectTitle, faker => faker.Hacker.Noun());
        RuleFor(defects => defects.ActualResult, faker => faker.Commerce.Department());
        RuleFor(defects => defects.Severity, faker => faker.Random.Int(1, 6).ToString());
    }
}