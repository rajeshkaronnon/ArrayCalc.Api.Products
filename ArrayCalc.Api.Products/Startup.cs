using Autofac;
using Autofac.Integration.WebApi;
using ArrayCalc.Api.Products.Services;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Reflection;
[assembly: OwinStartup(typeof(ArrayCalc.Api.Products.Startup))]
namespace ArrayCalc.Api.Products
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            var builder = new ContainerBuilder();

            // Register Web API controller in executing assembly.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register a product service to be used by the controller.
            builder.Register(c => new ProductService()).As<IProductService>().InstancePerRequest();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }
    }
}