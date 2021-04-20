﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLDesigner.Interfaces;
using UMLDesigner.Shapes.Rectangles;

namespace UMLDesigner
{
    class AbstractRectangle : IShape
    {
        public IRectangle _typeRectangle;
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Color Color { get; set; }
        public int PenWidth { get; set; }
        public Font NameFont = new Font("Arial", 18);
        public Font ArgumentFont = new Font("Arial", 16);        

        public int line = 4;

        public bool _endCreate = false;
        public AbstractRectangle(IRectangle typeRectangle)
        {
            _typeRectangle = typeRectangle;
            _endCreate = false;
            Color = Color.Black;
            PenWidth = 1;
            EndPoint = new Point(160, 220);
        }

        public void Draw()
        {
            _typeRectangle.Draw(Color, PenWidth, StartPoint, EndPoint, 4, NameFont, ArgumentFont);
        }

        public void OnMouseDown(MouseEventArgs e, List<IShape> shapes)
        {
            StartPoint = e.Location;
            Draw();
            _endCreate = true;
        }

        public void OnMouseMove(MouseEventArgs e, List<IShape> shapes)
        {
            if (_endCreate == false)
            {
                DrawDashEntity(Color.Black, 1, MyGraphics.GetInstance().GetTmpGraphics(), e.Location, new Point(160, 220));
                MyGraphics.GetInstance().SetImageToTmpBitmap();
            }
            else
            {
                Draw();
                MyGraphics.GetInstance().SetTmpBitmapAsMain();

            }
        }

        public void OnMouseUp(MouseEventArgs e)
        {
     
        }

        public static void DrawDashEntity(Color color, float penWidth, Graphics graphics, Point startPoint, Point size)
        {
            Pen _pen = new Pen(color, penWidth);
            float[] dashPattern = new float[2] { 5f, 5f };
            _pen.DashPattern = dashPattern;
            graphics.DrawRectangle(_pen, startPoint.X, startPoint.Y, size.X, size.Y);
        }
    }
}