# CircularInt
Basically, it's a circular int datatype.

# Usage
(taken from [wiki](https://github.com/TiredAJ/CircularInt/wiki/Where-to-start))

This library uses .NET 7.0, you might need this.

With the library installed and the using Circular; in place, you can start using CInts.

To start, you can initialise a CInt like:

Just the value
```C#
//value
CInt Val = new CInt(5);
```

Just the boundaries
```C#
//maximum, minimum
CInt Val = new CInt(10, 0);
```

or all three
```C#
//value, maximum, minimum
CInt Val = new CInt(5, 10, 0);
```

To use it in the place of an int (such as an index for an array), you can cast it to an int and it should be usable
```C#
string[] Names =
    {
        "Erin",
        "Charles",
        "Lexi",
        "Sunny",
        "Cara",
        "Bianca"
    };

CInt i = new CInt(0, (Names.Count() -1), 0);

while (true)
{
    Console.WriteLine(Names[(int)i]);

    i++;
    Thread.Sleep(1500);
}
```

Hopefully that explains the basics of CInts
