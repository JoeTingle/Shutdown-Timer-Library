# Shutdown Timer C# Library
Small C# library to allow for easy shutdown functionality of windows PC systems. Can call a shutdown immediately or on a timer defined by the user, passed through as a parameter.
## Functions
Current Public Functions:
- BeginTimer(int minutes)
  - Starts a time with the paramter which upon completion will execute a system shutdown
- Now()
  - Executes a system shutdown immediately
- Cancel()
  - Resets the current active timer

## Availability
Currently available as :
- Direct download .dll / .lib
- Nuget Package (TBC)
