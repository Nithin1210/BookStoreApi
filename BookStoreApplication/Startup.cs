using BookStoreBusiness.Business;
using BookStoreBusiness.IBusiness;
using BookStoreRepository.IRepository;
using BookStoreRepository.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace BookStoreApplication
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

            //User
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserBusiness, UserBusiness>();
            //Book
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookBusiness, BookBusiness>();
            //WishList
            services.AddScoped<IWishlistRepository, WishlistRepository>();
            services.AddScoped<IWishlistBusiness, WishlistBusiness>();
            //Cart
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartBusiness, CartBusiness>();
            //CustomerDetails
            services.AddScoped<ICustomerDetailRepository, CustomerDetailRepository>();
            services.AddScoped<ICustomerDetailBusiness, CustomerDetailBusiness>();
            //FeedBack
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IFeedbackBusiness, FeedbackBusiness>();
            //OrderPlaced
            services.AddScoped<IOrderPlacedRepository, OrderPlacedRepository>();
            services.AddScoped<IOrderPlacedBusiness, OrderPlacedBusiness>();
            //OrderSummary
            services.AddScoped<IOrderSummaryRepository, OrderSummaryRepository>();
            services.AddScoped<IOrderSummaryBusiness, OrderSummaryBusiness>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Book Store App",
                    Version = "v1",
                    Description = "Book Store Application"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                     {
                         new OpenApiSecurityScheme
                         {
                             Reference = new OpenApiReference
                             {
                                 Type=ReferenceType.SecurityScheme,
                                 Id="Bearer"
                             }
                         },
                          new string[]{}
}
                 });

            });
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"])) //Configuration["JwtToken:SecretKey"]
                };
            });
            services.AddDistributedRedisCache(Options =>
            {
                Options.Configuration = "localhost:6379";
                Options.InstanceName = "BookStoreCache";
            });
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore App");
            });
        }
    }
}
