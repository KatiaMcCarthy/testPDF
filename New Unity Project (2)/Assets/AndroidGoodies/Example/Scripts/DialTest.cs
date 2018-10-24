
namespace AndroidGoodiesExamples
{
	#if UNITY_ANDROID
	using DeadMosquito.AndroidGoodies;
#endif
	using JetBrains.Annotations;
	using UnityEngine;

	public class DialTest : MonoBehaviour
	{
#if UNITY_ANDROID
		const string PhoneNumber = "123456789";

		[UsedImplicitly]
		public void OnShowDialer()
		{
			AGDialer.OpenDialer(PhoneNumber);
		}

		[UsedImplicitly]
		public void OnPlaceCall()
		{
			AGDialer.PlacePhoneCall(PhoneNumber);
		}
#endif
	}
}
