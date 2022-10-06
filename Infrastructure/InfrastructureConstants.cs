using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace EmployeesListApp.Infrastructure
{
    public static class InfrastructureConstants
    {
        public static readonly string DatabaseFileName = "EmployeesApp.db3";

        public static readonly string DirectoryPath =
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.ReadOnly |
            SQLiteOpenFlags.SharedCache;
       
         public static string DatabasePath
            => Path.Combine(DirectoryPath, DatabaseFileName);
        
    }
}
