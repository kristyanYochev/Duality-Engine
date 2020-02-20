using System;
using System.Collections.Generic;
using System.Text;

namespace DualityEngine.Graphics
{
    public class Sprite
    {
        public string Content { get; private set; }
        public int Columns { get; private set; }
        public int Rows { get; private set; }
        
        public char GetCharAt(int row, int column)
        {
            return Content[row * Columns + column];
        }

        public Sprite(string content, int row, int col)
        {
            Content = content;
            Rows = row;
            Columns = col;
        }
    }
}
