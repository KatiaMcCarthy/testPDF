#if UNITY_ANDROID
namespace DeadMosquito.AndroidGoodies.Internal
{
	using System;

	public class AndroidAlarmManager
	{
		const int RTC_WAKEUP = 0;

		public static void SetExact(AndroidIntent intent, DateTime when)
		{
			AGSystemService.AlarmService.Call("setExact", RTC_WAKEUP, CalcMillis(when),
				AndroidPendingIntent.GetBroadcast(intent.AJO));
		}

		static long CalcMillis(DateTime when)
		{
			return AGUtils.CurrentTimeMillis + when.ToMillisSinceEpoch() - DateTime.Now.ToMillisSinceEpoch();
		}

		public static void Set(AndroidIntent intent, DateTime when)
		{
			AGSystemService.AlarmService.Call("set", RTC_WAKEUP, CalcMillis(when),
				AndroidPendingIntent.GetBroadcast(intent.AJO));
		}

		public static void SetRepeating(AndroidIntent intent, DateTime when, long intervalMillis)
		{
			AGSystemService.AlarmService.Call("setRepeating", RTC_WAKEUP, CalcMillis(when), intervalMillis, 
				AndroidPendingIntent.GetBroadcast(intent.AJO));
		}
	}
}
#endif