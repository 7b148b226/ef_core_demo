namespace ef_core_7_with_.net_7.Static;

public static class RandomDateTime
{
    public static DateTime Minutes()
    {
        return Minutes(new DateTime(1980, 1, 1), DateTime.UtcNow);
    }

    public static DateTime Minutes(DateTime start, DateTime end, Random rnd = null)
    {
        rnd ??= new Random();
        var delta = new TimeSpan(0, rnd.Next(0, (int)(end - start).TotalMinutes), 0);

        return start + delta;
    }
}
