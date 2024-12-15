using Paranoia.Client.Configuration;
using Paranoia.Client.Services;

namespace Paranoia.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<MessageOptions>((o) => {
                o.HostName = builder.Configuration["Message:HostName"];
                o.Port = int.Parse(builder.Configuration["Message:Port"]);
            });

            // Add services to the container.
            builder.Services
                .AddScoped<IMessageService, MessageService>()
                .AddScoped<IChatService, ChatService>();

            builder.Services.AddRazorPages();

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
        }
    }
}
