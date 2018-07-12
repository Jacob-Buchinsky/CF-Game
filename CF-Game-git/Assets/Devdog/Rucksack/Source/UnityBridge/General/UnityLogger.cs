using System;
using UnityEngine;

namespace Devdog.Rucksack
{
    public class UnityLogger : ILogger
    {
        private readonly string _prefix;
        public UnityLogger(string prefix = "")
        {
            _prefix = prefix;
        }
        
        public void LogVerbose(string msg, object instance = null)
        {
            Debug.Log(_prefix + msg, instance as UnityEngine.Object);
        }

        public void Log(string msg, object instance = null)
        {
            Debug.Log(_prefix + msg, instance as UnityEngine.Object);
        }

        public void Warning(string msg, object instance = null)
        {
            Debug.LogWarning(_prefix + msg, instance as UnityEngine.Object);
        }

        public void Error(string msg, object instance = null)
        {
            Debug.LogError(_prefix + msg, instance as UnityEngine.Object);
        }

        public void Error(string msg, Error error, object instance = null)
        {
            if (error != null)
            {
                Debug.LogError(_prefix + msg + "\n" + error, instance as UnityEngine.Object);
            }
        }
        
        public void Error(Exception exception, object instance = null)
        {
            if (exception != null)
            {
                Debug.LogError(_prefix + exception.Message, instance as UnityEngine.Object);
            }
        }
    }
}