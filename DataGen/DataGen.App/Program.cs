using CommandLine;
using DataGen.App.Controllers;
using DataGen.App.Infrastructure.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using Autofac;
using AutoMapper;
using DataGen.App.ViewModels;
using System.Collections.Generic;

namespace DataGen.App
{
    class Program
    {
        static int Main(string[] args)
        {
            var startup = new Startup();
            var services = new ServiceCollection();
            var builder = new ContainerBuilder();

            startup.ConfigureContainer(builder);
            startup.ConfigureMapper(services);

            var container = builder.Build();
            var scope = container.BeginLifetimeScope();
            
            int returnedCode = Parser.Default.ParseArguments<JsonOptions>(args)
                .MapResult(
                    (JsonOptions opts) => {
                        JsonController controller = scope.Resolve<JsonController>();

                        controller.GetIndex(Mapper.Map<JsonViewModel>(opts)).Wait();

                        Environment.Exit(0);
                        return 0;
                    },
                    errs => HandleErrors(errs));

            return returnedCode;
        }

        public static int HandleErrors (IEnumerable<Error> errs)
        {
            foreach (Error err in errs)
            {
                Console.WriteLine(err.ToString());
            }
            Console.ReadLine();

            return 1;
        }
    }
}
