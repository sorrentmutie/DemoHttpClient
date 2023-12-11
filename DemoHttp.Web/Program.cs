using DemoHttp.Services.ReqRes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddScoped<HttpClient>();
builder.Services.AddHttpClient("reqres", client =>
{
    client.BaseAddress = new Uri("https://reqres.in/api/users/");
});
builder.Services.AddScoped<IReqResService, ReqResService>();
//builder.Services.AddScoped<IReqResService, ReqResDatabaseService>();


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

app.MapRazorPages();

app.Run();
