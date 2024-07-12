using ATSAPPBACKEND.DAL;
using ATSAPPBACKEND.Repositories.Classes;
using ATSAPPBACKEND.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ATSAPPBACKEND
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("homeDbConnection"));
            });
            services.AddCors(options =>
            {
                options.AddPolicy("ATSAPPAPI", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().WithMethods("POST");
                });

            });
            services.AddScoped<DbContext, AppDbContext>();
            services.AddScoped<IBASICGETS, BASICGETS>();
            services.AddScoped<ICANDIDATEREPOSITORY, CANDIDATEREPOSITORY>();
            services.AddScoped<ICLIENTREPOSITORY, CLIENTREPOSITORY>();
            services.AddScoped<IEMPLOYERCOMPANYREPOSITORY, EMPLOYERCOMPANYREPOSITORY>();
            services.AddScoped<IEMPLOYERRESPOSITORY, EMPLOYERRESPOSITORY>();
            services.AddScoped<IIMPLEMENTATIONREPOSITORY, IMPLEMENTATIONREPOSITORY>();
            services.AddScoped<IREQUIREMENTREPOSITORY, REQUIREMENTREPOSITORY>();
            services.AddScoped<ISUBMISSIONREPOSITORY, SUBMISSIONREPOSITORY>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("ATSAPPAPI");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ATSAPP API v1");
            });
        }
    }
}
