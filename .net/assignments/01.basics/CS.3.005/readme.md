Problem
Simulate a 30-day month for one meter:

You’re given a 10-day pattern of daily units; repeat it 3× to make 30 days.

Compute:

monthlyUnits (sum)

outageDays (entries equal to 0)

Compute energy charge using slabs:

First 100 units @ ₹4.0

Next 200 units @ ₹6.0

Remaining @ ₹8.5

Add fixed charge by category (use a variable):

DOMESTIC → ₹50

COMMERCIAL → ₹150

If outageDays == 0, apply 2% rebate on (energy + fixed); otherwise no rebate.

Print a tidy invoice line with the breakdown.

Guidance
Build int[] pattern then create int[] month = new int[30] with loops.

Use a switch on category string.

Compute slabs with arithmetic + if/else if.

Keep all money as double.

Starter Data
int[] pattern = { 4, 4, 5, 5, 0, 6, 7, 3, 4, 5 }; // sum = 43  
string category = "COMMERCIAL"; // change to test   `
Note: Repeating pattern 3× ⇒ monthlyUnits = 43 × 3 = 129, outageDays = 3.

Slab Calculation for 129 units
First 100 @ 4.0 = ₹400

Next 29 @ 6.0 = ₹174

Total energy = ₹574

Fixed (COMMERCIAL) = ₹150

Outages > 0 ⇒ no rebate

Grand Total = ₹724.00

Expected Output
Category: COMMERCIAL | Units: 129 | Energy: ₹574.00 | Fixed: ₹150.00 | Rebate: ₹0.00 | Total: ₹724.00 | Outages: 3  