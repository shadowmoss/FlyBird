using UnityEngine;
using UnityEngine.UI;
using QFramework;
using QFramework.FlappyBird;
using UnityEngine.SceneManagement;

namespace QFramework.Example
{
	public class UIGameOverData : UIPanelData
	{
	}
	public partial class UIGameOver : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIGameOverData ?? new UIGameOverData();
			// please add init code here
			BtnRestart.onClick.AddListener(() =>
			{
				CloseSelf();

				// 点击重新开始按钮之后，将装填转变为未开始状态
				FlappyBird.FlappyBird.GameState.Value = GameStates.NotStart;
				Time.timeScale = 1;
				
				// 获取当前活跃场景并重新加载
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
