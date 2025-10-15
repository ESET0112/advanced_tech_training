Problem
Given 7 daily kWh values for a meter, compute:

Total, average

Day index (1-based) of max usage

Number of outage days (value == 0)

Print all on one line.

Guidance
Use an int[] daily hardcoded.

Use a for loop, if to count outages, track max and index.

Starter Data
int[] daily = { 4, 5, 6, 0, 7, 8, 5 };
Expected Output
Total = 35

Average = 5.00

Max = 8 on Day 6

Outages = 1

One possible print:

Total: 35 kWh | Avg: 5.00 kWh | Max: 8 kWh (Day 6) | Outages: 1   