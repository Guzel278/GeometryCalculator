using GeometryCalculator.Controllers.ShapeCalculator.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;

namespace ShapeCalculator.Tests
{
    public class Tests
    {
        [TestFixture]
        public class ShapeControllerTests
        {
            [Test]
            public void CalculateCircleArea_ReturnsCorrectArea()
            {
                double radius = 10;
                var controller = new ShapeController();

                double result = controller.CalculateCircleArea(radius).Value;

                Assert.AreEqual(314.16, result, 0.01);
            }

            [Test]
            public void CalculateTriangleArea_RightTriangle_ReturnsCorrectArea()
            {
                double side1 = 3.0;
                double side2 = 4.0;
                double side3 = 5.0;
                var controller = new ShapeController();

                var result = controller.CalculateTriangleArea(side1, side2, side3).Value;

                Assert.AreEqual(6.00, result);
            }

            [Test]
            public void CalculateTriangleArea_NotRightTriangle_ReturnsCorrectArea()
            {

                double side1 = 4.0;
                double side2 = 4.0;
                double side3 = 5.0;
                var controller = new ShapeController();

                var result = controller.CalculateTriangleArea(side1, side2, side3).Value;

                Assert.AreEqual(7.81, result);
            }
            [Test]
            public void CalculateCircleArea_WithNegativeRadius_ReturnsBadRequest()
            {
                double radius = -5.0;
                var controller = new ShapeController();

                var result = controller.CalculateCircleArea(radius).Value;

                Assert.AreEqual(0, result);
            }

            [Test]
            public void CalculateTriangleArea_WithNegativeSides_ReturnsBadRequest()
            {
                double side1 = 3.0;
                double side2 = -4.0;
                double side3 = 5.0;
                var controller = new ShapeController();

                var result = controller.CalculateTriangleArea(side1, side2, side3).Value;

                Assert.AreEqual(0, result);
            }

            [Test]
            public void CalculateTriangleArea_WithInvalidTriangleSides_ReturnsBadRequest()
            {

                double side1 = 1.0;
                double side2 = 2.0;
                double side3 = 10.0;
                var controller = new ShapeController();

                Assert.Throws<InvalidOperationException>(() => controller.CalculateTriangleArea(side1, side2, side3));
            }
        
        }
    }
}