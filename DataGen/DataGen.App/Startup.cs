using Autofac;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DataGen.App
{
    class Startup
    {
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule());
        }

        public void ConfigureMapper(IServiceCollection services)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<AutoMapperProfile>();
            });
        }
    }
}
