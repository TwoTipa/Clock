using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Clock
{
    public class ClockTime : MonoBehaviour
    {
        public TimeSpan CurrentTime { get; private set; }
        public Transform nail;

        [SerializeField] private float timezone = 3;
        [SerializeField] private string formate = $"{0}:{1}:{2}";
        [SerializeField] private TextMeshPro time;
        
        private void Awake()
        {
            CurrentTime = GetMyTime();
        }

        private TimeSpan GetMyTime()
        {
            return DateTime.UtcNow.TimeOfDay + TimeSpan.FromHours(timezone);
        }

        private void Update()
        {
            CurrentTime += TimeSpan.FromSeconds(Time.deltaTime);
            time.text = String.Format(formate, CurrentTime.Hours, CurrentTime.Minutes, CurrentTime.Seconds);
            CorrectTime();
        }

        /// <summary>
        /// Метод для синхронизации часов
        /// </summary>
        private void CorrectTime()
        {
            if (DateTime.UtcNow.Minute == 0 && DateTime.UtcNow.Second == 0)
            {
                CurrentTime = GetMyTime();
            }
        }
    }
}
