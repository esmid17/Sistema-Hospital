using Microsoft.Extensions.Configuration;
using System;

namespace CapaDatos
{
    public class ConexionSQL
    {
        public string cadena { get; set; }

        public ConexionSQL()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            IConfigurationRoot root = builder.Build();
            cadena = root.GetConnectionString("cn");
        }


    }
}
