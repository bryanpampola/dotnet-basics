using System.Text;

namespace basics.Types;

internal class ReferenceTypes : DisplayableClass
{
    public override string GetTypeInformation()
    {
        var sb = new StringBuilder(GetType().Name + "\n");

        sb.AppendLine(new ClassTypes().DisplayTypePropertiesAndValues());

        sb.AppendLine(nameof(InterfaceTypes));

        sb.AppendLine(new ArrayTypes().DisplayTypePropertiesAndValues());

        sb.AppendLine(nameof(DelegateTypes));

        return sb.ToString();
    }

    internal class ClassTypes
    {
        public object Object { get; set; } = "Ultimate base class of all other types";
        public string String { get; set; } = "represents a sequence of UTF-16 code units";
        public ClassExample Class { get; set; }
        internal class ClassExample
        {
        }
    }

    public interface InterfaceTypes
    {
    }

    internal class ArrayTypes
    {
        public int[] SingleDimensionalArray { get; set; } = new int[] { 1 };
        public int[,] MultiDimensionalArray { get; set; } = new int[3, 4]
        {
           {0, 1, 2, 3} ,   /*  initializers for row indexed by 0 */
           {4, 5, 6, 7} ,   /*  initializers for row indexed by 1 */
           {8, 9, 10, 11}   /*  initializers for row indexed by 2 */
        };
        public int[][] JaggedArray { get; set; } = new int[2][] 
        { 
            new int[] { 92, 93, 94 }, 
            new int[] { 85, 66, 87, 88 } 
        };
    }

    internal delegate void DelegateTypes (string example);
}
