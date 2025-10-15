Problem
You are given the outage hours for each meter over the week.

Meter	Hours[]
MTR001	[1, 0, 0, 5, 2, 0, 0]
MTR002	[0, 0, 0, 0, 0, 0, 0]
MTR003	[0, 4, 3, 0, 0, 0, 0]
Tasks:

For each meter:

Sum total outage hours.

If total > 8 → “Escalate to field team”.

If total == 0 → “Stable”.

Else → “Monitor”.

Use nested for loops & if conditions.

Print summary table.

Use Concepts
Nested for loops

Logical & comparison operators

Conditional classification

Expected Output
MTR001 | Outage Hours: 8 | Action: Monitor  
MTR002 | Outage Hours: 0 | Action: Stable  
MTR003 | Outage Hours: 7 | Action: Monitor   
Stretch
Use while loop variant to verify no negative entries exist (if found, print “Invalid Data”).