using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SmartRentCompass.Data; // Replace this with the correct namespace where ApartmentService is located
// Ensure the ApartmentService.cs file has this namespace at the top

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register your services
builder.Services.AddScoped<ApartmentService>(); // Correct service registration

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();