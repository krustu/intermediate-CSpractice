# What does it for? and What I understood
Business logic should not know about HTTP or SQL because these are infrastructure details that change often,
while the business rules stay the same. If the logic is separated behind an interface,
we can switch from an API to a database without rewriting the rules.
It also lets us test the rules with a fake source,
without a network or a real database.