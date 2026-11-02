# What is a Captive Dependency?
A captive dependency happens when a service with a longer lifetime, 
for example a Singleton, depends on a service with a shorter lifetime, 
for example a Scoped one. The short-lived service stays alive as long as the long-lived one,
so it can hold stale data and cause bugs. The container can detect it if ValidateScopes is enabled.