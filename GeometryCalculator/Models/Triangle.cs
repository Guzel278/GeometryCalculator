using System;

namespace GeometryCalculator.Models
{
  public class Triangle : IShape
    {
        private double side1;
        private double side2;
        private double side3;

        public Triangle(double side1, double side2, double side3)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }

        public double CalculateArea()
        {

            if (!IsValidTriangle(side1, side2, side3))
            {
                throw new InvalidOperationException("Invalid triangle sides.");
            }

            if (IsRightTriangle())
            {
                // Если треугольник прямоугольный, вычисляем его площадь как половину произведения катета на высоту
                double cathetus1 = 0;
                double cathetus2 = 0;
                double hypotenuse = Math.Max(Math.Max(side1, side2), side3);

                if (side1 == hypotenuse)
                {
                    cathetus1 = side2;
                    cathetus2 = side3;
                }
                else if (side2 == hypotenuse)
                {
                    cathetus1 = side1;
                    cathetus2 = side3;
                }
                else if (side3 == hypotenuse)
                {
                    cathetus1 = side1;
                    cathetus2 = side2;
                }

                double area = 0.5 * cathetus1 * cathetus2;
                return Math.Round(area, 2);
            }
            else
            {
                //формула Герона для вычисления площади треугольника
                double s = (side1 + side2 + side3) / 2;
                return Math.Round(Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3)),2);
            }
        }

        private bool IsValidTriangle(double side1, double side2, double side3)
        {
            return side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1;
        }
        //по теореме Пифагора определим является ли треугольник прямоугольным
        private bool IsRightTriangle()
        {
            double[] sides = { side1, side2, side3 };
            Array.Sort(sides);
            return sides[0] * sides[0] + sides[1] * sides[1] == sides[2] * sides[2];
        }
    }
}

