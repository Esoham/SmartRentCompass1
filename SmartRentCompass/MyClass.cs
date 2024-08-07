using System;

namespace SmartRentCompass
{
    public class MyClass
    {
        public int MyProperty { get; set; }

        public MyClass(int myProperty)
        {
            if (myProperty < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(myProperty), "Property value cannot be negative.");
            }

            MyProperty = myProperty;
        }

        public void DoSomething()
        {
            Console.WriteLine($"Doing something with {MyProperty}");
        }
    }
}