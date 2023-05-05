using System;
using System.Collections.Generic;
using System.Text;

namespace ООО_ФЛОРИСТ_1.Classes
{
    class Connection
    {
        public static MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection("server = localhost; uid = root; pwd = 2004; database = florist");
    }
}
