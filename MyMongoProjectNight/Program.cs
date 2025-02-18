using Microsoft.Extensions.Options;
using MyMongoProjectNight.Services;
using MyMongoProjectNight.Services.CategoryServices;
using MyMongoProjectNight.Services.DepartmentServices;
using MyMongoProjectNight.Services.DiscountServices;
using MyMongoProjectNight.Services.FeatureServices;
using MyMongoProjectNight.Services.ProductServices;
using MyMongoProjectNight.Services.SaleServices;
using MyMongoProjectNight.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());//Tek tek atama yapmak yerine bunu otomatik olarak eþlemeizii saðlayan Automapperýn çalýþmasýný saðlayan yapý

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettingskey"));

builder.Services.AddScoped<IDatabaseSettings>(sp => //serviceprovider:servissaðlayýcýsý
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();