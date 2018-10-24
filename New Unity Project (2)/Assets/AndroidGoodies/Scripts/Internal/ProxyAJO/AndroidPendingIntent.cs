#if UNITY_ANDROID
namespace DeadMosquito.AndroidGoodies.Internal
{
	using UnityEngine;

	/// <summary>
	/// Android pending intent.
	/// </summary>
	static class AndroidPendingIntent
	{
		const int FLAG_UPDATE_CURRENT = 1 << 27;

		public static AndroidJavaObject GetActivity(AndroidJavaObject intent)
		{
			using (var pic = new AndroidJavaClass(C.AndroidAppPendingIntent))
			{
				return pic.CallStaticAJO("getActivity", AGUtils.Activity, 0, intent, FLAG_UPDATE_CURRENT);
			}
		}
		
		public static AndroidJavaObject GetBroadcast(AndroidJavaObject intent)
		{
			using (var pic = new AndroidJavaClass(C.AndroidAppPendingIntent))
			{
				return pic.CallStaticAJO("getBroadcast", AGUtils.Activity, 0, intent, FLAG_UPDATE_CURRENT);
			}
		}
	}
}
#endif