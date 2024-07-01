using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SHotel.Business.DTOs.SliderDTOs;
using SHotel.Business.Extensions;
using SHotel.Business.Mapping;
using SHotel.Business.Services.Abstracts;
using SHotel.Business.Services.Concretes;
using SHotel.Business.ViewServices;
using SHotel.Core.Models;
using SHotel.Core.RepositoryAbstracts;
using SHotel.Data.DAL;
using SHotel.Data.RepositoryConcretes;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler =
    System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
}).AddFluentValidation(x=>
{
    x.RegisterValidatorsFromAssemblyContaining(typeof(SliderCreateDTOValidator));
});

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("default")); 
});

builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.SignIn.RequireConfirmedEmail = true;    
    opt.Password.RequireNonAlphanumeric = true;
    opt.Password.RequiredLength = 8;
    opt.Password.RequireDigit = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;

    opt.User.RequireUniqueEmail = true;

    //opt.SignIn.RequireConfirmedEmail = true;
     
    opt.Lockout.MaxFailedAccessAttempts = 5;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
    opt.Lockout.AllowedForNewUsers = true;


}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe")); 

builder.Services.AddScoped<ISliderRepository, SliderRepository>();
builder.Services.AddScoped<ISliderService, SliderService>();

builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
builder.Services.AddScoped<IFeatureService, FeatureService>();

builder.Services.AddScoped<IGuestReviewRepository, GuestReviewRepository>();
builder.Services.AddScoped<IGuestReviewService, GuestReviewService>();

builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IPositionService, PositionService>();

builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
builder.Services.AddScoped<IWorkerService, WorkerService>();

builder.Services.AddScoped<IEatCategoryRepository, EatCategoryRepository>();   
builder.Services.AddScoped<IEatCategoryService, EatCategoryService>();

builder.Services.AddScoped<IEatRepository, EatRepository>();
builder.Services.AddScoped<IEatService, EatService>();

builder.Services.AddScoped<IBedRepository, BedRepository>();
builder.Services.AddScoped<IBedService, BedService>();

builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomService, RoomService>();

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IReservationService, ReservationService>();

builder.Services.AddScoped<IContactPostRepository, ContactPostRepository>();
builder.Services.AddScoped<IContactPostService, ContactPostService>();

builder.Services.AddScoped<ISettingRepository, SettingRepository>();
builder.Services.AddScoped<ISettingService, SettingService>();

builder.Services.AddScoped<IAdventureCategoryRepository, AdventureCategoryRepository>();
builder.Services.AddScoped<IAdventureCategoryService, AdventureCategoryService>();

builder.Services.AddScoped<IAdventureRepository, AdventureRepository>();
builder.Services.AddScoped<IAdventureService, AdventureService>();

builder.Services.AddScoped<IBasketItemService, BasketItemService>();
builder.Services.AddScoped<IBasketItemRepository, BasketItemRepository>();  


builder.Services.AddScoped<IRoomImageRepository, RoomImageRepository>();

builder.Services.AddScoped<LayoutService>();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.ConfigureExceptionHandler();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();
StripeConfiguration.ApiKey = builder.Configuration["Stripe:Secretkey"];
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
