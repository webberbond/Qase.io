﻿using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Steps;

namespace Qase.Tests.UISettings;

public class EnvironmentTestSettings : ProjectsTestSettings
{
    protected readonly TestEnvironmentModel TestEnvironmentModel = new TestEnvironmentModelDataFaker().Generate();

    protected EnvironmentsPageSteps EnvironmentsPageSteps;

    [SetUp]
    public new void SetUp()
    {
        EnvironmentsPageSteps = new EnvironmentsPageSteps(WebDriver);
    }
}