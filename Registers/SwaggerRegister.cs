using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ServiceCore.Services
{
    public static class SwaggerRegister
    {
        public static void AddSwaggerRegister(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "EducationService - Fpt school system",
                    Description = "The EducationService classes, subjects, terms,.... all of things of education activities",
                    TermsOfService = new Uri("http://fschool.fpt.edu.vn/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Trong Thuc Nguyen",
                        Email = string.Empty,
                        Url = new Uri("https://www.facebook.com/nguyentrong.thuc2"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "FPT copyright",
                        Url = new Uri("http://fschool.fpt.edu.vn/"),
                    }
                });

                //Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}