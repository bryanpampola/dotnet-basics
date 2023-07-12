using System.Text;

namespace basics.Types;

public class ValueTypes : DisplayableClass
{
    public override string GetTypeInformation()
    {
        var sb = new StringBuilder(GetType().Name + "\n");

        sb.AppendLine(nameof(SimpleTypes));

        sb.AppendLine(new SimpleTypes.SignedIntegral().DisplayTypePropertiesAndValues());

        sb.AppendLine(new SimpleTypes.UnsignedIntegral().DisplayTypePropertiesAndValues());

        sb.AppendLine(new SimpleTypes.UnicodeCharacters().DisplayTypePropertiesAndValues());

        sb.AppendLine(new SimpleTypes.IEEEBinaryFloatingPoint().DisplayTypePropertiesAndValues());

        sb.AppendLine(new SimpleTypes.HiPrecisionDecimalFloatingPoint().DisplayTypePropertiesAndValues());

        sb.AppendLine(new EnumTypes().DisplayTypePropertiesAndValues());

        sb.AppendLine(nameof(StructTypes));

        sb.AppendLine(new NullableValueTypes().DisplayTypePropertiesAndValues());

        sb.AppendLine(new TupleTypes().DisplayTypePropertiesAndValues());

        return sb.ToString();
    }

    internal class SimpleTypes
    {
        internal class SignedIntegral
        {
            public sbyte SByte { get; set; } = sbyte.MinValue; // -128 to 127
            public short Short { get; set; } = short.MinValue; // -32,768 to 32,767
            public int Int { get; set; } = int.MinValue; // -2,147,483,648 to 2,147,483,647
            public long Long { get; set; } = long.MinValue; // -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
        }

        internal class UnsignedIntegral
        {
            public byte Byte { get; set; } = byte.MaxValue; // 0 to 255
            public ushort UShort { get; set; } = ushort.MaxValue; // 0 to 65,535
            public uint UInt { get; set; } = uint.MaxValue; // 0 to 4,294,967,295
            public ulong ULong { get; set; } = ulong.MaxValue; // 0 to 18,446,744,073,709,551,615
        }

        internal class UnicodeCharacters
        {
            public char Char { get; set; } = '\u0048'; // =H | represents a UTF-16 code unit
        }

        internal class IEEEBinaryFloatingPoint
        {
            public double Double { get; set; } = 0.42e2; // =42 | ±5.0 × 10−324 to ±1.7 × 10308
            public float Float { get; set; } = 134.45E-2f; // =1.3445 | ±1.5 x 10−45 to ±3.4 x 1038

        }

        internal class HiPrecisionDecimalFloatingPoint
        {
            public decimal Decimal { get; set; } = 1.5E6m; // =1500000 | ±1.0 x 10-28 to ±7.9228 x 1028
        }
    }

    internal class EnumTypes
    {
        public Season EnumSeason { get; set; } = Season.Summer;
        public enum Season
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }
    }

    internal struct StructTypes //User-defined types of the form
    {
    }

    internal class NullableValueTypes
    {
        public int? NullableInt { get; set; } = null;
    }

    internal class TupleTypes
    {
        public (int, int) Tuple { get; set; } = (1, 1);
    }
}
