using System;
using MySql.Data.MySqlClient;

namespace Sets_RelationsLessons
{
    class DBMySQLUtils
    {
        /// <summary>
        /// Получение соединения с базой данных
        /// </summary>
        /// <param name="host">хост</param>
        /// <param name="port">порт</param>
        /// <param name="database">название базы данных</param>
        /// <param name="username">имя пользователя</param>
        /// <param name="password">пароль</param>
        /// <returns>соединение</returns>
        public static MySqlConnection GetDBConnection(string host, uint port, string database, string username, string password)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Database = database,
                Password = password,
                Server = host,
                UserID = username,
                SslMode = MySqlSslMode.None,
                Port = port  
            };

            MySqlConnection conn = new MySqlConnection
            {
                ConnectionString = builder.ConnectionString                
            };

            return conn;
        }
    }
}
