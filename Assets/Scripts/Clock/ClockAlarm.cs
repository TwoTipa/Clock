using System;
using Arrows;
using UnityEngine;

namespace Clock
{
    public class ClockAlarm : ClockTime
    {
        public static event Action<TimeSpan> SetAlarm;

        private Arrow _movingArrow;
        private float _hour;
        private float _minute;
        private float _second;
        
        public override ClockTime Initialisation(float timezone)
        {
            SetAlarmBtn.AlarmChange += SetAlarmBtnOnAlarmChange;
            return base.Initialisation(timezone);
        }

        public override ClockTime DeInitialisation()
        {           
            SetAlarmBtn.AlarmChange -= SetAlarmBtnOnAlarmChange;
            return base.DeInitialisation();
        }

        private void SetAlarmBtnOnAlarmChange(TimeSpan obj)
        {
            _hour = obj.Hours;
            _minute = obj.Minutes;
            _second = obj.Seconds;
            CurrentTime = obj;
        }

        public override TimeSpan Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray,out var hit, Mathf.Infinity, LayerMask.GetMask("Arrow")))
                {
                    _movingArrow = hit.transform.GetComponent<Arrow>();
                }
            }
            
            if (_movingArrow != null)
            {
                var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(_movingArrow.transform.position);
                var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
                if (angle < 0)
                {
                    angle = 360 + angle;
                }

                switch (_movingArrow.GetScale())
                {
                    case 360:
                        _hour = (angle/360) * 12;
                        
                        break;
                    case 60:
                        _minute = angle / 6;
                        break;
                    case 1:
                        _second = angle / 6;
                        break;
                }
                
                SetAlarmBtnOnAlarmChange(new TimeSpan((int)_hour, (int)_minute, (int)_second));
                
                if (Input.GetMouseButtonUp(0))
                {
                    _movingArrow = null;
                }
            }
            return CurrentTime;
        }
    }
}