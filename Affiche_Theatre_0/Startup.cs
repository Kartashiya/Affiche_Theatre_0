using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Affiche_Theatre_0.Service;
using Affiche_Theatre_0.Domain.Repositories.Abstract;
using Affiche_Theatre_0.Domain.Repositories.EntityFramework;
using Affiche_Theatre_0.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Affiche_Theatre_0
{
    public class Startup
    {
        //подлкючаем Config.cs (Service)
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration; //обращаемся к конфигу приложения

        public void ConfigureServices(IServiceCollection services)
        {
            //подлюкчение конфига из appsettings.json
            Configuration.Bind("Project", new Config()); //связываем раздел Project с нашим конфиг файлом

            //подключаем нужный функционал приложения в качестве сервисов
            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>(); //связка интерфейса с реализацией интерфейса
            services.AddTransient<IAffichesRepository, EFAffichesRepository>();
            services.AddTransient<IActorsRepository, EFActorsRepository>();
            services.AddTransient<DataManager>();

            //подключаем контекст БД
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            //настраиваем identity систему
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;            //подтверждение почты
                opts.Password.RequiredLength = 6;               //минимальная длина пароля
                opts.Password.RequireNonAlphanumeric = false;   //в пароле требуется символ, отличный от буквенно-цифрового
                opts.Password.RequireLowercase = false;         //использовать строчные буквы
                opts.Password.RequireUppercase = false;         //использовать прописные буквы
                opts.Password.RequireDigit = false;             //требуется число от 0-9 в пароле
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //настриваем authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "EnglishTheatre";                 //название куки
                options.Cookie.HttpOnly = true;                         //недоступно на клиентской стороне
                options.LoginPath = "/account/login";                   //путь для доступа к панели админа
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            //настраиваем политику авторизации для AdminArea
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); }); //требуем от пользователя роль админ
            });

            //добавляем сервисы для контроллеров и представлений (MVC)
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea")); //передаем область и политику
            });

            //добавляем поддержку контроллеров и представлений (MVC)
            services.AddControllersWithViews()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //ПОДКЛЮЧЕНИЕ В ОПРЕДЕЛЕННОМ ПОРЯДКЕ!!!!!!!!!!

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();    //подробная информация о ошибке

            //подключение поддержки статичных файлов в приложении (css, js, ...)
            app.UseStaticFiles();

            //подключение маршрутизации
            app.UseRouting();

            //подключаем аутентификацию и авторизацию
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            //регистрируем нужные маршруты (endpoints)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");  //маршрут для админа
                endpoints.MapControllerRoute("default", "{controller=Affiches}/{action=Index}/{id?}");              //default - /Home/Index
            });
        }
    }
}
