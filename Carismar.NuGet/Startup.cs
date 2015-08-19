using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Carismar.NuGet.Startup))]

namespace Carismar.NuGet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
