using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
// ReSharper disable once RedundantUsingDirective ; Used by Preprocessor Directive
using UnityEngine;

namespace BrutalHack.Aleron.Shared.Util
{
    public class Logger
    {
        private static readonly CultureInfo British = new CultureInfo("en-GB");
        public static bool OmitTimestamp = false;

        public static void Log(string message,
            [CallerMemberName] string callerMemberName = "",
            [CallerFilePath] string callerFilePath = "",
            [CallerLineNumber] int callerLineNumber = 0)
        {
            Thread.CurrentThread.CurrentCulture = British;
            string timestamp = string.Empty;

            if (OmitTimestamp == false)
            {
                timestamp = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff");
            }

            string logMessage = string.Format("{0}: {1}->{2}:{3}\n{4}",
                timestamp, callerFilePath, callerMemberName, callerLineNumber, message);
#if UNITY_5_3_OR_NEWER
            Debug.Log(logMessage);
#else
            Console.WriteLine(logMessage);
#endif
        }
    }
}