# Composition Root 
The composition root is the single place in the application where we create all the objects and connect them to each other.
In my project it’s the Main method: I create the repository and the sender, pass them into OrderService,
then pass the service into App and start it. All other classes only receive their dependencies through the constructor and don’t create them
, so I can change an implementation in one place.

