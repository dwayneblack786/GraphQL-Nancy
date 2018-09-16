using System;
using System.Runtime.InteropServices;
using Barcode.GraphQL.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32.SafeHandles;
using ServiceProvider = Barcode.GraphQL.Tests.Configurations.Base.ServiceProvider;

namespace Barcode.GraphQL.Tests.Configurations.Providers
{
    public class TestServiceProvider : IServiceProvider, IDisposable
    {
        public IConfigurationRoot Configuration { get; set; }
        private readonly IServiceProvider _serviceProvider;
        public bool Disposed;
        private readonly SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);

        public TestServiceProvider()
        {
            var services = new ServiceProvider().ServiceCollection;


            //Services = services;
            var bootstrapper = new BootstrapManager(services);

            _serviceProvider = ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(services);

        }
        public object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
                return;

            if (disposing)
            {
                _handle.Dispose();
            }

            Disposed = true;
        }
    }
}


