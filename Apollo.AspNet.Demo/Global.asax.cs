﻿using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.ConfigAdapter;
using Com.Ctrip.Framework.Apollo.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Web;

namespace Apollo.AspNet.Demo
{
    public class Global : HttpApplication
    {
        public static IConfiguration Configuration { get; private set; }

        protected void Application_Start(object sender, EventArgs e)
        {
            YamlConfigAdapter.Register();

            Configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .AddApollo(ConfigurationManager.AppSettings["Apollo.AppId"], ConfigurationManager.AppSettings["Apollo.MetaServer"])
                .AddDefault(ConfigFileFormat.Xml)
                .AddDefault(ConfigFileFormat.Json)
                .AddDefault(ConfigFileFormat.Yml)
                .AddDefault(ConfigFileFormat.Yaml)
                .AddDefault()
                .Build();
        }
    }
}
