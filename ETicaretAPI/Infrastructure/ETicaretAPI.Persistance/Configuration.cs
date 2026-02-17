using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance
{
    static class Configuration
    {
        public static string ConnectionString 
        {
            get
            {
                ConfigurationManager configuraionManager = new();
                configuraionManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ETicaretAPI.API"));
                configuraionManager.AddJsonFile("appsettings.json");

                return configuraionManager.GetConnectionString("PostgreSQL");

            } 
        }
    }
}
