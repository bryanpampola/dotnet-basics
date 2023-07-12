using static System.Console;

namespace basics.Questions;

// https://stackoverflow.com/questions/64816714/when-to-use-record-vs-class-vs-struct

// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/records


internal class StructClassRecordComparison
{
    public void Execute()
    {
        var foo = new SomeRecord(new List<string>());
        var fooAsShallowCopy = foo;
        var fooAsWithCopy = foo with { }; // A syntactic sugar for new SomeRecord(foo.List);
        var fooWithDifferentList = foo with { List = new List<string>() { "a", "b" } };
        var differentFooWithSameList = new SomeRecord(foo.List); // This is the same like foo with { };
        foo.List.Add("a");

        WriteLine($"Count in foo: {foo.List.Count}"); // 1
        WriteLine($"Count in fooAsShallowCopy: {fooAsShallowCopy.List.Count}"); // 1
        WriteLine($"Count in fooWithDifferentList: {fooWithDifferentList.List.Count}"); // 2
        WriteLine($"Count in differentFooWithSameList: {differentFooWithSameList.List.Count}"); // 1
        WriteLine($"Count in fooAsWithCopy: {fooAsWithCopy.List.Count}"); // 1
        WriteLine("");

        WriteLine($"Equals (foo & fooAsShallowCopy): {Equals(foo, fooAsShallowCopy)}"); // True. The lists inside are the same.
        WriteLine($"Equals (foo & fooWithDifferentList): {Equals(foo, fooWithDifferentList)}"); // False. The lists are different
        WriteLine($"Equals (foo & differentFooWithSameList): {Equals(foo, differentFooWithSameList)}"); // True. The list are the same.
        WriteLine($"Equals (foo & fooAsWithCopy): {Equals(foo, fooAsWithCopy)}"); // True. The list are the same, see below.
        WriteLine($"ReferenceEquals (foo.List & fooAsShallowCopy.List): {ReferenceEquals(foo.List, fooAsShallowCopy.List)}"); // True. The records property points to the same reference.
        WriteLine($"ReferenceEquals (foo.List & fooWithDifferentList.List): {ReferenceEquals(foo.List, fooWithDifferentList.List)}"); // False. The list are different instances.
        WriteLine($"ReferenceEquals (foo.List & differentFooWithSameList.List): {ReferenceEquals(foo.List, differentFooWithSameList.List)}"); // True. The records property points to the same reference.
        WriteLine($"ReferenceEquals (foo.List & fooAsWithCopy.List): {ReferenceEquals(foo.List, fooAsWithCopy.List)}"); // True. The records property points to the same reference.
        WriteLine("");

        WriteLine($"ReferenceEquals (foo & fooAsShallowCopy): {ReferenceEquals(foo, fooAsShallowCopy)}"); // True. !!! fooAsCopy is pure shallow copy of foo. !!!
        WriteLine($"ReferenceEquals (foo & fooWithDifferentList): {ReferenceEquals(foo, fooWithDifferentList)}"); // False. These records are two different reference variables.
        WriteLine($"ReferenceEquals (foo & differentFooWithSameList): {ReferenceEquals(foo, differentFooWithSameList)}"); // False. These records are two different reference variables and reference type property hold by these records does not matter in ReferenceEqual.
        WriteLine($"ReferenceEquals (foo & fooAsWithCopy): {ReferenceEquals(foo, fooAsWithCopy)}"); // False. The same story as differentFooWithSameList.
        WriteLine("");

        var bar = new RecordOnlyWithValueNonMutableProperty(0);
        var barAsShallowCopy = bar;
        var differentBarDifferentProperty = bar with { NonMutableProperty = 1 };
        var barAsWithCopy = bar with { };

        WriteLine($"Equals (bar & barAsShallowCopy): {Equals(bar, barAsShallowCopy)}"); // True.
        WriteLine($"Equals (bar & differentBarDifferentProperty): {Equals(bar, differentBarDifferentProperty)}"); // False. Remember, the value equality is used.
        WriteLine($"Equals (bar & barAsWithCopy): {Equals(bar, barAsWithCopy)}"); // True. Remember, the value equality is used.
        WriteLine($"ReferenceEquals (bar & barAsShallowCopy): {ReferenceEquals(bar, barAsShallowCopy)}"); // True. The shallow copy.
        WriteLine($"ReferenceEquals (bar & differentBarDifferentProperty): {ReferenceEquals(bar, differentBarDifferentProperty)}"); // False. Operator with creates a new reference variable.
        WriteLine($"ReferenceEquals (bar & barAsWithCopy): {ReferenceEquals(bar, barAsWithCopy)}"); // False. Operator with creates a new reference variable.
        WriteLine("");

        var fooBar = new RecordOnlyWithValueMutableProperty();
        var fooBarAsShallowCopy = fooBar; // A shallow copy, the reference to bar is assigned to barAsCopy
        var fooBarAsWithCopy = fooBar with { }; // A deep copy by coincidence because fooBar has only one value property which is copied into barAsDeepCopy.

        WriteLine($"Equals (fooBar & fooBarAsShallowCopy): {Equals(fooBar, fooBarAsShallowCopy)}"); // True.
        WriteLine($"Equals (fooBar & fooBarAsWithCopy): {Equals(fooBar, fooBarAsWithCopy)}"); // True. Remember, the value equality is used.
        WriteLine($"ReferenceEquals (fooBar & fooBarAsShallowCopy): {ReferenceEquals(fooBar, fooBarAsShallowCopy)}"); // True. The shallow copy.
        WriteLine($"ReferenceEquals (fooBar & fooBarAsWithCopy): {ReferenceEquals(fooBar, fooBarAsWithCopy)}"); // False. Operator with creates a new reference variable.
        WriteLine("");

        fooBar.MutableProperty = 2;
        fooBarAsShallowCopy.MutableProperty = 3;
        fooBarAsWithCopy.MutableProperty = 3;
        WriteLine($"fooBar.MutableProperty = {fooBar.MutableProperty} | fooBarAsShallowCopy.MutableProperty = {fooBarAsShallowCopy.MutableProperty} | fooBarAsWithCopy.MutableProperty = {fooBarAsWithCopy.MutableProperty}"); // fooBar.MutableProperty = 3 | fooBarAsShallowCopy.MutableProperty = 3 | fooBarAsWithCopy.MutableProperty = 3
        WriteLine($"Equals (fooBar & fooBarAsShallowCopy): {Equals(fooBar, fooBarAsShallowCopy)}"); // True.
        WriteLine($"Equals (fooBar & fooBarAsWithCopy): {Equals(fooBar, fooBarAsWithCopy)}"); // True. Remember, the value equality is used. 3 != 4
        WriteLine($"ReferenceEquals (fooBar & fooBarAsShallowCopy): {ReferenceEquals(fooBar, fooBarAsShallowCopy)}"); // True. The shallow copy.
        WriteLine($"ReferenceEquals (fooBar & fooBarAsWithCopy): {ReferenceEquals(fooBar, fooBarAsWithCopy)}"); // False. Operator with creates a new reference variable.
        WriteLine("");

        fooBarAsWithCopy.MutableProperty = 4;
        WriteLine($"fooBar.MutableProperty = {fooBar.MutableProperty} | fooBarAsShallowCopy.MutableProperty = {fooBarAsShallowCopy.MutableProperty} | fooBarAsWithCopy.MutableProperty = {fooBarAsWithCopy.MutableProperty}"); // fooBar.MutableProperty = 3 | fooBarAsShallowCopy.MutableProperty = 3 | fooBarAsWithCopy.MutableProperty = 4
        WriteLine($"Equals (fooBar & fooBarAsWithCopy): {Equals(fooBar, fooBarAsWithCopy)}"); // False. Remember, the value equality is used. 3 != 4
        WriteLine("");

        var venom = new MixedRecord(new List<string>(), 0); // Reference/Value property, mutable non-mutable.
        var eddieBrock = venom;
        var carnage = venom with { };
        venom.List.Add("I'm a predator.");
        carnage.List.Add("All I ever wanted in this world is a carnage.");
        WriteLine($"Count in venom: {venom.List.Count}"); // 2
        WriteLine($"Count in eddieBrock: {eddieBrock.List.Count}"); // 2
        WriteLine($"Count in carnage: {carnage.List.Count}"); // 2
        WriteLine($"Equals (venom & eddieBrock): {Equals(venom, eddieBrock)}"); // True.
        WriteLine($"Equals (venom & carnage): {Equals(venom, carnage)}"); // True. Value properties has the same values, the List property points to the same reference.
        WriteLine($"ReferenceEquals (venom & eddieBrock): {ReferenceEquals(venom, eddieBrock)}"); // True. The shallow copy.
        WriteLine($"ReferenceEquals (venom & carnage): {ReferenceEquals(venom, carnage)}"); // False. Operator with creates a new reference variable.
        WriteLine("");

        eddieBrock.MutableList = new List<string>();
        eddieBrock.MutableProperty = 3;
        WriteLine($"Equals (venom & eddieBrock): {Equals(venom, eddieBrock)}"); // True. Reference or value type does not matter. Still a shallow copy of venom, still true.
        WriteLine($"Equals (venom & carnage): {Equals(venom, carnage)}"); // False. the venom.List property does not points to the same reference like in carnage.List anymore.
        WriteLine($"ReferenceEquals (venom & eddieBrock): {ReferenceEquals(venom, eddieBrock)}"); // True. The shallow copy.
        WriteLine($"ReferenceEquals (venom & carnage): {ReferenceEquals(venom, carnage)}"); // False. Operator with creates a new reference variable.
        WriteLine($"ReferenceEquals (venom.List & carnage.List): {ReferenceEquals(venom.List, carnage.List)}"); // True. Non mutable reference type.
        WriteLine($"ReferenceEquals (venom.MutableList & carnage.MutableList): {ReferenceEquals(venom.MutableList, carnage.MutableList)}"); // False. This is why Equals(venom, carnage) returns false.
        WriteLine("");

    }
    public record SomeRecord(List<string> List);

    public record RecordOnlyWithValueNonMutableProperty(int NonMutableProperty);

    public record RecordOnlyWithValueMutableProperty
    {
        internal int MutableProperty { get; set; } = 1; // this property gets boxed
    }

    public record MixedRecord(List<string> List, int NonMutableProperty)
    {
        internal List<string> MutableList { get; set; } = new();
        internal int MutableProperty { get; set; } = 1; // this property gets boxed
    }


}
