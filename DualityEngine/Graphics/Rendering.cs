using System;
using System.Collections.Generic;
using System.Text;

namespace DualityEngine.Graphics
{
    public class Rendering
    {
        public static void RenderSprite(Sprite sprite, double x, double y) 
        {
            int posX = (int)Math.Round(x * Console.WindowWidth);
            int posY = (int)Math.Round(y * Console.WindowHeight);
            
            for(int row = 0; row < sprite.Rows; ++row)
            {
                for(int column = 0; column < sprite.Columns; ++column)
                {
                    DrawCharAt(sprite.GetCharAt(row, column), posX + column, posY + row);
                }
            }
        }

        private static void DrawCharAt(char s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException){}
        }
    }
}