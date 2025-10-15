Problem
Write a console app that:

Reads previous and current readings (in kWh).

Calculates the difference (consumption).

Checks:

If consumption < 0 → Invalid.

If consumption == 0 → Possible outage.

If consumption > 500 → High consumption alert.

Use Concepts
Arithmetic operators (+, -)

Comparison operators (<, ==, >)

Logical operators (&&, ||)

if statements

Sample Input
  Previous Reading: 15000  Current Reading: 15620  

Expected Output
  Net Consumption: 620 kWh  High Consumption Alert!  

Stretch
Add logical condition: if consumption > 100 and < 500 → print “Normal usage”.




Comment: In Stretch Condition 1-100 was not mentioned. So I have taken 1-499 as Normal Usage only
