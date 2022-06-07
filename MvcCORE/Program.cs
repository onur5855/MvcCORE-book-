using Microsoft.EntityFrameworkCore;
using MvcCORE.Infrastructure.Context;
using MvcCORE.Infrastructure.RepoSitories.Concrete;
using MvcCORE.Infrastructure.RepoSitories.Interface.EntityRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//starup servisleri burada yaziliyor servis 
builder.Services.AddDbContext<BookContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ) ;
    options.UseLazyLoadingProxies(true);
});
//burada kullang�m�z. addscoped  => her istek yani request i�in nesne �retir ve talep sonland�g�nda �retti�i nesneyi dispose eder.
//asp.net core da  3 adet ya�am s�resi (life time) vard�r. bunlar addscope,addsingleton,addtransienttir.
//burada yapt�g�m�z kay�t i�lemi sayesinde uygulama Interface hallerini cag�rd�m�zda Repolar�n Concreteleri bize verilir.
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IDetailsRepository, DetailsRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
