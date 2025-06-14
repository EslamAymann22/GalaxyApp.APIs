//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.OpenApi.Models;
//namespace GalaxyApp.APIs
//{
//    public static class SwaggerGenerator
//    {


//        public static IServiceCollection AddSwaggerGenerator(this IServiceCollection services, IConfiguration configuration)
//        {

//            services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GalaxyApp Project", Version = "v1" });
//                //c.EnableAnnotations();

//                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
//                {
//                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
//                    Name = "Authorization",
//                    In = ParameterLocation.Header,
//                    Type = SecuritySchemeType.ApiKey,
//                    Scheme = JwtBearerDefaults.AuthenticationScheme
//                });

//                c.AddSecurityRequirement(new OpenApiSecurityRequirement
//            {
//            {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = JwtBearerDefaults.AuthenticationScheme
//                }
//            },
//            Array.Empty<string>()
//            }
//           });
//            });

//            services.AddAuthorization(option =>
//            {
//                option.AddPolicy("CreateStudent", policy =>
//                {
//                    policy.RequireClaim("Create Student", "True");
//                });
//                option.AddPolicy("DeleteStudent", policy =>
//                {
//                    policy.RequireClaim("Delete Student", "True");
//                });
//                option.AddPolicy("EditStudent", policy =>
//                {
//                    policy.RequireClaim("Edit Student", "True");
//                });
//            });

//            return services;

//        }

//    }
//}
