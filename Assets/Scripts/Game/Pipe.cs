using System;
using UnityEngine;
using QFramework;

namespace QFramework.FlappyBird
{
	public partial class Pipe : ViewController
	{
		void Start()
		{
			// Code Here
		}

		public float Speed = 3;
		private bool mScoreAdded = false;
		
		private void FixedUpdate()
		{
			// Player在零点，
			if (transform.position.x < 0 && !mScoreAdded)
			{
				FlappyBird.Score.Value++;
				mScoreAdded = true;
				AudioKit.PlaySound("Score");
				Debug.Log("Add Score");
			}

			if(transform.position.x < -20){

				// gameObject.DestroySelf();
				PipeGenerator.PipePool.Recycle(this);
			}
			transform.LocalPositionX(transform.localPosition.x - 1 * Time.fixedDeltaTime);
		}

		public void ResetData()
		{
			mScoreAdded = false;
			this.Hide();
		}
	}
}
