using System;

class Entry
{
    public string _date;
    public string _time;
    public string _prompt;
    public string _response;

    public void Display()
    {
        Console.WriteLine($"{_date} {_time} - {_prompt}");
        Console.WriteLine(_response);
    }
}