using System;
namespace RuneCube
{
    public class HerokuConnectionStringGetter
    {
        public static string GetHerokuConnectionString() 
        {
            string con = Environment.GetEnvironmentVariable("DATABASE_URL");
            string[] arr = con.Split(":");
            string userId = arr[1].Substring(2);
            string[] hostPasswordArr = arr[2].Split("@");
            string password = hostPasswordArr[0];
            string host = hostPasswordArr[1];
            string[] portDbArr = arr[3].Split("/");
            string port = portDbArr[0];
            string database = portDbArr[1];
            string conectionString = $"User ID={userId};Password={password};" +
                $"Host={host};Port={port};Database={database};" +
                $"Pooling=true;SSL Mode=Require;TrustServerCertificate=True";
            return conectionString;
        }
    }
}
