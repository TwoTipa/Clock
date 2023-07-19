using System;
using UnityEngine;

namespace Clock
{
    public class ClockWatch : ClockTime
    {
        private float _timezone;
        public override ClockTime Initialisation(float timezone)
        {
            _timezone = timezone;
            CurrentTime = GetMyTime(timezone);
            return base.Initialisation(timezone);
        }

        public override TimeSpan Tick()
        {
            CurrentTime += TimeSpan.FromSeconds(Time.deltaTime);
            CorrectTime();
            return CurrentTime;
        }

        /// <summary>
        /// Метод для синхронизации часов
        /// </summary>
        private void CorrectTime()
        {
            if (DateTime.UtcNow.Minute == 0 && DateTime.UtcNow.Second == 0)
            {
                CurrentTime = GetMyTime(_timezone);
            }
        }
    }
}