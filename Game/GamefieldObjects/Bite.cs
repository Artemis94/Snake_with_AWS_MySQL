using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_with_AWS_MySQL
{
    /// <summary>
    /// The possible Bite types.
    /// </summary>
    enum BiteTypes
    {
        Apple,
        Pizza,
        Cheese,
        Mushroom
    }

    /// <summary>
    /// Represents the things on the field that the Snake can eat. 
    /// </summary>
    class Bite:FieldObject
    {
        private int points;
        BiteTypes biteType;

        /// <summary>
        /// Initializes a new instance of the Bite class. 
        /// </summary>
        /// <param name="x">An Integer number.</param>
        /// <param name="y">An Integer number.</param>
        /// <param name="img">An Image</param>
        /// <param name="points">An Integer number.</param>
        /// <param name="biteType">The ByteType</param>
        public Bite(int x, int y, Image img, int points, BiteTypes biteType):base(x,y,img)
        {
            this.points = points;
            this.biteType = biteType;
        }

        /// <summary>
        /// Gets and Sets how many points the bite is worth.
        /// </summary>
        public int Points { get => points; set => points = value; }

        /// <summary>
        /// Gets what the Bite is.
        /// </summary>
        internal BiteTypes BiteType { get => biteType; }
    }
}
