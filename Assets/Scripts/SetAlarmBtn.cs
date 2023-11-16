using System;
using Clock;
using TMPro;
using UnityEngine;

public class SetAlarmBtn : MonoBehaviour
{
    public static event Action<ClockTime> SwitchClock;
    public static event Action<TimeSpan> AlarmChange;
    [SerializeField] private TextMeshProUGUI me;
    [SerializeField] private GameObject inpFld;
    [SerializeField] private TMP_InputField hourInp;
    [SerializeField] private TMP_InputField minuteInp;
    private bool _isAlarmMode = false;
    
    public void SwitchMode()
    {
        _isAlarmMode = !_isAlarmMode;
        inpFld.SetActive(_isAlarmMode);
        if (_isAlarmMode)
        {
            me.text = "Подтверить";
            OnSwitchClock(new ClockAlarm());
        }
        else
        {
            me.text = "Установить будильник";
            //SetAlarm?.Invoke(new TimeSpan(Convert.ToInt32(hourInp.text),  Convert.ToInt32(minuteInp.text), 0));
            OnSwitchClock(new ClockWatch());
        }
    }

    public void onAlarmChange()
    {
        TimeSpan time = new TimeSpan(Convert.ToInt32(hourInp.text)+0, Convert.ToInt32(minuteInp.text)+0, 0);
        AlarmChange?.Invoke(time);
    }

    private static void OnSwitchClock(ClockTime obj)
    {
        SwitchClock?.Invoke(obj);
    }
}