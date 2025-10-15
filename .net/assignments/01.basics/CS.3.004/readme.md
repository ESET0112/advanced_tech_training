Problem
For 3 meters, each with 7 daily kWh entries:

For each meter:

Total & average

PeakAlert if any day > 8 kWh

SustainedOutage if there are two consecutive zero-days

Across all meters, find the single highest day usage (value + which meter + day)

Guidance
Use int[][] meters as a jagged array.

Outer loop over meters, inner over days.

Use flags for alerts; track per-meter max and global max (with meter/day indexes).

Starter Data
int[][] meters = new int[][]  {    
    new[] { 4, 5, 0, 0, 6, 7, 3 }, // A    
    new[] { 2, 2, 2, 2, 2, 2, 2 }, // B    
    new[] { 9, 1, 1, 1, 1, 1, 1 }  // C  
};  
    string[] ids = { "A-1001", "B-2001", "C-3001" };  
// 
Expected Per-Meter Stats
A-1001: Total 25, Avg 3.57, PeakAlert False, SustainedOutage True (days 3–4)

B-2001: Total 14, Avg 2.00, PeakAlert False, SustainedOutage False

C-3001: Total 15, Avg 2.14, PeakAlert True (day 1), SustainedOutage False

Expected Global
Highest day = 9 kWh on C-3001 Day 1
Example print (one line per meter + summary):

  A-1001 | Total:25 Avg:3.57 | Peak:No | SustainedOutage:Yes  B-2001 | Total:14 Avg:2.00 | Peak:No | SustainedOutage:No  C-3001 | Total:15 Avg:2.14 | Peak:Yes | SustainedOutage:No  Highest Day: 9 kWh | Meter: C-3001 | Day: 1