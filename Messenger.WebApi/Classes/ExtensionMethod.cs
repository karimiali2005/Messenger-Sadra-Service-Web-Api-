using System;

namespace Messenger.WebApi.Classes
{
    public static class ExtensionMethod
    {
        public static void ToSaveElmah(this System.Exception exception)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
         
        }

        /// <summary>
        /// اختلاف دو زمان بدست می آورد
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static DateTime ChangeTime(this DateTime dateTime, int hours, int minutes, int seconds, int milliseconds)
        {

            return new DateTime(
                ((DateTime)dateTime).Year,
                ((DateTime)dateTime).Month,
                ((DateTime)dateTime).Day,
                hours,
                minutes,
                seconds,
                milliseconds,
                ((DateTime)dateTime).Kind);
        }
    }
}