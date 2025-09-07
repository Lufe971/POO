using System;

class Time
{
    private int hour;
    private int minute;
    private int second;
    private int millisecond;

    public Time()
    {
        hour = 0;
        minute = 0;
        second = 0;
        millisecond = 0;
    }

    public Time(int h)
    {
        if (h < 0 || h > 23)
            throw new ArgumentException($"The hour: {h}, is not valid.");
        hour = h;
        minute = 0;
        second = 0;
        millisecond = 0;
    }

    public Time(int h, int m)
    {
        if (h < 0 || h > 23)
            throw new ArgumentException($"The hour: {h}, is not valid.");
        if (m < 0 || m > 59)
            throw new ArgumentException($"The minute: {m}, is not valid.");
        hour = h;
        minute = m;
        second = 0;
        millisecond = 0;
    }

    public Time(int h, int m, int s, int ms = 0)
    {
        if (h < 0 || h > 23)
            throw new ArgumentException($"The hour: {h}, is not valid.");
        if (m < 0 || m > 59)
            throw new ArgumentException($"The minute: {m}, is not valid.");
        if (s < 0 || s > 59)
            throw new ArgumentException($"The second: {s}, is not valid.");
        if (ms < 0 || ms > 999)
            throw new ArgumentException($"The millisecond: {ms}, is not valid.");
        hour = h;
        minute = m;
        second = s;
        millisecond = ms;
    }

    public Time Add(Time other, out bool nextDay)
    {
        int ms = millisecond + other.millisecond;
        int carrySec = ms / 1000;
        ms %= 1000;

        int s = second + other.second + carrySec;
        int carryMin = s / 60;
        s %= 60;

        int m = minute + other.minute + carryMin;
        int carryHour = m / 60;
        m %= 60;

        int h = hour + other.hour + carryHour;
        nextDay = h >= 24;
        h %= 24;

        return new Time(h, m, s, ms);
    }

    public void Print(Time sumWith, Time checkWith)
    {
        Console.WriteLine("Time: " + ToString());
        Console.WriteLine("Milliseconds : " + ToMilliseconds());
        Console.WriteLine("Seconds      : " + ToSeconds());
        Console.WriteLine("Minutes      : " + ToMinutes());

        bool nextDay;
        Time added = Add(sumWith, out nextDay);
        Console.WriteLine("Add          : " + added.ToString());

        bool nextDayCheck;
        Add(checkWith, out nextDayCheck);
        Console.WriteLine("Is Other day : " + nextDayCheck);
        Console.WriteLine();
    }

    public long ToMilliseconds()
    {
        return (long)hour * 3600000 + (long)minute * 60000 + (long)second * 1000 + millisecond;
    }

    public long ToSeconds()
    {
        return (long)hour * 3600 + (long)minute * 60 + second;
    }

    public long ToMinutes()
    {
        return (long)hour * 60 + minute;
    }

    public override string ToString()
    {
        return $"{hour:D2}:{minute:D2}:{second:D2}.{millisecond:D3} {(hour < 12 ? "AM" : "PM")}";
    }
}