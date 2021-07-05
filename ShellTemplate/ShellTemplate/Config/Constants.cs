using SQLite;

namespace ShellTemplate
{
    public static class Constants
    {
        public const string DBName = "template.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            //  open in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            //  create if doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            //  enable multi thread access
            SQLite.SQLiteOpenFlags.SharedCache;
    }
}
