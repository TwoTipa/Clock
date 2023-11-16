using System;
using System.Collections;
using DefaultNamespace;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Networking;

namespace Clock
{
    public class ClockWatch : ClockTime
    {

        private string _firstSrver = "https://worldtimeapi.org/api/timezone/Europe/Moscow";
        private string _secondSrver = "https://worldtimeapi.org/api/timezone/Europe/Moscow";
        
        private float _timezone;
        public override ClockTime Initialisation(float timezone)
        {
            _timezone = timezone;
            SendGetRequest();
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
                SendGetRequest();
            }
        }
        
        
        private async System.Threading.Tasks.Task<Task> SendGetRequest()
        {
            UnityWebRequest webRequest = UnityWebRequest.Get(_firstSrver);

            webRequest.SendWebRequest();
            await System.Threading.Tasks.Task.Delay(1000);
            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                ServerResponse requestTime = JsonUtility.FromJson<ServerResponse>(webRequest.downloadHandler.text);
                SetCurrentTime(DateTime.Parse(requestTime.utc_datetime));
            }
            else
            {
                Debug.Log("Error");
            }

            return null;
        }

        private void SetCurrentTime(DateTime time)
        {
            Debug.Log(time);
            CurrentTime = new TimeSpan(time.Hour, time.Minute, time.Second);
        }
        [Serializable]
        private class ServerResponse
        {
            public string utc_datetime;
            public string datetime;
        }
    }
    
}
