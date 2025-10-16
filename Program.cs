var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient("API", client =>
{
    //client.BaseAddress = new Uri("https://localhost:7047/"); //En local
    client.BaseAddress = new Uri("https://rindra-dotnet-developer.onrender.com"); //Sur Render
    client.Timeout = TimeSpan.FromSeconds(60); // éviter le TaskCanceled
});
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("API"));

// Add services to the container.
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Portfolio}/{action=Home}/{id?}");

app.Run();
