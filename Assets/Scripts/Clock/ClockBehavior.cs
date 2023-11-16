using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace Clock
{
    public class ClockBehavior : MonoBehaviour
    {
        [SerializeField] protected float timezone = 3;
        [SerializeField] private string formate = $"{0}:{1}:{2}";
        [SerializeField] private TextMeshPro time;

        private TimeSpan _alarm = TimeSpan.MinValue;
        private bool _isAlarmSet = false;
        private ClockTime _clockTime;

        public ClockTime GetClock()
        {
            return _clockTime;
        }

        public void SetAlarm(TimeSpan newAlarm)
        {
            _alarm = newAlarm;
        }
        
        private void OnEnable()
        {
            SetAlarmBtn.SwitchClock += SetAlarmBtnOnSwitchClock;
            ClockAlarm.SetAlarm += SetAlarmBtnOnSetAlarm;
        }

        private void OnDisable()
        {
            SetAlarmBtn.SwitchClock -= SetAlarmBtnOnSwitchClock;
            ClockAlarm.SetAlarm -= SetAlarmBtnOnSetAlarm;
        }

        private void SetAlarmBtnOnSetAlarm(TimeSpan obj)
        {
            SetAlarm(obj);
        }

        private void SetAlarmBtnOnSwitchClock(ClockTime obj)
        {
            _clockTime.DeInitialisation();
            _clockTime = obj.Initialisation(timezone);
        }

        private void Start()
        {
            _clockTime = new ClockWatch().Initialisation(timezone);
            if (PlayerPrefs.GetInt("AlarmHour") != 0)
            {
                _alarm = new TimeSpan(PlayerPrefs.GetInt("AlarmHour"), PlayerPrefs.GetInt("AlarmMinutes"), 0);
                _isAlarmSet = true;
            }
            else
            {
                _isAlarmSet = false;
            }
        }
        

        private void Update()
        {
            var tick = _clockTime.Tick();
            time.text = String.Format(formate, tick.Hours.ToString("00"), tick.Minutes.ToString("00"), tick.Seconds.ToString("00"));
        }
        
        
    }
}