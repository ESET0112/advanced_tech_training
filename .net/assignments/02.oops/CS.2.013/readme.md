Inheritance Basics --- Device → Meter / Gateway
Goal: Establish base class reuse.

Problem

Base class Device:

Props: Id (string), InstalledOn (DateTime).

Method: Virtual Describe() → "Device Id: ... InstalledOn: ..."

Derived:

Meter adds PhaseCount (int) and overrides Describe() to include it.

Gateway adds IpAddress (string) and overrides Describe().

Tasks

Create Device[] with 1 meter + 1 gateway (polymorphic array).

Loop and Console.WriteLine(d.Describe()).

Expected Output

Meter Id: AP-0001 | Installed: 2024-07-01 | Phases: 3
Gateway Id: GW-11 | Installed: 2025-01-10 | IP: 10.0.5.21