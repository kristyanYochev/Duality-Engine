using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DualityEngine.Exceptions;

namespace DualityEngine.Graphics
{
    public class Sprite
    {
        public string Content { get; private set; }
        public int Columns { get; private set; }
        public int Rows { get; private set; }
        
        public char GetCharAt(int row, int column)
        {
            if (0 <= row && row < Rows && 0 <= column && column < Columns)
            {
                return Content[row * Columns + column];
            }
            throw new CoordinatesOutOfBoundsException();
        }

        public Sprite(string content, int row, int col)
        {
            Content = content;
            Rows = row;
            Columns = col;
        }


        public static Sprite ParseSprite(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            return new Sprite(String.Join("", lines), lines.Length, lines[0].Length);
        }
    }
}
