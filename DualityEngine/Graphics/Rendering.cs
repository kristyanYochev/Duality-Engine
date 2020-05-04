using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using DualityEngine.Interfaces;
using DualityEngine.Mathf;
using DualityEngine.Implementations;

namespace DualityEngine.Graphics
{
    public class Rendering
    {
        private static string[] VirtualScreen { get; set; }
        private static IConsole console;
        private static Stream stdout;
        private static int ScreenWidth;
        private static int ScreenHeight;

        public static void Setup(IConsole console)
        {
            Rendering.console = console;
            // Make Console fullscreen only on windows (*nix doesn't support that)
            switch(Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    Rendering.console.WindowWidth = Rendering.console.LargestWindowWidth;
                    Rendering.console.WindowHeight = Rendering.console.LargestWindowHeight;
                    break;
                default:
                    break;
            }
            ScreenWidth = Rendering.console.WindowWidth;
            ScreenHeight = Rendering.console.WindowHeight;
            stdout = Rendering.console.OpenStandardOutput(ScreenWidth * ScreenHeight);
            VirtualScreen = new string[ScreenHeight];
            Rendering.console.CursorVisible = false;
        }
        public static void Setup()
        {
            console = new Implementations.Console();
            // Make Console fullscreen only on windows (*nix doesn't support that)
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    console.WindowWidth = console.LargestWindowWidth;
                    console.WindowHeight = console.LargestWindowHeight;
                    break;
                default:
                    break;
            }
            ScreenWidth = console.WindowWidth;
            ScreenHeight = console.WindowHeight;
            stdout = console.OpenStandardOutput(ScreenWidth * ScreenHeight);
            VirtualScreen = new string[ScreenHeight];
            console.CursorVisible = false;
        }

        public static void Teardown()
        {
            stdout.Close();
            console.CursorVisible = true;
        }

        public static void RenderSprite(Sprite sprite, Vector2Int position) 
        {
            for(int row = 0; row < sprite.Rows; ++row)
            {
                for(int column = 0; column < sprite.Columns; ++column)
                {
                    DrawCharAt(sprite.GetCharAt(row, column), position.X + column, position.Y + row);
                }
            }
            //Console.Out.Flush();
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
            switch(Environment.OSVersion.Platform)
            {
                case PlatformID.MacOSX:
                case PlatformID.Unix:
                    console.Clear();
                    break;
            }
            string ScreenString = string.Join("\n", VirtualScreen);
            stdout.Write(Encoding.ASCII.GetBytes(ScreenString), 0, ScreenString.Length);
            stdout.Flush();
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