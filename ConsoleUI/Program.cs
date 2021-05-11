using ExceptionsLibrary;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //When you type the word "DemoCode" it gives you the ability to link to class libraries that you haven't already linked.

            //The code just below instantiates demo code
            DemoCode demo = new DemoCode();

            //Recall from the ExceptionsLibary class, that when we want to call any of the method in it, we need to specify a number as a parameter
            //The number refers to the position in an array that we created
            //When we input the number parameter when calling the method it'll return to us the item in that particular position in the array we created
            //Simply put, by writing "3" in the "demo.GrandParentMethod(3);" we're requesting for the fourth item in the array we created in the ExceptionsLibrary class.
            //Arrays start counting from position 0 (which is the first item) as such 3 is the fourth position if you follow the n+1 principle.
            //int result = demo.GrandParentMethod(3);

            //When we specify a unit parameter that is beyond what the length of the array you get an out of bounds exception.
            //Note that variables created within blocks (curly braces) are limited in scope to that block.
            //If you need to be able to access the variable outside the block you must first declare the variable globally (outside the block).
            try
            {
                int result = demo.GrandParentMethod(4 );
                Console.WriteLine($"The value at the given position is {result}");
            }
            //Note that you can catch multiple types of error within one try catch usage.
            //Make sure the "Exception" is the last exception type to catch because it's very general
            //Note that the parameter "ex" is a variable parameter that can be used repeatedly because it is limited in scope to the catch block it is mentioned in.
            catch(ArgumentException ex)
            {
                Console.WriteLine("You gave us suspicious information, are you a hoodlum?");
            }
            catch (Exception ex)
            {
                //Try catch should be done as high as possible in the program so as to ensure that you get as much information as possible about the root of the problem and every other place that is affected by the problem.
                //Low level classes don't need try catch as much as high level classes.
                //If you don't have a throw here it means the application can continue to run in spite of the error.
                Console.WriteLine(ex.Message);
                //The line of code below shows you the stack trace
                Console.WriteLine(ex.StackTrace);

                //The codes below help get the inner exception (which is the rest of the stack trace)
                //As long as there's still an inner exception it will write out the stack trace.
                var inner = ex.InnerException;

                while (inner != null)
                {
                    Console.WriteLine(inner.StackTrace);
                    inner = inner.InnerException;
                }
            }
            

            Console.ReadLine();
        }
    }
}
