Problem
Simulate meter status logs for a week:Each day record:Status = "OK", "OUTAGE", "TAMPER", "LOW_VOLT".

Write a loop:

Count how many times each event occurs.

If outage count > 2 OR tamper count > 1 → print “Maintenance required”.

Else print “Meter healthy”.

Use Concepts
foreach

Logical OR (||) and AND (&&)

Nested conditionals

Sample Data
L  string[] status = { "OK", "OUTAGE", "OK", "TAMPER", "OUTAGE", "OK", "LOW_VOLT" };  

Expected Output
  OK: 3 | OUTAGE: 2 | TAMPER: 1 | LOW_VOLT: 1  Meter healthy  

Stretch
Add “Suspicious Pattern” if tamper occurs right after an outage.

