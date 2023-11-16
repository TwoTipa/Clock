using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldToTime : MonoBehaviour
{
    public TMP_InputField inputField;
    public string pattern = @"^([0-1]?[0-9]|2[0-3]):([0-5][0-9])$";


    private void Start()
    {
        inputField.text = "00";
    }

    public void OnInputFieldValueChanged(TMP_InputField input)
    {
        // Проверяем, соответствует ли введенный текст формату времени
        if (Regex.IsMatch(inputField.text, pattern))
        {
            // Если формат верен, обновляем текст в поле ввода
            inputField.text = inputField.text;
        }
        else
        {
            // Если формат неверный, очищаем текст в поле ввода
            if(this.inputField.text.Length > 0) inputField.text = inputField.text.Substring(0, inputField.text.Length-1);
        }
    }
}
