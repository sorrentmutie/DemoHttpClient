using DemoHttp.Services.PeopleTodos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//builder.Services.AddScoped<HttpClient>();
builder.Services.AddHttpClient("json-placeholder",
    client => { client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/"); });

builder.Services.AddScoped<IPeopleTodosServices, PeopleTodosServices>();
// builder.Services.AddScoped<IRandomUserService, RandomUserService>();
// builder.Services.AddScoped<IReqResService, ReqResService>();
// builder.Services.AddScoped<IReqResService, ReqResDatabaseService>();

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