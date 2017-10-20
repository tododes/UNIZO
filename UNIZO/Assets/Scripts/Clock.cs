using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[SerializeField]
public class Clock : SaveableObject {

    public int year, month, day, hour, minute, second;

    public Clock() { }

    public Clock(string file, DateTime dateTime) : base(file) {
        year = dateTime.Year;
        month = dateTime.Month;
        day = dateTime.Day;
        hour = dateTime.Hour;
        minute = dateTime.Minute;
        second = dateTime.Second;
    }

    public static Clock operator +(Clock c, DateTime dt)
    {
        c.year += dt.Year;
        c.month += dt.Month;
        c.day += dt.Day;
        c.hour += dt.Hour;
        c.minute += dt.Minute;
        c.second += dt.Second;
        return c;
    }

    public void SetDataFromDateTime(DateTime dateTime){
        year = dateTime.Year;
        month = dateTime.Month;
        day = dateTime.Day;
        hour = dateTime.Hour;
        minute = dateTime.Minute;
        second = dateTime.Second;
    }

    public DateTime convertToDateTime(){
        return new DateTime(year, month, day, hour, minute, second);
    }
}
