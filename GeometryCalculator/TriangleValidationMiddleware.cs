namespace GeometryCalculator
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Threading.Tasks;

    public class TriangleValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public TriangleValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Получаем параметры запроса
            double.TryParse(context.Request.Query["side1"], out double side1);
            double.TryParse(context.Request.Query["side2"], out double side2);
            double.TryParse(context.Request.Query["side3"], out double side3);

            // Проверяем валидность треугольника
            if (!IsValidTriangle(side1, side2, side3))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Invalid triangle sides.");
                return;
            }

            await _next(context);
        }

        private bool IsValidTriangle(double side1, double side2, double side3)
        {
            return side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1;
        }
    }

}
