using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Entities.Schedules
{
    [Owned]
    [ComplexType]
    public class Time : IComparable<Time>
    {
        public int? Hours { get; set; }
        public int? Minutes { get; set; }

        public int CompareTo(Time time)
        {
            if (this.Hours > time.Hours)
                return -1;
            else
            {
                if (this.Hours == this.Hours)
                {
                    if (this.Minutes > time.Minutes)
                        return -1;
                    else
                    {
                        if (this.Minutes == time.Minutes)
                            return 0;
                        else return 1;
                    }
                }
                else return 1;
            }
        }

        public override string ToString()
        {
            return String.Format("{0:00}:{1:00}", this.Hours, this.Minutes);
        }

    }
}
