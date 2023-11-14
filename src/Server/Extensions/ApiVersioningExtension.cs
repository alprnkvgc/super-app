﻿using Microsoft.AspNetCore.Mvc.Versioning;

namespace Server.Extensions
{
    public static class ApiVersioningExtension
    {
        public static IServiceCollection AddAndConfigureApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                                new HeaderApiVersionReader("api-version"),
                                                                new MediaTypeApiVersionReader("api-version"));

            });


            services.AddVersionedApiExplorer(config =>
            {
                config.GroupNameFormat = "'v'VVV";
                config.SubstituteApiVersionInUrl = true;
            });


            return services;
        }
    }

}
