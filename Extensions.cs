using System.Text;

namespace basics;

public static class Extensions
{
    public static string DisplayTypePropertiesAndValues(this Object @object)
    {
        if (@object == null)
        {
            return string.Empty;
        }

        var sb = new StringBuilder(@object.GetType().Name + "\n");
        sb.AppendLine("=====================");
        var props = @object.GetType().GetProperties();
        foreach (var property in props)
        {
            sb.AppendLine($"{property.Name} - {property.GetValue(@object, null)}");
        }

        return sb.ToString();
    }
}

public abstract class DisplayableClass
{
    public abstract string GetTypeInformation();
}