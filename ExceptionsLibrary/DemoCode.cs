using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLibrary
{
    public class DemoCode
    {
        //What the code below does is illustrate and drive home the point that you shouldn't call methods directly, a bigger method should call a bunch of smaller methods rather than calling a method that it needs directly.
        public int GrandParentMethod(int position)
        {
            int output = 0;
            Console.WriteLine("Open database connection" );

            try
            {
                output = ParentMethod(position);

                //If you want, you can catch exceptions within the "try" block 
                //Note that this isn't the best way to handle errors like these
                //Volunteers relating to input can be done within the input validation
                //Code
                //if (position < 0)
                //{
                //    throw new IndexOutOfRangeException("The value has to be greater than or equal to zero");
                //}
            }
            catch (Exception ex)
            {
                //Throw is used to catch errors and pass it up to the higher class/code
                //It's especially useful when you want to create exception handling in the lower classes
                //throw can also be used to log errors.
                //in average cases, "throw;" is enough
                //Don't write "throw ex" because it's not the same as "throw", it shortens the stack trace and doesn't show the full stack trace outlining all the classes and methods affected by the project.
                //Don't write "throw new Exception("Bespoke exception message")" because it also reduces the stack trace.

                //You should throw a new exception when it is specific to an exception type you want to catch
                //When you type "throw new Exception" you get a list of suggestions
                //Throwing a new exception also reduces the stack trace, the way to get around it is when you add an inner exception.
                //The code below shows you the format of an inner exception
                //The new exception type you created will respond to the exception in question, however, the inner exception will show the trigger/origin of the new exception type thus giving you the full stack trace
                throw new ArgumentException("You passed bad data", ex);
            }
            //Code enclosed in the "finaly" will run no matter what
            //You must not put code that has bugs or that will throw an exception in the "finally" block
            finally
            {
                Console.WriteLine("Close database connection");
            }

            return output;
        }

        public int ParentMethod(int position)
        {
            return GetNumber(position);
        }

        //It's not advisable to use your try catch in this level of the program, it should preferably be used in the user interface side.
        public int GetNumber(int position)
        {
            int output = 0;
            //try
            //{
                int[] numbers = new int[] { 1, 4, 7, 2 };
                output = numbers[position];
            //}

            //What the code below does is that it catches every exception and logs, it's a bit too general and not specific enough
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    //The line of code belows tells you exactly where the error happened
            //    Console.WriteLine(ex.StackTrace);
            //}

            return output;
        }
    }
}
