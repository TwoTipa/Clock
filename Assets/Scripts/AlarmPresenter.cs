using System;
using Clock;
using TMPro;
using UnityEngine;

public class AlarmPresenter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI alarm;
    private void Start()
    {
        if (PlayerPrefs.GetInt("AlarmHour") != 0)
        {
            alarm.text = $"Будильник прозвенит в {PlayerPrefs.GetInt("AlarmHour")}:{PlayerPrefs.GetInt("AlarmMinutes")}";
        }
        else
        {
            alarm.text = "Установите будильник";
        }
    }

    private void OnEnable()
    {
        ClockAlarm.SetAlarm += SetAlarmBtnOnSetAlarm;
    }

    private void OnDisable()
    {
        ClockAlarm.SetAlarm -= SetAlarmBtnOnSetAlarm;
    }

    private void SetAlarmBtnOnSetAlarm(TimeSpan obj)
    {
        PlayerPrefs.SetInt("AlarmHour", obj.Hours);
        PlayerPrefs.SetInt("AlarmMinutes", obj.Minutes);
        alarm.text = $"Будильник прозвенит в {obj}";
        PlayerPrefs.Save();
    }
}