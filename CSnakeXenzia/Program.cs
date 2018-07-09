using System;
using System.Collections.Generic;

namespace CSnakeXenzia
{
    class Program
    {
        static char [][] grid=new char[20][];
        static int height=20;
        static int width=50;
        static int wormx = 25;
        static int wormy=9;
        static List<position>position=new List<position>();
        static int snakelength = 3;

        private static bool isGameOver = false;
       
        
        

        static void Main(string[] args)
        {
            InitFrame();
            Drawframe();
            initsnake();
            DrawSnake();
            //Drawsnakehead();
            //DrawSnakebodyOnHead();
            

            while (!isGameOver)
            {
                Drawsnakehead();
                DrawSnakebodyOnHead();
                SnakeMotion();
            }
          
            Console.ReadKey();
           

        }
       
      
        private static void InitFrame()
        {
            Console.CursorVisible = false;
            for (int i = 0; i < height; i++)
            {
                grid[i] = new char[width];
            }

                grid[0][0] = '0';
                grid[0][width - 1] = '0';
                grid[height - 1][0] = '0';
                grid[height - 1][width - 1] = '0';
            for (int i =1; i < height-1; i++)
            {
                grid[i][0] = '|';
                grid[i][width - 1] = '|';
            }

            for (int i = 1; i < width-1; i++)
            {
                grid[0][i] = '=';
                grid[height - 1][i] = '=';
            }

            for (int k = 1; k < height-1; k++)
            {
                for (int c = 1; c <width-1; c++)
                {
                    grid[k][c] = ' ';
                    
                }  
            }
                
            
        }

        public static void Drawframe()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.SetCursorPosition(x,y);
                    Console.Write((grid[y][x]));
                }
            }
        }

        public static void Drawsnakehead()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(wormx,wormy);
            Console.Write('@');
        }

        public static void DrawSnakebodyOnHead()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(wormx,wormy);
            Console.Write('o');
        }

        public static void initsnake()
        {
            position.Add(new position{x=10,y=10});
            position.Add(new position{x=11,y=10});
            position.Add(new position{x=12,y=10});

            foreach (position pos in position)
            {
                grid[pos.y][pos.x] = '0';
            }
        }

        public static void DrawSnake()
        {
            int count = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var pos in position)
            {
               Console.SetCursorPosition(pos.x,pos.y);
                count++;
                if (count<3)
                {
                    Console.WriteLine('o');
                }
                else
                {
                    Console.WriteLine('o');
                }

            }
        }

        public static void SnakeMotion()
        {
            Console.SetCursorPosition(position[0].x,position[0].y);
            Console.Write(' ');

            if (position.Count!=snakelength)
            {
                grid[position[0].y][position[0].x] = ' ';
                    position.RemoveAt(0);
            }
        }


    }
    
   
}