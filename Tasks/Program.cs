// See https://aka.ms/new-console-template for more information

//Console.WriteLine("Hello, World!");

using Lab10;
using System;
using Lab10.tests;

public class Program
{
    public static void Main(string[] args)
    {
        Test test = new Test();
        test.runTests(args);
    }
}
