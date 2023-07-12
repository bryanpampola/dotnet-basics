using static System.Console;

namespace basics.Questions;

/// <summary>
/// When a value of a value type is assigned to an object reference, a "box" is allocated to hold the value. 
/// That box is an instance of a reference type, and the value is copied into that box. 
/// Conversely, when an object reference is cast to a value type, a check is made that the referenced object is a box of the correct value type. 
/// If the check succeeds, the value in the box is copied to the value type.
/// </summary>
internal class BoxingUnboxing
{
    internal void Example1()
    {
        int i = 123;
        object o = i;    // Boxing
        int j = (int)o;  // Unboxing
    }

    internal void Example2()
    {
        var x = new SampleStruct { Text = "Hello" };
        object o = x;
        x.Text = "World";
        WriteLine(string.Format("{0} {1}", x, o));
    }

    struct SampleStruct
    {
        public string Text { get; set }
        public override string ToString() { return Text; }
    }
}


