using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PIS.Models;
using PIS.Options;
using PIS.Services;
using PIS.Services.Contracts;
using PIS.Repositories;
using Microsoft.EntityFrameworkCore;
using PIS.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<AdminCredentialsOptions>(
    builder.Configuration.GetSection(AdminCredentialsOptions.SectionName));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 6;
    })
    .AddEntityFrameworkStores<RepositoryContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.SlidingExpiration = true;
});

// Register ProjectManager as a singleton for DI
builder.Services.AddScoped<IProjectService, ProjectManager>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var repositoryContext = services.GetRequiredService<RepositoryContext>();
    repositoryContext.Database.EnsureCreated();

    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var adminOptions = services.GetRequiredService<IOptions<AdminCredentialsOptions>>().Value;

    var roles = new[] { "admin", "user" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    var adminUser = await userManager.FindByNameAsync(adminOptions.UserName);
    if (adminUser == null)
    {
        adminUser = new ApplicationUser
        {
            UserName = adminOptions.UserName,
            Email = adminOptions.UserName
        };

        var result = await userManager.CreateAsync(adminUser, adminOptions.Password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "admin");
        }
    }
    else if (!await userManager.IsInRoleAsync(adminUser, "admin"))
    {
        await userManager.AddToRoleAsync(adminUser, "admin");
    }
}

app.Run();
