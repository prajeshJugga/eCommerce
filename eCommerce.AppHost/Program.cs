var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.eCommerceApi>("ecommerceapi");

builder.Build().Run();
