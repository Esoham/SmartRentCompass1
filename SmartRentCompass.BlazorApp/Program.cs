using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SmartRentCompass.Services; // Ensure this matches the namespace in ApartmentService.cs

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register your services
builder.Services.AddScoped<ApartmentService>(); // Register the correct ApartmentService

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization(); // Add this line if you have authentication/authorization in your application

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();