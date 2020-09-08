using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_with_AWS_MySQL
{
    
    /// <summary>
    /// Represents a play of the game.
    /// </summary>
    class GameObject
    {
        private int id;
        private DateTime time;
        private int difficulty;
        private int points;

        /// <summary>
        /// Initializes a new instance of the GameObject class.
        /// </summary>
        /// <param name="id">Integer number. The unique database id of the game.</param>
        /// <param name="time">DateTime, the time that the gamne was played.</param>
        /// <param name="difficulty">Integer number, representing the game mode. </param>
        /// <param name="points">Integer number, representing how many points the player achieved during the game.</param>
        public GameObject(int id, DateTime time, int difficulty, int points)
        {
            this.id = id;
            this.time = time;
            this.difficulty = difficulty;
            this.points = points;
        }
        /// <summary>
        /// The time that the gamne was played
        /// </summary>
        public DateTime Time { get => time; set => time = value; }

        /// <summary>
        /// Represents the game mode.
        /// </summary>
        public int Difficulty { get => difficulty; set => difficulty = value; }

        /// <summary>
        /// Represents how many points the player has achieved during the game.
        /// </summary>
        public int Points { get => points; set => points = value; }

    }
}
