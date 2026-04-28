using System;
using System.Collections;
using UnityEngine;
using QFramework;
using QFramework.Example;
using QFramework.FlappyBird;

namespace QFramework.FlappyBird
{
	public partial class Player : ViewController
	{
		private Rigidbody2D mRigidbody2D;

		public float JumpSpeed = 5f;

		public SpriteRenderer mRender;

		private bool mCheckPlayerInScreen = false;
		
		// 协程是什么
		IEnumerator Start()
		{
			// Code Here
			mRigidbody2D = GetComponent<Rigidbody2D>();
			mRender = GetComponent<SpriteRenderer>();
			yield return new WaitForEndOfFrame();

			mCheckPlayerInScreen = true;
			FlappyBird.GameState.RegisterWithInitValue(state =>
			{
				if (state == GameStates.NotStart)
				{
					mRigidbody2D.bodyType = RigidbodyType2D.Static;
				}
				else
				{
					mRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
				}
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				Debug.Log("点击了鼠标左键");
				if (FlappyBird.GameState.Value == GameStates.NotStart)
				{
					Debug.Log("进入开始状态");
					FlappyBird.GameState.Value = GameStates.Started;
				}

				if (FlappyBird.GameState.Value == GameStates.Started)
				{
					mRigidbody2D.velocity = Vector2.up * JumpSpeed;
					AudioKit.PlaySound("Jump");
				}
			}

			if (mRigidbody2D.velocity.y > 0)
			{
				var angleZ = Mathf.Lerp(0,30,mRigidbody2D.velocity.y/5);
				transform.localEulerAngles = new Vector3(0, 0, angleZ);
			}
			else
			{
				var angleZ = Mathf.Lerp(0, -30, Mathf.Abs(mRigidbody2D.velocity.y / 5));
				transform.localEulerAngles = new Vector3(0, 0, angleZ);
			}


			if (mCheckPlayerInScreen && !mRender.isVisible)
			{
				GameOver();
			}
		}

		private void OnCollisionEnter2D(Collision2D col)
		{
				GameOver();
		}

		// private void OnGUI()
		// {
		// 	IMGUIHelper.SetDesignResolution(720*0.5f,1280*0.5f);
		// 	GUILayout.Label("Score:" + FlappyBird.Score.Value);
		// 	GUILayout.Label("BestScore:" + FlappyBird.BestScore.Value);
		// }

		void GameOver()
		{
			if (FlappyBird.GameState.Value == GameStates.Started)
			{
				FlappyBird.GameState.Value = GameStates.GameOver;
				AudioKit.PlaySound("Die");
			}
		}
	}
}
