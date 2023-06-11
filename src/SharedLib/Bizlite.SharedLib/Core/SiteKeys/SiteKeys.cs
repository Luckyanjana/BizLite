using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizlite.SharedLib.Core.SiteKeys
{
    public static class SiteKeys
    {

        private static IConfigurationSection configuration;

        public static void Configure(IConfigurationSection _configuration)
        {
            configuration = _configuration;
        }
        public static string Domain => configuration["Domain"];




    }
}
