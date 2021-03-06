﻿using System;
using System.Collections.Generic;
using System.Text;
using DualityEngine.Mathf;

namespace DualityEngine.Graphics
{
    public interface UIElement
    {
        string Content { get; set; }
        Vector2Int Position { get; set; }
        void Render();
    }
}
