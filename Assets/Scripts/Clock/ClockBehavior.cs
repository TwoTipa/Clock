using System;
using TMPro;
using UnityEngine;

namespace Clock
{
    public class ClockBehavior : MonoBehaviour
    {
        [SerializeField] protected float timezone = 3;
        [SerializeField] private string formate = $"{0}:{1}:{2}";
        [SerializeField] private TextMeshPro time;
        private ClockTime _clockTime;

        public ClockTime GetClock()
        {
            return _clockTime;
        }

        private void OnEnable()
        {
            SetAlarmBtn.SwitchClock += SetAlarmBtnOnSwitchClock;
        }

        private void OnDisable()
        {
            SetAlarmBtn.SwitchClock -= SetAlarmBtnOnSwitchClock;
        }

        private void SetAlarmBtnOnSwitchClock(ClockTime obj)
        {
            _clockTime = obj.Initialisation(timezone);
        }

        private void Start()
        {
            _clockTime = new ClockWatch().Initialisation(timezone);
        }

        private void Update()
        {
            var tick = _clockTime.Tick();
            time.text = String.Format(formate, tick.Hours.ToString("00"), tick.Minutes.ToString("00"), tick.Seconds.ToString("00"));
        }
    }
}