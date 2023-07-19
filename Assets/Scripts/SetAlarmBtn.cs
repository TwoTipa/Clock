﻿using System;
using Clock;
using TMPro;
using UnityEngine;

public class SetAlarmBtn : MonoBehaviour
{
    public static event Action<ClockTime> SwitchClock;
    [SerializeField] private TextMeshProUGUI me;
    private bool _isAlarmMode = false;
    
    public void SwitchMode()
    {
        _isAlarmMode = !_isAlarmMode;
        if (_isAlarmMode)
        {
            OnSwitchClock(new ClockAlarm());
        }
        else
        {
            OnSwitchClock(new ClockWatch());
        }
    }

    private static void OnSwitchClock(ClockTime obj)
    {
        SwitchClock?.Invoke(obj);
    }
}