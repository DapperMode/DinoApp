using Practice.Entities;
using Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Models;
using Practice.Services;
using Practice.EF;
using Practice.Services.DataTransferObjects;

namespace Practice
{
    class Program
    {
        delegate int pointTo(int[] x);
        static void Main(string[] args)
        {
            //--------------------------------------------------
            // testing dino services
            DinoService service = new DinoService();

            DTODinoCollection testCollection = new DTODinoCollection();

            testCollection = service.GetDinoCollection();

            foreach (var d in testCollection)
            {
                Console.WriteLine(string.Format("NAME: {0} HEALTH: {1}", d.Name, d.Health));
                Console.WriteLine();
            }

            DTODino testDino = service.GetDinoItem("1");
            Console.WriteLine("NAME: " + testDino.Name + " STAMINA: " + testDino.Stamina);

            Console.ReadLine();

            //--------------------------------------------------

            ////--------------------------------------------------
            //// String comparisons and the equality operators - RESEARCH

            //String s1 = "test";
            //String s2 = new String(new char[] {'t','e','s','t'});
            //String s3 = "test1".Substring(0, 4);
            //object s4 = s3;

            //Console.WriteLine("Tests for s1");
            //Console.WriteLine("{0} {1} {2}", object.ReferenceEquals(s1, s2), s1 == s2, s1.Equals(s2));
            //Console.WriteLine("{0} {1} {2}", object.ReferenceEquals(s1, s3), s1 == s3, s1.Equals(s3));
            //Console.WriteLine("{0} {1} {2}", object.ReferenceEquals(s1, s4), s1 == s4, s1.Equals(s4));

            //Console.WriteLine();
            //Console.WriteLine("Tests for s2");
            //Console.WriteLine("{0} {1} {2}", object.ReferenceEquals(s2, s1), s2 == s1, s2.Equals(s1));
            //Console.WriteLine("{0} {1} {2}", object.ReferenceEquals(s2, s3), s2 == s3, s2.Equals(s3));
            //Console.WriteLine("{0} {1} {2}", object.ReferenceEquals(s2, s4), s2 == s4, s2.Equals(s4));

            //Console.WriteLine();
            //Console.WriteLine("Tests for s3");
            //Console.WriteLine("{0} {1} {2}", object.ReferenceEquals(s3, s1), s3 == s1, s3.Equals(s1));
            //Console.WriteLine("{0} {1} {2}", object.ReferenceEquals(s3, s2), s3 == s2, s3.Equals(s2));
            //Console.WriteLine("{0} {1} {2}", object.ReferenceEquals(s3, s4), s3 == s4, s3.Equals(s4));

            //Console.WriteLine();
            //Console.WriteLine("Tests for s4");
            //Console.WriteLine("{0} {1} {2}", object.ReferenceEquals(s4, s1), s4 == s1, s4.Equals(s1));
            //Console.WriteLine("{0} {1} {2}", object.ReferenceEquals(s4, s2), s4 == s2, s4.Equals(s2));
            //Console.WriteLine("{0} {1} {2}", object.ReferenceEquals(s4, s3), s4 == s3, s4.Equals(s3));
            //Console.WriteLine();

            ////--------------------------------------------------

            ////--------------------------------------------------

            //bool active = true;

            //while (active == true)
            //{
            //    Console.WriteLine("Enter a number: ");
            //    float x = Console.ReadLine().ToInt();

            //    Console.WriteLine("Enter a second number: ");
            //    float y = Console.ReadLine().ToInt();

            //    MyClass testClass = new MyClass();
            //    Console.WriteLine("The multiplication of these numbers yealds: " + testClass.Multiply(x, y)); // method declared and implemented in inherited abstract class
            //    Console.WriteLine();
            //    Console.WriteLine("And the division of both numbers yields: " + testClass.Divide(x, y)); // method declared in abstract class, but implemented in inheriting class
            //    Console.WriteLine();
            //    Console.WriteLine("Finally, the subtraction of these two numbers is: " + testClass.Subtract(x, y)); // method declared in Interface and implemented in inheriting class
            //    Console.WriteLine();

            //    Console.WriteLine("Hit enter to restart or enter "+ "Q " + "to quit");
            //    string choice = Console.ReadLine().ToUpper();
            //    if (choice == "Q")
            //    {
            //        active = false;
            //    }

            //    Console.Clear();
            //}

            ////--------------------------------------------------

            ////--------------------------------------------------
            //Drawing testDrawing = new Drawing(5); //passing in an ID for the constructor to generate a demo collection of picks within the drawing

            //Console.WriteLine("Drawing of ID: " + testDrawing.DrawingID + " contains the following values for Picks: ");
            //foreach (Pick item in testDrawing.Picks)
            //{
            //    Console.WriteLine("PickID: "+ item.PickID + " Pick Value: "+ item.Value);
            //}
            //Console.WriteLine();
            ////--------------------------------------------------

            ////--------------------------------------------------
            ////Given a collection of intergers,  write a C# method to total all the values that are even numbers
            //List<int> intList = new List<int> { 1, 20, 30, 11, 6, 0, 13, 22 };
            //int[] intArray = { 1, 20, 30, 11, 6, 0, 13, 22 };
            //pointTo obj = GetEven;

            //Console.WriteLine("The total of all even numbers in the list is: " + GetEvenTotal(intList)); // using foreach loop
            //Console.WriteLine();
            //Console.WriteLine("The total of all even numbers in the array is: " + GetEvenTotal(intArray)); // using lambda expression
            //Console.WriteLine();
            //Console.WriteLine("The total of all even numbers in the array is: " + GetEven(intArray)); // using LINQ statement
            //Console.WriteLine();
            //Console.WriteLine("The total of all even numbers in the array is: " + obj.Invoke(intArray)); // using delagate method

            ////--------------------------------------------------

            ////--------------------------------------------------
            ////Messing with delegates
            //MyClass obj = new MyClass();
            //obj.countMethod(Callback);
            ////--------------------------------------------------

        }
        static void Callback(int i)
        {
            Console.WriteLine(i);
        }
        public static int GetEvenTotal(List<int> tempList)
        {
            int totalEvens = 0;

            foreach (int i in tempList)
            {
                if (i % 2 == 0)
                {
                    totalEvens += i;
                }
            }

            return totalEvens;
        }
        public static int GetEven(int[] intArray)
        {
            var results = from x in intArray where x % 2 == 0 select x;
            return results.Sum();
        }
        public static long GetEvenTotal(int[] intArray)
        {
            return intArray.Where(x => x % 2 == 0).Sum(i => (long)i);
        }
    }

    public class MyClass : AbstractClass, IClass
    {
        public delegate void CallBack(int i);
        public void countMethod(CallBack obj)
        {
            for (int i = 0; i < 10000; i++)
            {
                //does something
                obj(i);
            }
        }

        public override float Divide(float x, float y)
        {
            return x / y;
        }
        public float Subtract(float x, float y)
        {
            return x - y;
        }
    }
    public abstract class AbstractClass
    {
        public float Multiply(float x, float y)
        {
            return x * y;
        }
        public abstract float Divide(float x, float y);
    }

    public interface IClass
    {
        float Subtract(float x, float y);
    }
}