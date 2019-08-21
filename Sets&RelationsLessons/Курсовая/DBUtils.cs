using MySql.Data.MySqlClient;

namespace Sets_RelationsLessons
{
    class DBUtils
    {
        /// <summary>
        /// Получение соединения с базой данных
        /// </summary>
        /// <returns>содинение</returns>
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            uint port = 3306;
            string database = "mydb";
            string username = "root";
            string password = "nikahzokk";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
