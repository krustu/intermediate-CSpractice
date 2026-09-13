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

