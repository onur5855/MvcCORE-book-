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
//burada kullangýmýz. addscoped  => her istek yani request için nesne üretir ve talep sonlandýgýnda ürettiði nesneyi dispose eder.
//asp.net core da  3 adet yaþam süresi (life time) vardýr. bunlar addscope,addsingleton,addtransienttir.
//burada yaptýgýmýz kayýt iþlemi sayesinde uygulama Interface hallerini cagýrdýmýzda Repolarýn Concreteleri bize verilir.
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
