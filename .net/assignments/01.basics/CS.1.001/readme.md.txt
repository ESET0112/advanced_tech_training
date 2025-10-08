Quick Bill from Two Readings
Problem
Write a console app that:

Prompts for meterSerial (string), prevReading (int), currReading (int).

Computes units = currReading - prevReading.

If units ≤ 0, print an error.

Else compute energyCharge = units * 6.5 and a tax = 5% and total = energyCharge + tax.

Print a one-line bill summary.



-->
energyCharge , tax and total taken as double because if we take them as int it may loose precision.