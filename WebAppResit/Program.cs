using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using WebAppResit.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebAppResitContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebAppResitContext") ?? throw new InvalidOperationException("Connection string 'WebAppResitContext' not found.")));

// Add services to the container.

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();
builder.Services.AddAuthentication();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    
    var context = services.GetRequiredService<WebAppResitContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initializer(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
