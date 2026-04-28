using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.FlappyBird
{
	// Generate Id:05d6b468-4eb8-4891-bb9d-e089d08a25f6
	public partial class UIGamePanel
	{
		public const string Name = "UIGamePanel";
		
		[SerializeField]
		public UnityEngine.UI.Text BestScore;
		[SerializeField]
		public UnityEngine.UI.Text ScoreText;
		[SerializeField]
		public UnityEngine.UI.Text TapToStartText;
		
		private UIGamePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BestScore = null;
			ScoreText = null;
			TapToStartText = null;
			
			mData = null;
		}
		
		public UIGamePanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGamePanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGamePanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
