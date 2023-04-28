namespace Qase.Entities.ResponseModels;

public class Counts
{
    public int cases { get; set; }
    public int suites { get; set; }
    public int milestones { get; set; }
    public Runs runs { get; set; }
    public Defects defects { get; set; }
}

public class Defects
{
    public int total { get; set; }
    public int open { get; set; }
}

public class Result
{
    public string title { get; set; }
    public string code { get; set; }
    public Counts counts { get; set; }
}

public class ProjectModelAPI
{
    public bool status { get; set; }
    public Result result { get; set; }
}

public class Runs
{
    public int total { get; set; }
    public int active { get; set; }
}