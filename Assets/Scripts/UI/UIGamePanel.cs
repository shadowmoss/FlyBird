using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UnityEngine.SocialPlatforms.Impl;

namespace QFramework.FlappyBird
{
	public class UIGamePanelData : UIPanelData
	{
	}
	public partial class UIGamePanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGamePanelData ?? new UIGamePanelData();
			// please add init code here
			FlappyBird.BestScore.RegisterWithInitValue(bestScore =>
			{
				BestScore.text = "Best Score: " + bestScore;
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
			
			FlappyBird.Score.RegisterWithInitValue(score =>
			{
				ScoreText.text = ""+score;
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
			
			ScoreText.Hide();
			
			FlappyBird.GameState.RegisterWithInitValue(states =>
			{
				Debug.Log("调用了状态变更事件");
				if (states == GameStates.NotStart)
				{
					Debug.Log("进入了开始状态GamePanel");
					ScoreText.Hide();
					TapToStartText.Show();
				}
				else if (states == GameStates.Started)
				{
					ScoreText.Show();
					TapToStartText.Hide();
				}
				else if (states == GameStates.GameOver)
				{
					ScoreText.Hide();
					TapToStartText.Hide();
				}
			});
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}
	}
}
