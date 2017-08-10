using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace GeometryWars
{
    class Program
    {

        public enum MovementEnum
        {
            Up = 0,
            Right = 1,
            Down = 2,
            Left = 3
        };

        public static int windowWidth = Console.LargestWindowWidth;
        public static int windowHeigth= Console.LargestWindowHeight;

        public const ConsoleColor HERO_COLOR = ConsoleColor.DarkBlue;
        public const ConsoleColor BACKGROUND_COLOR = ConsoleColor.Black;

        public static Player hero;
        public static List<Enemy> enemies;

        public static float hSize = 5;
        public static float charAspect = 1.5f;
        //public static Coordinate heroSize = new Coordinate { X = (int)(hSize*charAspect), Y = (int)hSize };
        public static Entity bg;


        static void Main(string[] args)
        {
            InitConsole();
            InitGame();
            GenerateBG();
            do
            {
                Thread.Sleep(50);
                hero.updatePlayer();
                foreach (Enemy enemy in enemies) enemy.MoveEntity();
            } while (!hero.bIsAlive);
            //Console.ReadLine();
        }

        /// <summary>
        /// This method customizes the console
        /// </summary>
        /// <remarks>
        /// It is very important that you run the Clear() method after
        /// changing the background color since this causes a repaint of the background
        /// </remarks>
        static void InitConsole()
        {
            Console.Clear();//Clears the console(Deletes anything previously written on it)
            Console.BackgroundColor = BACKGROUND_COLOR;
            //Console.SetWindowSize(94, 84);//Sets the console size do its always the same
            //Console.CursorSize = 1;
            Console.SetWindowSize(windowWidth, windowHeigth);
            Console.CursorVisible = false;
            var fonts = ConsoleHelper.ConsoleFonts;
            ConsoleHelper.SetConsoleFont(0);
            ConsoleHelper.SetConsoleIcon(SystemIcons.Information);
            //Console.BackgroundColor = ConsoleColor.DarkRed;//Changes the background color
            //Console.ForegroundColor = ConsoleColor.White;//Changes the font color
            Console.Clear();//Clears the console(Deletes anything previously written on it)

            //for (int f = 0; f < fonts.Length; f++)Console.WriteLine("{0}: X={1}, Y={2}", fonts[f].Index, fonts[f].SizeX, fonts[f].SizeY);
        }

        /// <summary>
        /// Initiates the game by painting the background
        /// and initiating the hero
        /// </summary>
        static void InitGame()
        {
            enemies = new List<Enemy>();
            for (int i=0;i<4;i++)
                enemies.Add(new Enemy());
            //foreach (Enemy enemy in enemies) enemy.MoveEntity();
            hero = new Player()
            {
                sImageName = "H3.png",
                cCurrentEntityLocation = new Coordinate() { X = 0, Y = 0 },
                cNewEntityLocation = new Coordinate() { X = 0, Y = 0 },
                cEntitySize = new Coordinate() { X = (int)(hSize * charAspect), Y = (int)hSize }
                
            };
            hero.PlaceEntity();
        }



        static void GenerateBG()
        {
            bg = new Entity()
            {
                sImageName = "TitleScreen.png",
                cCurrentEntityLocation = new Coordinate() { X = 0, Y = 0 },
                cEntitySize = new Coordinate() { X = 240, Y = 94 }
            };
            bg.PlaceEntity();
        }
    }


}

