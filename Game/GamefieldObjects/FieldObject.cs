using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_with_AWS_MySQL
{
    /// <summary>
    /// The basis of all objects appearing on the game's field. 
    /// </summary>
    abstract class FieldObject
    {
        int x;
        int y;

        /// <summary>
        /// The appearence of the object on the field.
        /// </summary>
        protected Image img;

        protected FieldObject(int x, int y, Image img)
        {
            this.x = x;
            this.y = y;
            this.img = img;
        }

        /// <summary>
        /// Returns or sets the X coordinate of a FieldObject.
        /// </summary>
        public int X { get => x; set => x = value; }

        /// <summary>
        /// Returns or sets the Y coordinate of a FieldObject.
        /// </summary>
        public int Y { get => y; set => y = value; }

        /// <summary>
        /// Returns or sets the Image of a FieldObject.
        /// </summary>
        public Image Img { get => img; set => img = value; }




    }
}
