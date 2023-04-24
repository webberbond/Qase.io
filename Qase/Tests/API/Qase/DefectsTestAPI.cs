using System.Net;
using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Services;
using Qase.Tests.APISettings;
using Qase.Utilities;

namespace Qase.Tests.API.Qase;

public class DefectsTestAPI : ProjectsSettingsAPI
{
    private readonly DefectsModel _defectsModel = new DefectsModelDataFaker().Generate();

    [Test]
    public async Task CreateDefect()
    {
        var restResponse = await TestDefectService.CreateDefect(GetProjectCode(), _defectsModel);
        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        
        const string jsonSchemaPath = "Schemas/DefectSchema.json";

        var createdDefect = await TestDefectService.GetDefectsByProjectCode(GetProjectCode());
        var jsonResponse = createdDefect.Content;
        var jsonSchema = await File.ReadAllTextAsync(jsonSchemaPath);
        
        var isValid = SchemaValidator.ValidateResponse(jsonResponse, jsonSchema);
        Assert.That(isValid, Is.EqualTo(true), "Json schema validation");

        var finishModel = new DefectsModel
        {
            DefectTitle = createdDefect.Data.result.title,
            ActualResult = createdDefect.Data.result.actual_result
        };
        
        Assert.That(finishModel, Is.EqualTo(_defectsModel), "Comparing actual defect data with generated");
    }
}