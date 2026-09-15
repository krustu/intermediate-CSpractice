# public class BankAccountException : Exception { ... } // общий предок для всех ошибок счёта
# public class InsufficientFundsException : BankAccountException { ... }
# public class AccountFrozenException : BankAccountException { ... }

## What I Learned

A custom exception is a class that inherits from the base `Exception` class. 
It allows us to create our own exceptions with extra information about the problem and understand exactly how they work.
