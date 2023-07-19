using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Clock
{
    public class ClockTime
    {
        public TimeSpan CurrentTime { get; protected set; }
        public Transform nail;


        public virtual ClockTime Initialisation(float timezone)
        {
            return this;
        }
        
        public virtual TimeSpan Tick()
        {
            return CurrentTime;
        }
        
        protected TimeSpan GetMyTime(float timezone)
        {
            return DateTime.UtcNow.TimeOfDay + TimeSpan.FromHours(timezone);
        }

    }
}
