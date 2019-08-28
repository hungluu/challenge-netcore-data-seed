using Autofac;
using DataGen.App.Controllers;
using DataGen.Business.Services;

namespace DataGen.App
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JsonGenService>().As<IJsonGenService>().InstancePerLifetimeScope();
            builder.RegisterType<TokenService>().As<ITokenService>().InstancePerLifetimeScope();
            builder.RegisterType<TemplateService>().As<ITemplateService>().InstancePerLifetimeScope();

            // For console app only
            builder.RegisterType<JsonController>().InstancePerLifetimeScope();
        }
    }
}
