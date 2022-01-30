using System;
using System.IO;

public static class Constants
{
    public const string DatabaseFilename = "TodoSQLite.db3";

    public const SQLite.SQLiteOpenFlags Flags =
        //Open the database with read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        //Create the database if it does not exist
        SQLite.SQLiteOpenFlags.Create |
        //Enable multi-thread database access
        SQLite.SQLiteOpenFlags.SharedCache;

    public static string DatabasePath
    {
        get
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(basePath, DatabaseFilename);
        }
    }
}