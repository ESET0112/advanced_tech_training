Create a Meter class with:

Fields/props: MeterSerial (string), Location (string), InstalledOn (DateTime), LastReadingKwh (int).

Methods:

AddReading(int deltaKwh): adds to LastReadingKwh if deltaKwh > 0, else ignore.

Summary(): returns "SERIAL Location: X | Reading: Y".

Tasks

Instantiate two meters, set properties via object initializer.

Call AddReading with valid and invalid deltas.

Print Summary() for each.

Expected Output (example)

AP-0001 Location: Feeder-12 | Reading: 15230
AP-0002 Location: DTR-9     | Reading:  9800
