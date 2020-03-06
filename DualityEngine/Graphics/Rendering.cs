using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace DualityEngine.Graphics
{
    public class Rendering
    {
        private static string[] VirtualScreen { get; set; }
        private static Stream stdout;
        private static int ScreenWidth;
        private static int ScreenHeight;

        public static void Setup()
        {
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;
            ScreenWidth = Console.WindowWidth;
            ScreenHeight = Console.WindowHeight;
            stdout = Console.OpenStandardOutput(ScreenWidth * ScreenHeight);
            VirtualScreen = new string[ScreenHeight];
            Console.CursorVisible = false;
        }

        public static void Teardown()
        {
            stdout.Close();
        }

        public static void RenderSprite(Sprite sprite, double x, double y) 
        {
            int posX = (int)Math.Round(x * ScreenWidth);
            int posY = (int)Math.Round(y * ScreenHeight);
            
            for(int row = 0; row < sprite.Rows; ++row)
            {
                for(int column = 0; column < sprite.Columns; ++column)
                {
                    DrawCharAt(sprite.GetCharAt(row, column), posX + column, posY + row);
                }
            }
            Console.Out.Flush();
        }

        public static void ClearScreen()
        {
            for (uint y = 0; y < VirtualScreen.GetLength(0); ++y)
            {
                VirtualScreen[y] = new string(' ', ScreenWidth);
            }
        }

        public static void Flip()
        {
            string ScreenString = string.Join("\n", VirtualScreen);
            stdout.Write(Encoding.ASCII.GetBytes(ScreenString), 0, ScreenString.Length);
        }

        private static void DrawCharAt(char c, int x, int y)
        {
            if ((0 <= x && x < ScreenWidth) && (0 <= y && y < ScreenHeight))
            {
                char[] charArr = VirtualScreen[y].ToCharArray();
                charArr[x] = c;
                VirtualScreen[y] = new string(charArr);
            }
        }
    }
}