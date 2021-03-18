using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Persistence.EF;
using OnlineShop.Persistence.EF.ParchaseInvoices;
using OnlineShop.Persistence.EF.ProductCategories;
using OnlineShop.Persistence.EF.Products;
using OnlineShop.Persistence.EF.StoreRooms;
using OnlineShop.Services.ParchaseInvoices;
using OnlineShop.Services.ParchaseInvoices.Contracs;
using OnlineShop.Services.ProductCategories;
using OnlineShop.Services.ProductCategories.Contracts;
using OnlineShop.Services.Products;
using OnlineShop.Services.Products.Contracts;
using OnlineShop.Services.StoreRooms;
using OnlineShop.Services.StoreRooms.Contracs;

namespace OnlineShop.RestApi
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
            services.AddControllers();

            services.AddScoped<EFDataContext>();
            services.AddScoped<UnitOfWork, EFUnitOfWork>();

            services.AddScoped<ProductCategoryRepository,EFProductCategoryRepository>();
            services.AddScoped<ProductCategoryService, ProductCategoryAppService>();

            services.AddScoped<ProductRepository, EFProductRepository>();
            services.AddScoped<ProductService, ProductAppService>();

            services.AddScoped<ParchaseInvoiceRepository, EFParchaseInvoiceRpository>();
            services.AddScoped<ParchaseInvoiceService, ParchaseInvoiceAppService>();

            services.AddScoped<StoreRoomRepository, EFStoreRoomRepository>();
            services.AddScoped<StoreRoomService, StoreRoomAppService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
