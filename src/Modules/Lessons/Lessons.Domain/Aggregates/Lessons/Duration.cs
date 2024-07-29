using BuildingBlocks.Domain;

namespace Lessons.Domain.Aggregates.Lessons;

public class Duration : ValueObject
{
    public int Minutes { get; }

    private Duration(int minutes)
    {
        Minutes = minutes;
    }

    public static Duration Create(int minutes)
    {
        if (minutes > 0 && minutes % 30 == 0)
            return new Duration(minutes);
        else
            throw new ArgumentOutOfRangeException(nameof(minutes));
    }
}
