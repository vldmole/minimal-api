using minimal_api.api.auth;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

ApiMapper.mapEndpoints(app);

app.Run();
