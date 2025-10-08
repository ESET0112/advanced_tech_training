Interface for Reading --- IReadable
Goal: Program to interface.

Problem
Define IReadable:

public interface IReadable
{
    int ReadKwh();             // returns delta since last poll
    string SourceId { get; }
}
Implement:

DlmsMeter : IReadable (returns a random 1--10 kWh).

ModemGateway : IReadable (returns a random 0--2 kWh representing backfill).

Tasks

Put both in List<IReadable> and poll 5 times (loop).

Print "SourceId -> deltaKwh" for each poll.

Expected Output (sample)

AP-0001 -> 7
GW-21   -> 1
...