using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            //工厂方法
            RectangleFactory rectangleFactory = new RectangleFactory();
            Shape rectangle1 = rectangleFactory.CreatShape(1.0, 2.0);
            Shape rectangle2 = rectangleFactory.CreatShape(4, 6);
            SquareFactory squareFactory = new SquareFactory();
            Shape square1 = squareFactory.CreatShape(4.0);
            Shape square2 = squareFactory.CreatShape(5);
            //简单工厂
            ShapeSimpleFactory simpleFactory = new ShapeSimpleFactory();
            for (int i = 0; i < 10; i++) {  
                Random ran = new Random();
                int side1 = ran.Next(1, 1000);
                Random ran2 = new Random();
                int side2 = ran2.Next(1, 1000);
                Random ran3 = new Random();
                int side3 = ran3.Next(1, 1000);
                Random ran4 = new Random();
                int type = ran4.Next(1,4);
                Shape ranShape=simpleFactory.CreatShape(type, side1, side2,side3);
                ranShape.Print();
                System.Threading.Thread.Sleep(2000);//延时避免生成相同的随机数

            }

        }
    }
    public interface Shape
    {
        double getArea();
        Boolean Judge();
        void Print();
    }

    //长方形
    public class Rectangle : Shape
    {
        public double height { get; set; }
        public double width { get; set; }
        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }
        public double getArea()
        {
            return this.height * this.width;
        }
        public Boolean Judge()
        {
            return this.height > 0 && this.width > 0;
        }
        public void Print()
        {
            if (this.Judge())
            {
                Console.WriteLine($"长方形：长为{height},宽为{width},面积为{getArea()}");
            }
            else
            {
                Console.WriteLine("设置的长度不合法");
            }
        }
    }

    //三角形
    public class Triangle : Shape
    {
        public double side1 { get; set; }
        public double side2 { get; set; }
        public double side3 { get; set; }
        public Triangle(double side1, double side2,double side3)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }
        public double getArea()
        {
            double p = (side1 + side2 + side3)/2;
            return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
        }
        public Boolean Judge()
        {
            return this.side1 > 0 && this.side2 > 0 && this.side3 > 0 && side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1;
        }
        public void Print()
        {
            if (this.Judge())
            {
                Console.WriteLine($"三角形：三条边为{side1}/{side2}/side{side3},面积为{getArea()}");
            }
            else
            {
                Console.WriteLine("设置的长度不合法");
            }
        }
    }
    public class Square : Shape
    {
        public double sideLength { get; set; }
        public Square(double sideLength)
        {
            this.sideLength = sideLength;
        }
        public double getArea()
        {
            return this.sideLength * this.sideLength;
        }
        public Boolean Judge()
        {
            return this.sideLength > 0;
        }
        public void Print()
        {
            if (this.Judge())
            {
                Console.WriteLine($"正方形：长为{sideLength},面积为{getArea()}");
            }
            else
            {
                Console.WriteLine("设置的长度不合法");
            }
        }
    }

    ////工厂抽象类
    //public interface Factory
    //{
    //    Shape CreatShape(double side1, double side2);
    //}
    //实现（工厂方法）
    public class RectangleFactory
    {

        public Shape CreatShape(double height, double width)
        {
            return new Rectangle(height, width);
        }
    }
    public class TriangleFactory
    {
        public Shape CreatShape(double side1, double side2,double side3)
        {
            return new Triangle(side1,side2,side3);
        }
    }

    public class SquareFactory
    {
        public Shape CreatShape(double side)
        {
            return new Square(side);
        }
    }

    //实现（简单工厂）
    public class ShapeSimpleFactory
    {
        public Shape CreatShape(int type,double side1,double side2,double side3)
        {
              switch (type)
                {
                
                    case 1:
                        return new Rectangle(side1, side2);

                    case 2:
                        return new Square(side1);

                    case 3:
                        return new Triangle(side1, side2,side3);
                default:
                    return null;
              }
        }
    }

}