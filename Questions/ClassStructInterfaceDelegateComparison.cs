namespace basics.Questions;

internal class ClassStructInterfaceDelegateComparison
{
    /// <summary>
    /// A class type defines a data structure that contains data members (fields) and function members (methods, properties, and others). 
    /// Class types support single inheritance and polymorphism, mechanisms whereby derived classes can extend and specialize base classes.
    /// </summary>
    class Class { }

    /// <summary>
    /// A struct type is similar to a class type in that it represents a structure with data members and function members. 
    /// However, unlike classes, structs are value types and don't typically require heap allocation. 
    /// Struct types don't support user-specified inheritance, and all struct types implicitly inherit from type object.
    /// </summary>
    struct Struct { }

    /// <summary>
    /// An interface type defines a contract as a named set of public members. 
    /// A class or struct that implements an interface must provide implementations of the interface's members. 
    /// An interface may inherit from multiple base interfaces, and a class or struct may implement multiple interfaces.
    /// </summary>
    interface Interface { }

    /// <summary>
    /// A delegate type represents references to methods with a particular parameter list and return type. 
    /// Delegates make it possible to treat methods as entities that can be assigned to variables and passed as parameters. 
    /// Delegates are analogous to function types provided by functional languages. 
    /// They're also similar to the concept of function pointers found in some other languages. Unlike function pointers, delegates are object-oriented and type-safe.
    /// </summary>
    /// <param name="str"></param>
    delegate void Delegate (string str);
}
