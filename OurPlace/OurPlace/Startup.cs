using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OurPlace.Data;
using OurPlace.Hubs;
using OurPlace.Repositories;
using OurPlace.Repositories.Interfaces;
using OurPlace.Services;
using OurPlace.Services.Interfaces;

namespace OurPlace
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("LocalConnection")));

            services.AddDefaultIdentity<User>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddSignalR();

            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IImageRepository, ImageRepository>();

            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<INotificationRepository, NotificationRepository>();

            services.AddTransient<IFriendService, FriendService>();
            services.AddTransient<IFriendRepository, FriendRepository>();

            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IChatRepository, ChatRepository>();

            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IMessageRepository, MessageRepository>();

            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IPostRepository, PostRepository>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [System.Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chatHub");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=HomePage}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
