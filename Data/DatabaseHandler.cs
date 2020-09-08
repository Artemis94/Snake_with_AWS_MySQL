using System;
using System.Collections.Generic;
using MySqlConnector;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_with_AWS_MySQL
{

    /// <summary>
    /// Contains the methods required for the database operations.
    /// </summary>
    class DatabaseHandler
    {
        private MySqlConnection conn;
        private static DatabaseHandler instance;

        private DatabaseHandler()
        {
            conn = new MySqlConnection("Server = ************.amazonaws.com; Port = 3306; Database = snake_data; Uid = user; Pwd =password; ");
            conn.Open();
        }



        /// <summary>
        /// Provides access to the DatabaseHandler object.
        /// </summary>
        public static DatabaseHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseHandler();
                }
                return instance;
            }
        }


        /// <summary>
        /// Inserts a new user to the database, if the given username or e-mail doesn't already exist in the database.
        /// </summary>
        /// <param name="username">String, user input.</param>
        /// <param name="email">String, user input.</param>
        /// <param name="password">String, user input.</param>
        /// <param name="full_name">String, user input.</param>
        /// <param name="birthdate">DateTime, user input.</param>
        /// <returns>True if the Insert is successful, returns False if the username or e-mail are already taken.</returns>
        public bool InsertUser(string username, string email, string password, string full_name, DateTime birthdate)
        {
                bool taken = SelectUsername(username, email);

                if (taken)
                    return false;
                
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO users(username, email, full_name, password, birthdate, users.rank, active) 
                                    VALUES(@username, @email, @full_name, @password, @birthdate, 1, true)";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@full_name", full_name);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@birthdate", birthdate);

                return cmd.ExecuteNonQuery()==1;
        }
        

        private bool SelectUsername(string username, string email)
        {
            bool exists = false;

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT username, email FROM users WHERE username=@username OR email=@email";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.ExecuteNonQuery();

            var reader1 = cmd.ExecuteReader();

            if (reader1.HasRows)
            {
                exists = true;        // The username and/or e-mail is already taken.
            }
            reader1.Close();

            return exists;            
        }


        /// <summary>
        /// Returns the user profile belonging to the username, if the given username and password are correct.
        /// </summary>
        /// <param name="username">String, user input.</param>
        /// <param name="password">String, user input.</param>
        /// <returns>A user object, if the username and password are correct, otherwise null.</returns>
        public User Login(string username, string password) {
            User u = null;

            var command = conn.CreateCommand();
            command.CommandText = "SELECT id, password FROM users WHERE username=@username and active=true";
            command.Parameters.AddWithValue("@username", username);
            command.ExecuteNonQuery();
            var reader1 = command.ExecuteReader();

            if (reader1.HasRows)
            {
                reader1.Read();

                if (PasswordHash.Validate(reader1.GetString(1), password))
                {
                    reader1.Close();

                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT id, username, password, email, full_name, birthdate, users.rank, active FROM users WHERE username=@username";
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();
                    var reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        u = new User(reader.GetInt32("id"), reader.GetString("username"),
                            reader.GetString("email"), reader.GetString("full_name"), reader.GetDateTime("birthdate"), reader.GetInt32("rank"), reader.GetBoolean("active"));
                        reader.Close();
                    }
                }
                else
                    reader1.Close();
            }
            else
                reader1.Close();

            return u;
        }


        /// <summary>
        /// Inserts a game into the database.
        /// </summary>
        /// <param name="o">GameObject, represents the game played, that the player wishes to save.</param>
        /// <returns>Returns true if the save was successful. </returns>
        public bool SaveGame(GameObject o) {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO games(user_id, time, difficulty, points) VALUES(@user_id, @time, @difficulty, @points)";
            cmd.Parameters.AddWithValue("@user_id", LoggedInUser.loggedinuser.Id);
            cmd.Parameters.AddWithValue("@time", o.Time);
            cmd.Parameters.AddWithValue("@difficulty", o.Difficulty);
            cmd.Parameters.AddWithValue("@points", o.Points);
            int i = cmd.ExecuteNonQuery();
            return i == 1;
        }

        /// <summary>
        /// Returns an ordered List of all games from the database that belog to the current user.
        /// </summary>
        /// <returns>A List of GameObject objects or null if there are no games found.</returns>
        public List<GameObject> LoadGames()
        {
            List<GameObject> games = new List<GameObject>();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id, time, difficulty, points FROM games WHERE user_id=@user_id ORDER BY difficulty ASC, points DESC;";
                cmd.Parameters.AddWithValue("@user_id", LoggedInUser.loggedinuser.Id);
                cmd.ExecuteNonQuery();
                var reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    games.Add(new GameObject(reader.GetInt32(0), reader.GetDateTime(1), reader.GetInt32(2), reader.GetInt32(3)));
                }

                reader.Close();
        
            if (games.Count != 0)
                    return games;
                return null;
        }

        /// <summary>
        /// Determines wheter or not the password entered belongs to the current user.
        /// </summary>
        /// <param name="pwd">String, user input.</param>
        /// <returns>True if the password is correct, otherwise false.</returns>
        public bool CorrectPassword(string pwd)
        {
            bool correct = false;

            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT password FROM users WHERE username=@username";
            cmd.Parameters.AddWithValue("@username", LoggedInUser.loggedinuser.Username);
            cmd.ExecuteNonQuery();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows) {
                reader.Read();
                if (PasswordHash.Validate(reader.GetString(0), pwd))
                    correct = true;
            }
            reader.Close();

            return correct;
        }

        /// <summary>
        /// Updates the current user with new information.
        /// </summary>
        /// <param name="username">String, user input</param>
        /// <param name="email">String, user input</param>
        /// <param name="fullname">String, user input</param>
        /// <param name="birthdate">DateTime, user input</param>
        /// <param name="rank">Integer, user input</param>
        /// <returns>
        /// 0 if the input username is already taken.
        /// 2 if the input e-mail is already in use by another account.
        /// 1 if the update was successful.
        /// </returns>
        public int UpdateUser(string username, string email, string fullname, DateTime birthdate, int rank)
        {
                if (!SelectUsername(username, LoggedInUser.loggedinuser.Id)) {
                    if (!SelectEmail(email, LoggedInUser.loggedinuser.Id)) {

                        var cmd = conn.CreateCommand();
                        cmd.CommandText = @"UPDATE users SET username=@username, email=@email, full_name=@full_name, birthdate=@birthdate , users.rank=@rank
                                  WHERE id=@id";
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@full_name", fullname);
                        cmd.Parameters.AddWithValue("@birthdate", birthdate);
                        cmd.Parameters.AddWithValue("@rank", rank);
                        cmd.Parameters.AddWithValue("@id", LoggedInUser.loggedinuser.Id);

                        return cmd.ExecuteNonQuery();
                    } else {
                        return 2;
                    }
                } else {
                    return 0;
                }
        }

        /// <summary>
        /// Updates the password that belogs to the current user.
        /// </summary>
        /// <param name="pwd">String, user input.</param>
        /// <returns>True if the update was successful, otherwise false.</returns>
        public bool UpdatePassword(string pwd)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE users SET password=@password WHERE id=@id";
            cmd.Parameters.AddWithValue("@password", pwd);
            cmd.Parameters.AddWithValue("@id", LoggedInUser.loggedinuser.Id);

            if (cmd.ExecuteNonQuery() == 1)
                return true;

            return false;            
        }


        /// <summary>
        /// Updates the password that belogs to the e-mail address.
        /// </summary>
        /// <param name="pwd">String, user input.</param>
        /// <returns>True if the update was successful, otherwise false.</returns>
        public bool UpdatePassword(string pwd, string email)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE users SET password=@password WHERE email=@email";
            cmd.Parameters.AddWithValue("@password", pwd);
            cmd.Parameters.AddWithValue("@email", email);

            if (cmd.ExecuteNonQuery() == 1)
                return true;

            return false;
        }

        /// <summary>
        /// Returns the highest point game of the selected game mode, for all users.
        /// </summary>
        /// <param name="difficulty"></param>
        /// <returns>A string List or null, if there are no games in the selectd category. </returns>
        public List<string> LoadGamesRanked(int difficulty)
        {
            List<string> games = new List<string>();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT u.id, u.username, MAX(g.points) as points, g.time FROM games g LEFT JOIN users u ON g.user_id = u.id WHERE g.difficulty = @difficulty GROUP BY u.id ORDER BY points DESC";
            cmd.Parameters.AddWithValue("@difficulty", difficulty);
            cmd.ExecuteNonQuery();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string s = (reader.GetInt32("id").ToString() + "#" + reader.GetString("username").ToString() + "#" + reader.GetDateTime("time").ToString() + "#" + reader.GetInt32("points").ToString());
                games.Add(s);
            }

            reader.Close();

            if (games.Count != 0)
                return games;
            return null;

        }

        /// <summary>
        /// Selects and returns all users from the database.
        /// </summary>
        /// <returns>A User List.</returns>
        public List<User> SelecAllUsers()
        {
            List<User> users = new List<User>();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id, username, email, full_name, birthdate, users.rank, active FROM users";
                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    users.Add(new User(reader.GetInt32("id"), reader.GetString("username"), reader.GetString("email"), reader.GetString("full_name"), reader.GetDateTime("birthdate"), reader.GetInt32("rank"), reader.GetBoolean("active")));
                }

            reader.Close();
            return users;
        }

        /// <summary>
        /// Updates a specific user with new information.
        /// </summary>
        /// <param name="id">Integer.</param>
        /// <param name="username">String, user input</param>
        /// <param name="email">String, user input</param>
        /// <param name="rank">Integer, user input</param>
        /// <param name="active">Bool</param>
        /// <returns>
        /// 0 if the input username is already taken.
        /// 2 if the input e-mail is already in use by another account.
        /// 1 if the update was successful.
        /// </returns>
        public int AdminUpdateUser(int id, string username, string email, int rank, bool active)
        {
                if (!SelectUsername(username, id)) {
                    if (!SelectEmail(email, id)) {
                        var cmd = conn.CreateCommand();
                        cmd.CommandText = @"UPDATE users SET username=@username, email=@email, users.rank=@rank, active=@active
                                  WHERE id=@id";
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@rank", rank);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@active", active);

                        return cmd.ExecuteNonQuery();
                    }
                    else {
                        return 2;
                    }
                } else
                    return 0;
        }

        /// <summary>
        /// Changes a specific user's password to the given parameter.
        /// </summary>
        /// <param name="id">Integer</param>
        /// <param name="pwd">String</param>
        /// <returns>1 if the change was successful.</returns>
        public int AdminResetUserPassword(int id, string pwd) {

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE users SET password=@pwd WHERE id=@id";
            cmd.Parameters.AddWithValue("@pwd", PasswordHash.Hash(pwd));
            cmd.Parameters.AddWithValue("@id", id);

            return cmd.ExecuteNonQuery();           

        }

        /// <summary>
        /// Determines if the username parameter already exists in the database aside from being with the id parameter.
        /// </summary>
        /// <param name="username">String, user input</param>
        /// <param name="id">String, user input</param>
        /// <returns>True if the username is already in use, otherwise false. </returns>
        private bool SelectUsername(string username, int id) {
                bool exists = false;        

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT username FROM users WHERE username=@username AND id!=@id;";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                var reader1 = cmd.ExecuteReader();

                if (reader1.HasRows) {
                    exists = true;
                }
                reader1.Close();

                return exists;

            
        }

        /// <summary>
        /// Determines if the email parameter already exists in the database aside from being with the id parameter.
        /// </summary>
        /// <param name="email">String, user input</param>
        /// <param name="id">String, user input</param>
        /// <returns>True if the e-mail address is already in use, otherwise false. </returns>
        private bool SelectEmail(string email, int id) {

            bool exists = false;

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT email FROM users WHERE email=@email AND id!=@id;";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            var reader1 = cmd.ExecuteReader();

            if (reader1.HasRows) {
                exists = true;
            }
            reader1.Close();

            return exists;
        }


        /// <summary>
        /// Determines if the email parameter exists in the database or not.
        /// </summary>
        /// <param name="email">String, user input</param>
        /// <param name="id">String, user input</param>
        /// <returns>True if the e-mail address is present. </returns>
        public bool SelectEmail(string email)
        {
            bool exists = false;

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT email FROM users WHERE email=@email;";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.ExecuteNonQuery();

            var reader1 = cmd.ExecuteReader();

            if (reader1.HasRows)
            {
                exists = true;
            }
            reader1.Close();

            return exists;
        }

        /// <summary>
        /// Determins how many users have Administrator rank.
        /// </summary>
        /// <returns>An integer number.</returns>
        public int SelectCountAdmins() {

            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(id) FROM users WHERE users.rank = 3";
            cmd.ExecuteNonQuery();

            var reader = cmd.ExecuteReader();
            reader.Read();
            int n = reader.GetInt32(0);
            reader.Close();

            return n;
        }

    }
}
