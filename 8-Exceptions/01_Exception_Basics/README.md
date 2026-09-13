# Exception hierarchy
Exception
├── SystemException (ошибки времени выполнения .NET)
│   ├── NullReferenceException
│   ├── ArgumentException
│   │       └── ArgumentNullException
│   │       └── ArgumentOutOfRangeException
│   ├── InvalidOperationException
│   ├── IndexOutOfRangeException
│   ├── DivideByZeroException
│   ├── FormatException
│   └── KeyNotFoundException
└── ApplicationException (устаревший, для своих исключений — на практике почти не используют, чаще наследуют прямо от Exception)

## Exception Hierarchy

This diagram shows the concept of how the exception hierarchy works.

Examples and practice can be found in the first file, **`Exception-Hierarchy`**.


