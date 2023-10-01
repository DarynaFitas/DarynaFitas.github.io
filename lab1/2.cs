using System;
using System.Collections.Generic;
using StackUtils;

namespace StackUtils
{

    public class IntegerStack
    {
        private List<int> stack;


        public IntegerStack()
        {
            stack = new List<int>();
        }

        public void Push(int value)
        {
            stack.Add(value);
        }


        public int Pop()
        {
            if (stack.Count == 0)
            {
                throw new InvalidOperationException("стек пустий");
            }

            int value = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return value;
        }

        public double CalculateAverageDivisibleByThree()
        {
            int sum = 0;
            int count = 0;

            foreach (int value in stack)
            {
                if (value % 3 == 0)
                {
                    sum += value;
                    count++;
                }
            }

            if (count == 0)
            {
                return -1;
            }

            return (double)sum / count;
        }
    }
}


public class Program
{
    public static void Main()
    {

        var stack = new IntegerStack();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);

        double average = stack.CalculateAverageDivisibleByThree();
        if (average == -1)
        {
            Console.WriteLine("Елементи, які діляться на три, не знайдені в стеку.");
        }
        else
        {
            Console.WriteLine($"Середнє значення елементів, що ділиться на три: {average}");
        }
        Console.WriteLine();


        var emptyStack = new IntegerStack();
        average = emptyStack.CalculateAverageDivisibleByThree();
        if (average == -1)
        {
            Console.WriteLine("Елементи, які діляться на три, не знайдені в стеку.");
        }
        else
        {
            Console.WriteLine($"Середнє значення елементів, що ділиться на три: {average}");
        }
    }
}