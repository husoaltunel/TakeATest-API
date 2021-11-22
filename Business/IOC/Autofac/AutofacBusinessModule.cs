using Autofac;
using Core.Utilities.Hashing;
using Core.Utilities.Hashing.Abstract;
using Core.Utilities.Security.Abstract;
using Core.Utilities.Security.Jwt;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace Business.IOC.Autofac
{
    public class AutofacBusinessModule : Module
    {
        private readonly IConfiguration _configuration;
        public AutofacBusinessModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<IDbConnection>(connection => new SQLiteConnection(_configuration.GetConnectionString("SqliteConnectionString")));
            builder.RegisterType<HashingHelper>().As<IHashingHelper>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            base.Load(builder);
        }
    }
}
