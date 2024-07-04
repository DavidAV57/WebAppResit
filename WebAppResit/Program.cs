using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using WebAppResit.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebAppResitContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebAppResitContext") ?? throw new InvalidOperationException("Connection string 'WebAppResitContext' not found.")));

/*
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<WebAppResitContext>();
    */

// Add services to the container.
builder.Services.AddIdentity<IdentityUser, IdentityRole>(
        options =>
        {
            options.Stores.MaxLengthForKeys = 128;
        })
    .AddEntityFrameworkStores<WebAppResitContext>()
    .AddRoles<IdentityRole>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Services.AddAuthorization(Options =>
{
Options.AddPolicy("RequiresAdmins",policy =>policy.RequireRole("Admin"));
});
builder.Services.AddRazorPages()
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizeFolder("/Admin", "RequiresAdmins");
    });
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
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<WebAppResitContext>();
    context.Database.Migrate();
    var userMgr = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleMgr = services.GetRequiredService<RoleManager<IdentityRole>>();
    IdentitySeedData.Initialize(context, userMgr, roleMgr).Wait();

}
app.Run();
