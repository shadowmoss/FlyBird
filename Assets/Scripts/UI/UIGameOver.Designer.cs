using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:732da859-45eb-4f02-9931-12936aeea235
	public partial class UIGameOver
	{
		public const string Name = "UIGameOver";
		
		[SerializeField]
		public UnityEngine.UI.Text Title;
		[SerializeField]
		public UnityEngine.UI.Button BtnRestart;
		
		private UIGameOverData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Title = null;
			BtnRestart = null;
			
			mData = null;
		}
		
		public UIGameOverData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGameOverData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGameOverData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
