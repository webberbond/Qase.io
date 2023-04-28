using System.Net;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Services.QaseServices;
using Qase.Tests.APISettings;

namespace Qase.Tests.API.Qase;

[AllureNUnit]
public class DefectsTestAPI : ProjectsSettingsAPI
{
    private readonly DefectsModel _defectsModel = new DefectsModelDataFaker().Generate();
    private TestDefectService _testDefectService;
    private const string JsonSchemaPath = "Schemas/DefectSchema.json";
    
    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Defects Test API")]
    public async Task CreateDefect()
    {
        _testDefectService = new TestDefectService();
        
        var (createdDefectStatusCode, restResponse) = await _testDefectService.CreateDefect(GetProjectCode(), _defectsModel);
        Assert.That(createdDefectStatusCode.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"{restResponse}");

        var (getDefectStatusCode, finishModel, createdDefectContent) = await _testDefectService.GetDefectsByProjectCode(GetProjectCode());
        var jsonSchema = await File.ReadAllTextAsync(JsonSchemaPath);
        var isValid = SchemaValidator.ValidateResponse(createdDefectContent, jsonSchema);

        Assert.That(getDefectStatusCode, Is.EqualTo(HttpStatusCode.OK), $"{createdDefectContent}");
        Assert.That(finishModel, Is.EqualTo(_defectsModel), "Comparing actual defect data with generated");
        Assert.That(isValid, Is.EqualTo(true), "Json schema validation");
    }
}