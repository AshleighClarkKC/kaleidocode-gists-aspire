using Projects;

var builder = DistributedApplication.CreateBuilder(args);


builder.AddProject<Kaleidocode_Gists_Services_General>("GeneralService");

builder.Build().Run();
