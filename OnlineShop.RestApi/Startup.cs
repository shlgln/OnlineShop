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
using OnlineShop.Persistence.EF.SaleInvoiceItems;
using OnlineShop.Persistence.EF.SaleInvoices;
using OnlineShop.Persistence.EF.StoreRooms;
using OnlineShop.Services.ParchaseInvoices;
using OnlineShop.Services.ParchaseInvoices.Contracs;
using OnlineShop.Services.ProductCategories;
using OnlineShop.Services.ProductCategories.Contracts;
using OnlineShop.Services.Products;
using OnlineShop.Services.Products.Contracts;
using OnlineShop.Services.SaleInvoiceItems;
using OnlineShop.Services.SaleInvoiceItems.Contracts;
using OnlineShop.Services.SaleInvoices;
using OnlineShop.Services.SaleInvoices.Contracts;
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

            services.AddScoped<SaleInvoiceRepository, EFSaleInvoiceRepository>();
            services.AddScoped<SaleInvoiceService, SaleInvoiceAppService>();

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


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
