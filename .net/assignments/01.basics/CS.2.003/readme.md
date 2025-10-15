Problem
You’re given 7 CSV-like lines: yyyy-MM-dd,kWh,status where status is OK / OUTAGE / TAMPER.Compute:

Sum of kWh where status == OK

Count of OUTAGE days

Count of TAMPER days

Average kWh across only OK days

Guidance
Use string[] lines.

For each line: Split(','), double.Parse, if/else if.

Keep okCount to compute average.

Starter Data
string[] lines = {    "2025-09-01,4.2,OK",    "2025-09-02,5.0,OK",    "2025-09-03,0.0,OUTAGE",    "2025-09-04,3.8,OK",    "2025-09-05,6.1,OK",    "2025-09-06,2.5,TAMPER",    "2025-09-07,5.4,OK"  };   `
Expected Output (deterministic)
OK sum = 24.5 kWh

OUTAGE days = 1

TAMPER days = 1

OK average = 4.90 kWh

Example print:

  OK: 24.50 kWh (avg 4.90) | OUTAGE: 1 | TAMPER: 1  