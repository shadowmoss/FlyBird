using System;
using UnityEngine;
using QFramework;

namespace QFramework.FlappyBird
{
	public partial class GameController : ViewController
	{
		void Start()
		{
			// Code Here
			UIKit.Root.SetResolution(720,1280,1);
			UIKit.OpenPanel<UIGamePanel>();
		}

		private void OnDestroy()
		{
			try
			{
				// UIKit.ClosePanel<UIGamePanel>();
			}
			catch (Exception _)
			{
				
			}
		}
	}
}
