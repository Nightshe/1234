using System;

namespace MathCalculator
{
    public class Addition
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
    }

    public class Subtraction
    {
        public double Subtract(double a, double b)
        {
            return a - b;
        }
    }

    public class Multiplication
    {
        public double Multiply(double a, double b)
        {
            return a * b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Addition addition = new Addition();
            Subtraction subtraction = new Subtraction();
            Multiplication multiplication = new Multiplication();

            double num1 = 10;
            double num2 = 5;

            Console.WriteLine($"Addition: {num1} + {num2} = {addition.Add(num1, num2)}");
            Console.WriteLine($"Subtraction: {num1} - {num2} = {subtraction.Subtract(num1, num2)}");
            Console.WriteLine($"Multiplication: {num1} * {num2} = {multiplication.Multiply(num1, num2)}");

            Console.ReadLine();
        }
    }
}
