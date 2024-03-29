[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Ddd.DotNet.MvcWebApi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Ddd.DotNet.MvcWebApi.App_Start.NinjectWebCommon), "Stop")]

namespace Ddd.DotNet.MvcWebApi.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ddd.DotNet.Application.Interface;
    using Ddd.DotNet.Application;
    using Ddd.DotNet.Domain.Services;
    using Ddd.DotNet.Domain.Interfaces;
    using Ddd.DotNet.Data.Repository;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IBaseAppService<>)).To(typeof(BaseAppService<>));
            kernel.Bind<IClienteAppService>().To<ClienteAppService>();

            kernel.Bind(typeof(IBaseService<>)).To(typeof(BaseService<>));
            kernel.Bind<IClientService>().To<ClientService>();

            kernel.Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<>));
            kernel.Bind<IClienteRepository>().To<ClientRepository>();
        }        
    }
}
