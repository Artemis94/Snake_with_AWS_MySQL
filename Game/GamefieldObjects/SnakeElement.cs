using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_with_AWS_MySQL
{

    /// <summary>
    /// Represents a piece of the snake.
    /// </summary>
    class SnakeElement : FieldObject
    {
        int direction;

        /// <summary>
        /// Initializes a new instance of the SnakeElement class. 
        /// </summary>
        /// <param name="x">An Integer number.</param>
        /// <param name="y">An Integer number.</param>
        /// <param name="img">An Image</param>
        /// <param name="direction">An Integer number.</param>
        public SnakeElement(int x, int y, Image img, int direction):base(x,y,img)
        {
            this.direction = direction;
        }

        /// <summary>
        /// Returns in which direction the SnakeElement will move next.
        /// </summary>
        public int Direction { get => direction; set => direction = value; }



    }
}
