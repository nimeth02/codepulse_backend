using codePuls.Application.Interfaces;
using codePuls.Application.Services;
using codePuls.Infrastructure.Extensions;
using CodePuls.Domain.Interfaces.Repositories;
using codePuls.Infrastructure.Repositories;
using codePuls.Application.Configurations;
using codePuls.Domain.Interfaces.Repositories;
using codePuls.Domain.Interfaces;
using codePuls.API.Middlewares;
using FluentValidation.AspNetCore;
using codePuls.Application.DTOs.RequestValidators;
using FluentValidation;
using codePuls.API.Extensions;
//using codePuls.Application.Services.Metrics;
//using codePuls.Application.Interfaces.Metrics;
//using codePuls.Application.Services.Chat;
//using codePuls.Application.Interfaces.Chat;
//using codePuls.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerDocumentation();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IProjectMembershipRepository, ProjectMembershipRepository>();
//builder.Services.AddScoped<ITeamRepository, TeamRepository>();
//builder.Services.AddScoped<ITeamService, TeamService>();
//builder.Services.AddScoped<ITeamMembershipRepository, TeamMembershipRepository>();
//builder.Services.AddScoped<ICodeReositoryReository, CodeRepositoryRepository>();
//builder.Services.AddScoped<ICodeRepositoryService, CodeRepositoryService>();
//builder.Services.AddScoped<IPullRequestReository, PullRequestRepository>();
//builder.Services.AddScoped<IPullRequestService, PullRequestService>();
//builder.Services.AddScoped<IPRClosedFrequencyService, PRClosedFrequencyService>();
//builder.Services.AddScoped<ICycleTimeService, CycleTimeService>();
//builder.Services.AddScoped<IPRActivityService, PRActivityService>();
//builder.Services.AddScoped<IPRClosedComparisonService, PRClosedComparisonService>();
//builder.Services.AddScoped<ICycleTimeComparisonService, CycleTimeComparisonService>();
//builder.Services.AddScoped<IChatService, codePuls.Application.Services.Chat.ChatService>();
//builder.Services.AddScoped<IChatRepository, codePuls.Infrastructure.Services.ChatService>();
//builder.Services.AddScoped<ILLMRepository, LLMService>();
builder.Services.AddScoped<ITransactionManager, TransactionManager>();

builder.Services.AddHttpClient();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

//builder.Services.Configure<ApiBehaviorOptions>(options =>
//{
//    Console.WriteLine("Configuring ApiBehaviorOptions with custom InvalidModelStateResponseFactory");
//    options.SuppressModelStateInvalidFilter = true;
//    options.UseCustomInvalidModelStateResponse();
//    Console.WriteLine("ApiBehaviorOptions configured. SuppressModelStateInvalidFilter: " + options.SuppressModelStateInvalidFilter);
//});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidateModelFilter>();
})
.ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
})
.AddFluentValidation(options =>
{
    options.AutomaticValidationEnabled = true;
    options.DisableDataAnnotationsValidation = true;
    options.ImplicitlyValidateChildProperties = true;
    options.ImplicitlyValidateRootCollectionElements = true;
});

builder.Services.AddValidatorsFromAssemblyContaining<ProjectRequestValidator>();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseCors("AllowAllOrigins");

app.UseMiddleware<ExceptionHandlingMiddleware>();

MapsterConfig.ConfigureMappings();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/hello", () => Results.Ok("Hello from codePuls!"));

app.MapControllers();

app.Run();
