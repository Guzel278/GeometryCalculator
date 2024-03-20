using GeometryCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GeometryCalculator.Controllers
{
    namespace ShapeCalculator.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class ShapeController : ControllerBase
        {
            [HttpGet]
            [Route("circle/{radius}")]
            public ActionResult<double> CalculateCircleArea(double radius)
            {
                if (radius <= 0)
                {
                    return BadRequest("Radius should be positive");
                }

                var circle = new Circle(radius);
                var area = circle.CalculateArea();
                return area;
            }

            [HttpGet]
            [Route("triangle/{side1}/{side2}/{side3}")]
            public ActionResult<double> CalculateTriangleArea(double side1, double side2, double side3)
            {           
                try
                {
                    if (side1 <= 0 || side2 <= 0 || side3 <= 0)
                    {
                        return BadRequest("Triangle sides should be positive");
                    }
                    var triangle = new Triangle(side1, side2, side3);
                    double area = triangle.CalculateArea();
                    return Ok(area);
                }
                catch (InvalidOperationException ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
