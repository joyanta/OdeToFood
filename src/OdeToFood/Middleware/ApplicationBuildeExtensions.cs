using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuildeExtensions
    {
        public static IApplicationBuilder UseNodeModule( this IApplicationBuilder app, IHostingEnvironment env)
        {
            var path = Path.Combine( env.ContentRootPath, "node_modules" );
            var fileProvider = new PhysicalFileProvider(path);
            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
            options.FileProvider = fileProvider;
            app.UseStaticFiles(options);
            return app;
        }
    }
}
