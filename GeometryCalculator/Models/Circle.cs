using System;

namespace GeometryCalculator.Models
{
    public class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double CalculateArea()
        {
            double area = Math.PI * radius * radius;
            return Math.Round(area, 2); 
        }
    }
}
