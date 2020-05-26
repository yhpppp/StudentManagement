using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace StudentManagement
{
    public class Startup
    {
        private IConfiguration  _configration;

        public Startup(IConfiguration configuration)
        {
            _configration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
        
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            /*
            //自定义指定为默认文档
            DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames.Clear();
            defaultFilesOptions.DefaultFileNames.Add("test.html");
            //添加默认文件中间件
            app.UseDefaultFiles(defaultFilesOptions);
            */
            /*
            // 添加默认文件中间件
            app.UseDefaultFiles();
            // 添加静态文件中间件
            app.UseStaticFiles();
            */

            // UseFileServer 结合了UseStaticFiles，UseDefaultFiles和UseDirectoryBrowser中间件的功能。

            app.UseFileServer();
            app.Use(async (context, next) =>
            {
                // 处理乱码
                context.Response.ContentType = "text/plain; charset=utf-8";

                // 获取当前进程名称
                string name = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

                // 获取appsettings.json中的MyKey
                string MyKey = _configration["MyKey"];
                //await context.Response.WriteAsync("1-middleware");
                await next();
            });

            //终端中间件
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(env.EnvironmentName);
                //await context.Response.WriteAsync("2-terminal middleware");

            });

        }
    }
}
