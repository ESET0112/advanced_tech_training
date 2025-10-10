Domain Model with Inheritance & Polymorphic Processing --- Event Hierarchy
Goal: Model real MDMS events + process via polymorphism.

Problem
Create base class:

abstract class Event
{
    public DateTime When { get; }
    public string MeterSerial { get; }
    protected Event(DateTime when, string meterSerial) { When = when; MeterSerial = meterSerial; }
    public abstract string Category { get; }
    public abstract int Severity { get; } // 1..5
    public virtual string Describe() => $"{When:yyyy-MM-dd HH:mm} [{Category}] {MeterSerial}";
}
Derived:

OutageEvent : Event (Category="OUTAGE", Severity=3, plus DurationMinutes).

TamperEvent : Event (Category="TAMPER", Severity=5, plus Code).

VoltageEvent : Event (Category="VOLTAGE", Severity=2, plus Voltage).

Processor

class EventProcessor
{
    public static void PrintTopSevere(IEnumerable<Event> events, int topN)
    {
        // sort by Severity desc, then When desc; print Describe() + extra fields polymorphically
    }
}
Tasks

Create a mixed list of 8 events across 3 types.

Print top 3 by severity/recency.

Expected Output

2025-10-06 09:20 [TAMPER] AP-0007 | Code: MISMATCH | Severity: 5
2025-10-05 22:10 [OUTAGE] AP-0003 | Duration: 95 min | Severity: 3
2025-10-05 18:00 [VOLTAGE] AP-0001 | V: 184 | Severity: 2