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
        //���������� Config.cs (Service)
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration; //���������� � ������� ����������

        public void ConfigureServices(IServiceCollection services)
        {
            //����������� ������� �� appsettings.json
            Configuration.Bind("Project", new Config()); //��������� ������ Project � ����� ������ ������

            //���������� ������ ���������� ���������� � �������� ��������
            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>(); //������ ���������� � ����������� ����������
            services.AddTransient<IAffichesRepository, EFAffichesRepository>();
            services.AddTransient<IActorsRepository, EFActorsRepository>();
            services.AddTransient<DataManager>();

            //���������� �������� ��
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            //����������� identity �������
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;            //������������� �����
                opts.Password.RequiredLength = 6;               //����������� ����� ������
                opts.Password.RequireNonAlphanumeric = false;   //� ������ ��������� ������, �������� �� ��������-���������
                opts.Password.RequireLowercase = false;         //������������ �������� �����
                opts.Password.RequireUppercase = false;         //������������ ��������� �����
                opts.Password.RequireDigit = false;             //��������� ����� �� 0-9 � ������
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //���������� authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "EnglishTheatre";                 //�������� ����
                options.Cookie.HttpOnly = true;                         //���������� �� ���������� �������
                options.LoginPath = "/account/login";                   //���� ��� ������� � ������ ������
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            //����������� �������� ����������� ��� AdminArea
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); }); //������� �� ������������ ���� �����
            });

            //��������� ������� ��� ������������ � ������������� (MVC)
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea")); //�������� ������� � ��������
            });

            //��������� ��������� ������������ � ������������� (MVC)
            services.AddControllersWithViews()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //����������� � ������������ �������!!!!!!!!!!

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();    //��������� ���������� � ������

            //����������� ��������� ��������� ������ � ���������� (css, js, ...)
            app.UseStaticFiles();

            //����������� �������������
            app.UseRouting();

            //���������� �������������� � �����������
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            //������������ ������ �������� (endpoints)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");  //������� ��� ������
                endpoints.MapControllerRoute("default", "{controller=Affiches}/{action=Index}/{id?}");              //default - /Home/Index
            });
        }
    }
}
