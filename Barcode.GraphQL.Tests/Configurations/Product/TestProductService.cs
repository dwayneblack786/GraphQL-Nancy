using System;
using System.Runtime.InteropServices;
using Barcode.Common.Model.Configuration;
using Barcode.GraphQL.Services;
using Microsoft.Extensions.Options;
using Microsoft.Win32.SafeHandles;

namespace Barcode.GraphQL.Tests.Configurations.Product
{
    public class TestProductService : ProductService, IDisposable
    {

        public bool Disposed;
        private readonly SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);
        public TestProductService(IOptions<Application> appConfiguration) : base(appConfiguration)
        {
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