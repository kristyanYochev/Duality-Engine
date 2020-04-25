using System;
using System.Collections.Generic;
using System.Text;
using DualityEngine.Exceptions;

namespace DualityEngine.Graphics
{
    public class Overlay
    {
        private Dictionary<string, UIElement> Elements { get; set; }

        public Overlay()
        {
            Elements = new Dictionary<string, UIElement>();
        }

        public void AddElement(string name, UIElement element)
        {
            Elements.Add(name, element);
        }

        public UIElement GetElement(string name)
        {
            UIElement element;
            if (!Elements.TryGetValue(name, out element))
            {
                throw new UIElementNotFoundException();
            }
            return element;
        }

        public void Render()
        {
            foreach(var element in Elements)
            {
                element.Value.Render();
            }
        }
    }
}
