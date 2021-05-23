using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BookShopAPI.Entities.DbContext;
using BookShopAPI.Guards;
using BookShopAPI.Guards.Interfaces;
using BookShopAPI.Middlewares;
using BookShopAPI.Models.Book;
using BookShopAPI.Models.Book.Validators;
using BookShopAPI.Models.BookShop;
using BookShopAPI.Models.BookShop.Validators;
using BookShopAPI.Seeder;
using BookShopAPI.Services;
using BookShopAPI.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace BookShopAPI
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
            services.AddControllers().AddFluentValidation();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddDbContext<BookShopDbContext>();
            services.AddScoped<BookShopSeeder>();
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddSwaggerGen();
            services.AddScoped<IBookShopService, BookShopService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookServiceGuard, BookServiceGuard>();
            services.AddScoped<IValidator<CreateBookShopDto>, CreateBookShopDtoValidator>();
            services.AddScoped<IValidator<BookQuery>, BookQueryValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BookShopSeeder seeder)
        {
            seeder.Seed();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookShop API");
            });

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
