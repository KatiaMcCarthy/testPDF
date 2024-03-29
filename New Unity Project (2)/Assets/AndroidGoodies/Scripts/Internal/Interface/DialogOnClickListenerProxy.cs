﻿
#if UNITY_ANDROID
namespace DeadMosquito.AndroidGoodies.Internal
{
	using System;
	using System.Diagnostics.CodeAnalysis;
	using JetBrains.Annotations;
	using UnityEngine;

	[SuppressMessage("ReSharper", "InconsistentNaming")]
	class DialogOnClickListenerProxy : AndroidJavaProxy
	{
		const string InterfaceSignature = "android.content.DialogInterface$OnClickListener";

		readonly Action _onClickVoid;
		readonly Action<int> _onClickInt;
		readonly bool _dismissOnClick;

		public DialogOnClickListenerProxy(Action onClick)
			: base(InterfaceSignature)
		{
			_onClickVoid = onClick;
		}

		public DialogOnClickListenerProxy(Action<int> onClick, bool dismissOnClick = false)
			: base(InterfaceSignature)
		{
			_onClickInt = onClick;
			_dismissOnClick = dismissOnClick;
		}

		[UsedImplicitly]
		public void onClick(AndroidJavaObject dialog, int which)
		{
			if (_onClickVoid != null)
			{
				GoodiesSceneHelper.Queue(_onClickVoid);
			}
			if (_onClickInt != null)
			{
				GoodiesSceneHelper.Queue(() => _onClickInt(which));
			}
			if (_dismissOnClick)
			{
				GoodiesSceneHelper.Queue(() => dialog.Call("dismiss"));
			}
		}
	}
}
#endif