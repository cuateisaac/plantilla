using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HorasExtra.Utilities
{
    public class Connection
    {
        static IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        private static Connection _Instance = null;
        public string DB = configuration.GetConnectionString("SqlCon");
        public static Connection Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Connection();
                return _Instance;
            }
        }
    }
}
