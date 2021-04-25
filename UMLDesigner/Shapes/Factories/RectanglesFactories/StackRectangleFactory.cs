﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLDesigner.Interfaces;
using UMLDesigner.Shapes.Rectangles;

namespace UMLDesigner.Shapes.Factories.RectanglesFactories
{
    public class StackRectangleFactory : IFactory
    {
        IRectangle _typeRectangle;
        public StackRectangleFactory()
        {
        }
        public IShape GetShape()
        {
            _typeRectangle = new StackRectangle();
            AbstractRectangle shape = new AbstractRectangle(_typeRectangle, "Stack");
            return shape;
        }
    }
}
