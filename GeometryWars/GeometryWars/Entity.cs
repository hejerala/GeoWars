using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GeometryWars
{
    /// <summary>
    /// Parent Class For Hero And Enemy 
    /// </summary>
    class Entity
    {
        public bool bIsAlive { get; set; }
        public string sImageName { get; set; }
        public Coordinate cCurrentEntityLocation { get; set; }
        public Coordinate cNewEntityLocation { get; set; }
        public Coordinate cEntitySize { get; set; }

        private string path;
        /// <summary>
        /// Make sure that the new coordinate is not placed outside the
        /// console window (since that will cause a runtime crash
        /// </summary>
        public bool CanMove()
        {
            if (cNewEntityLocation.X < 0 || cNewEntityLocation.X + cEntitySize.X >= Console.WindowWidth)
                return false;

            if (cNewEntityLocation.Y < 0 || cNewEntityLocation.Y + cEntitySize.Y >= Console.WindowHeight)
                return false;

            return true;
        }

        /// <summary>
        /// Make sure that the new coordinate is not placed outside the
        /// console window (since that will cause a runtime crash
        /// </summary>
        public bool DetectCollision(Entity checkCollision)
        {
            bool isColliding = true;
            if (!(cNewEntityLocation.X + cEntitySize.X < checkCollision.cNewEntityLocation.X) && !(cNewEntityLocation.X > checkCollision.cNewEntityLocation.X + checkCollision.cEntitySize.X))
            {
                if (!(cNewEntityLocation.Y + cEntitySize.Y < checkCollision.cNewEntityLocation.Y) && !(cNewEntityLocation.Y > checkCollision.cNewEntityLocation.Y + checkCollision.cEntitySize.Y))
                {
                    isColliding = false;
                }

                //if (cNewEntityLocation.Y + cEntitySize.Y < checkCollision.cNewEntityLocation.Y)
                //    isColliding = false;

                //if (cNewEntityLocation.Y > checkCollision.cNewEntityLocation.Y + checkCollision.cEntitySize.Y)
                //    isColliding = false;
            }



            //if (cNewEntityLocation.X + cEntitySize.X < checkCollision.cNewEntityLocation.X)
            //    isColliding = false;

            //if (cNewEntityLocation.X < checkCollision.cNewEntityLocation.X + checkCollision.cEntitySize.X)
            //    isColliding = false;

            //if (cNewEntityLocation.Y + cEntitySize.Y < checkCollision.cNewEntityLocation.Y)
            //    isColliding = false;

            //if (cNewEntityLocation.Y < checkCollision.cNewEntityLocation.Y + checkCollision.cEntitySize.Y)
            //    isColliding = false;

            //if (cNewEntityLocation.Y == checkCollision.cNewEntityLocation.Y && (cNewEntityLocation.X > checkCollision.cNewEntityLocation.X || cNewEntityLocation.X < checkCollision.cNewEntityLocation.X + checkCollision.cEntitySize.X))
            //    return false;

            //if (cNewEntityLocation.Y == checkCollision.cNewEntityLocation.Y && (cNewEntityLocation.X + cNewEntityLocation.X > checkCollision.cNewEntityLocation.X || cNewEntityLocation.X + cNewEntityLocation.X < checkCollision.cNewEntityLocation.X + checkCollision.cEntitySize.X))
            //    return false;



            //if (cNewEntityLocation.X + cEntitySize.X == checkCollision.cNewEntityLocation.X)
            //    return false;

            //if (cNewEntityLocation.Y + cEntitySize.Y == checkCollision.cNewEntityLocation.Y)
            //    return false;

            return isColliding;
        }

        /// <summary>
        /// Paint the new entity
        /// </summary>
        public virtual void MoveEntity()
        {
            if (CanMove())
            {
                EraseEntity();

                cCurrentEntityLocation = cNewEntityLocation;

                DrawEntity();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Paint the new entity with collision detection
        /// </summary>
        public virtual void MoveEntity(Entity checkCollision)
        {
            if (CanMove())
            {
                if (DetectCollision(checkCollision))
                {
                    EraseEntity();

                    cCurrentEntityLocation = cNewEntityLocation;

                    DrawEntity();
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Paints the entity on its starting position
        /// </summary>
        public virtual void PlaceEntity()
        {
            LoadImage();
            DrawEntity();
        }

        /// <summary>
        /// Overpaint the old entity
        /// </summary>
        public void EraseEntity()
        {
            //Console.BackgroundColor = BACKGROUND_COLOR;
            Console.ForegroundColor = Program.BACKGROUND_COLOR;

            for (int i = 0; i < cEntitySize.X; i++)
            {
                for (int j = 0; j < cEntitySize.Y; j++)
                {
                    Console.SetCursorPosition(cCurrentEntityLocation.X + i, cCurrentEntityLocation.Y + j);
                    Console.Write(" ");
                }

            }
        }



        public void LoadImage()
        {
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            _filePath = Directory.GetParent(_filePath).FullName;
            _filePath = Directory.GetParent(_filePath).FullName;
            path = _filePath + @"\images\" + sImageName;//The path for the source frames
        }
        public void DrawEntity()
        {

            Point location = new Point(cCurrentEntityLocation.X, cCurrentEntityLocation.Y); //top left corner of the image to be drawn
            Size imageSize = new Size(cEntitySize.X, cEntitySize.Y); //size in characters of the image to be drawn

            using (Graphics g = Graphics.FromHwnd(ConsoleHelper.GetConsoleWindow()))
            {
                using (Image image = Image.FromFile(path))
                {
                    Size fontSize = ConsoleHelper.GetConsoleFontSize();

                    // translating the character positions to pixels
                    Rectangle imageRect = new Rectangle(
                        location.X * fontSize.Width,
                        location.Y * fontSize.Height,
                        imageSize.Width * fontSize.Width,
                        imageSize.Height * fontSize.Height);
                    g.DrawImage(image, imageRect);
                }
            }
        }


    }
}
