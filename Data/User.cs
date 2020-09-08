using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_with_AWS_MySQL
{
    /// <summary>
    /// Represents a user.
    /// </summary>
    class User
    {
        private int id;
        private string username, email, full_name;
        private int rank;
        private DateTime birthdate;
        private int game_difficulty;
        private bool active;

        /// <summary>
        /// Initializes a new instance of the User class.
        /// </summary>
        /// <param name="id">An integer number. The database id of the user.</param>
        /// <param name="username">A string, the users unique username.</param>
        /// <param name="email">A string, the users unique e-mail address.</param>
        /// <param name="full_name">A string, the user's full name.</param>
        /// <param name="birthdate">A DateTime date, the users date of birth.</param>
        /// <param name="rank">An integer number, representing the user's rank.</param>
        /// <param name="active">A bool variable, representing wheter or not the user is active.</param>
        public User(int id, string username, string email, string full_name, DateTime birthdate, int rank, bool active)
        {
            this.id = id;
            this.username = username;
            this.email = email;
            this.full_name = full_name;
            this.birthdate = birthdate;
            this.rank = rank;
            this.game_difficulty = 4;
            this.active = active;
        }

        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public string Full_name { get => full_name; set => full_name = value; }
        public DateTime Birthdate { get => birthdate; set => birthdate = value; }
        public int Id { get => id; }
        public int Rank { get => rank; set => rank = value; }
        public int Game_difficulty { get => game_difficulty; set => game_difficulty=value; }
        public bool Active { get => active; set => active=value; }
    }



}
