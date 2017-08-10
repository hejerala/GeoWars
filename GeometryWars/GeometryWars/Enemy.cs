using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryWars
{
    /// <summary>
    /// Child Class Of Entity
    /// This is the enemy class
    /// </summary>
    class Enemy : Entity
    {
        private int movementCounter = 0;
        private int movementLimit = 5;
        private int movementLength = 5;
        //An enum to make the code more readable in the movement switch case
        private enum MovementEnum
        {
            Up = 0,
            Right = 1,
            Down = 2,
            Left = 3
        };
        private Random rLocationGenerator = new Random();
        public Enemy()
        {
            int positionX = rLocationGenerator.Next(0, Console.WindowWidth);
            int positionY = rLocationGenerator.Next(0, Console.WindowHeight);
            sImageName = "H2.png";
            cCurrentEntityLocation = new Coordinate() { X = positionX, Y = positionY  };
            cNewEntityLocation = new Coordinate() { X = positionX, Y = positionY  };
            cEntitySize = new Coordinate() { X = (int)(Program.hSize * Program.charAspect), Y = (int)Program.hSize };
            PlaceEntity();
        }

        public override void MoveEntity()
        {
            if (movementCounter == movementLimit)
            {
                switch (rLocationGenerator.Next(0, 4))
                {
                    case (int)MovementEnum.Up:
                        cNewEntityLocation = new Coordinate() { X = cCurrentEntityLocation.X + (0), Y = cCurrentEntityLocation.Y + (-movementLength) };
                        break;

                    case (int)MovementEnum.Right:
                        cNewEntityLocation = new Coordinate() { X = cCurrentEntityLocation.X + (movementLength), Y = cCurrentEntityLocation.Y + (0) };
                        break;

                    case (int)MovementEnum.Down:
                        cNewEntityLocation = new Coordinate() { X = cCurrentEntityLocation.X + (0), Y = cCurrentEntityLocation.Y + (movementLength) };
                        break;

                    case (int)MovementEnum.Left:
                        cNewEntityLocation = new Coordinate() { X = cCurrentEntityLocation.X + (-movementLength), Y = cCurrentEntityLocation.Y + (0) };
                        break;
                }
                base.MoveEntity();
                movementCounter = 0;
                //MoveEntity();
            }
            else
            {
                movementCounter++;
            }
        }
    }
}
