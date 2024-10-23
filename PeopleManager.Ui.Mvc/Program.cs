using Microsoft.EntityFrameworkCore;
using PeopleManager.Ui.Mvc.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. | Dependencies/services registreren in container
builder.Services.AddControllersWithViews();

// AddDbContext => scoped 
builder.Services.AddDbContext<PeopleManagerDbContext>(options =>
{
    options.UseInMemoryDatabase(nameof(PeopleManagerDbContext));
});

var app = builder.Build();

// Configure the HTTP request pipeline. | Provider
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    // zeggen tegen service provider => Geef me een database, EN We weten dat hij geregistreerd is
    // iets dat disposable is = proper opkuisen na uitvoering
    using var scope = app.Services.CreateScope();
    var database = scope.ServiceProvider.GetRequiredService<PeopleManagerDbContext>();
    database.Seed();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
