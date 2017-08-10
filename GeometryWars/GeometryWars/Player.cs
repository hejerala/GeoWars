using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryWars
{
    /// <summary>
    /// Child Class Of Entity
    /// This is the Hero Class
    /// This object is controlled by user inputs
    /// </summary>
    class Player : Entity
    {
        public static float hSize = 5;
        public static float bSize = 3;
        public static float charAspect = 1.5f;


        public void updatePlayer()
        {
            ConsoleKeyInfo keyInfo;
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                //((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        cNewEntityLocation = new Coordinate() { X = cCurrentEntityLocation.X + (0), Y = cCurrentEntityLocation.Y + (-1) };
                        break;

                    case ConsoleKey.D:
                        cNewEntityLocation = new Coordinate() { X = cCurrentEntityLocation.X + (1), Y = cCurrentEntityLocation.Y + (0) };
                        break;

                    case ConsoleKey.S:
                        cNewEntityLocation = new Coordinate() { X = cCurrentEntityLocation.X + (0), Y = cCurrentEntityLocation.Y + (1) };
                        break;

                    case ConsoleKey.A:
                        cNewEntityLocation = new Coordinate() { X = cCurrentEntityLocation.X + (-1), Y = cCurrentEntityLocation.Y + (0) };
                        break;

                    case ConsoleKey.RightArrow:
                        shootBullets(1);
                        break;

                    case ConsoleKey.LeftArrow:
                        shootBullets(3);
                        break;

                    case ConsoleKey.UpArrow:
                        shootBullets(0);
                        break;

                    case ConsoleKey.DownArrow:
                        shootBullets(2);
                        break;
                }
                //foreach (Enemy enemy in enemies) enemy.MoveEntity();
                //hero.MoveEntity();
                MoveEntity();
                //hero.MoveEntity(enemies.First());
            }
        }

        public void shootBullets(int direction)
        {
            Bullet bNewBullet = new Bullet
            {
                sImageName = "Bullet2.png",
                cCurrentEntityLocation = new Coordinate() { X = this.cCurrentEntityLocation.X, Y = this.cCurrentEntityLocation.Y },
                cNewEntityLocation = new Coordinate() { X = this.cCurrentEntityLocation.X, Y = this.cCurrentEntityLocation.Y },
                cEntitySize = new Coordinate() { X = (int)(bSize * charAspect), Y = (int)bSize }
            };
            //bNewBullet.LoadImage("Bullet2.png");
            bNewBullet.PlaceEntity();


            switch (direction)
            {
                

                case (int)Program.MovementEnum.Up:

                    while (bNewBullet.CanMove())
                    {
                       
                        bNewBullet.cNewEntityLocation = new Coordinate() { X = bNewBullet.cCurrentEntityLocation.X + (0), Y = bNewBullet.cCurrentEntityLocation.Y + (-1) };
                        bNewBullet.MoveEntity();
                    }
                    bNewBullet.EraseEntity();
                    DrawEntity();
                    break;

                case (int)Program.MovementEnum.Right:

                    
                    while (bNewBullet.CanMove())
                    {
                        
                        bNewBullet.cNewEntityLocation = new Coordinate() { X = bNewBullet.cCurrentEntityLocation.X + (1), Y = bNewBullet.cCurrentEntityLocation.Y + (0) };
                        bNewBullet.MoveEntity();
                    }
                    bNewBullet.EraseEntity();
                    DrawEntity();
                    break;

                case (int)Program.MovementEnum.Down:
                    while (bNewBullet.CanMove())
                    {
                      
                        bNewBullet.cNewEntityLocation = new Coordinate() { X = bNewBullet.cCurrentEntityLocation.X + (0), Y = bNewBullet.cCurrentEntityLocation.Y + (1) };
                        bNewBullet.MoveEntity();
                    }
                    bNewBullet.EraseEntity();
                    DrawEntity();
                    break;

                case (int)Program.MovementEnum.Left:
                    while (bNewBullet.CanMove())
                    {
                       
                        bNewBullet.cNewEntityLocation = new Coordinate() { X = bNewBullet.cCurrentEntityLocation.X + (-1), Y = bNewBullet.cCurrentEntityLocation.Y + (0) };
                        bNewBullet.MoveEntity();
                    }
                    bNewBullet.EraseEntity();
                    DrawEntity();
                    break;
            }

            
        }

    }
}
