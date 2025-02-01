using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
struct Scenario
{
    [FieldOffset(0)] public string Key;
    [FieldOffset(8)] public string Value;

    public Scenario(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public void Display()
    {
        Console.WriteLine($"{Key}: {Value}");
    }
}
