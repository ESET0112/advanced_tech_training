Constructors & Overloads --- Tariff
Goal: Define overloaded constructors + chaining.

Problem
Create a Tariff class with:

Props: Name (string), RatePerKwh (double), FixedCharge (double).

Ctors:

Tariff(string name) → defaults: rate=6.0, fixed=50.

Tariff(string name, double rate) → defaults fixed=50.

Tariff(string name, double rate, double fixedCharge).

ComputeBill(int units) → units * rate + fixed.

Tasks

Create three tariffs using different constructors.

For units=120, print computed bill for each.

Expected Output (example)

DOMESTIC: ₹770.00
COMMERCIAL: ₹1170.00
AGRI: ₹410.00
