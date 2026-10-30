# Explanation
Dependency inversion is the “D” in SOLID
. It says that high-level classes shouldn’t depend on low-level classes, 
both should depend on an abstraction. In my example, 
OrderProcessor depends on the IMessageSender interface instead of a concrete EmailSender, 
and the concrete class is chosen in one place, in Main. Because of that,
I can swap email for console or Telegram without changing OrderProcessor,
and I can replace the real sender with a fake one in tests.