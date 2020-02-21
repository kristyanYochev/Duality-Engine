using System;
using System.Collections.Generic;
using System.Text;

namespace DualityEngine.Graphics
{
    public class Rendering
    {
        public static void RenderSprite(Sprite sprite, double x, double y) 
        {
            Console.CursorVisible = false;
            int posX = (int)Math.Round(x * Console.WindowWidth);
            int posY = (int)Math.Round(y * Console.WindowHeight);
            
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
            Console.Clear();
        }

        private static void DrawCharAt(char c, int x, int y)
        {
            if ((0 <= x && x < Console.WindowWidth) && (0 <= y && y < Console.WindowHeight))
            {
                Console.SetCursorPosition(x, y);
                Console.Write(c);
            }
        }
    }
}