using Blazored.LocalStorage;
using DadsCollectionsLibrary.Data;
using DadsCollectionsLibrary.DBAccess;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddMvc();
builder.Services.AddTransient<IDatabaseData, SqlData>();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();

builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();



// Todo:
//-- Moderate tasks - need concentration
//1. cart page - add delete button (add ability to adjust the cart)


//-- Easy Tasks
//1. Main Page - need to adjust image to full screen

//2. product page - add products to DB and display



//ref to cookie and session setup
//https://github.com/blowdart/AspNetSameSiteSamples/tree/master/AspNetCore31RazorPages
//https://www.mikesdotnetting.com/article/210/razor-web-pages-e-commerce-adding-a-shopping-cart-to-the-bakery-template-site
//https://learningprogramming.net/net/asp-net-core-razor-pages/build-shopping-cart-with-session-in-asp-net-core-razor-pages/

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.Cookie.SameSite = SameSiteMode.None;
//        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
//        options.Cookie.IsEssential = true;
//    });

//builder.Services.AddSession(options =>
//{
//    options.Cookie.SameSite = SameSiteMode.None;
//    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
//    options.Cookie.IsEssential = true;
//});