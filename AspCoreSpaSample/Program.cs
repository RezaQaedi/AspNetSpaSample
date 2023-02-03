using AspCoreSpaSample.Domin;
using AspCoreSpaSample.Endpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(c =>
    c.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("Default")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(o =>
{
    o.Password.RequireDigit = false;
    o.Password.RequiredLength = 1;
    o.Password.RequireUppercase = false;
    o.Password.RequireLowercase = false;
    o.Password.RequireNonAlphanumeric = false;
    
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(_ => { });


app.Use((ctx, next) =>
{
    if (ctx.Request.Path.StartsWithSegments("/api"))
    {
        ctx.Response.StatusCode = 404;
        return Task.CompletedTask;
    }

    return next();
});

app.UseSpa(c =>
{
    c.UseProxyToSpaDevelopmentServer("http://localhost:4200");
});

var apiEndpoints = app.MapGroup("/api");

apiEndpoints.MapGet("/user", UserEndpoint.Handler);
apiEndpoints.MapPost("/login", LoginEndpoint.Handler);
apiEndpoints.MapPost("/regiser", RegisterEndpoint.Handler);
apiEndpoints.MapGet("/Logout", LogoutEndpoint.Handler).RequireAuthorization();

app.UseHttpsRedirection();

app.Run();
