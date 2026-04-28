using System;
using UnityEngine;
using QFramework;
using QFramework.Example;
using Unity.Mathematics;
using Random = UnityEngine.Random;

namespace QFramework.FlappyBird
{
	public partial class PipeGenerator : ViewController
	{
		public float DurationMin = 2;
		public float DurationMax = 3;
		public static SimpleObjectPool<Pipe> PipePool;
		void Start()
		{
			// Code Here
			PipeTemplate.Hide();
			mGenerateTime = Time.time; // 当前时间
			mDuration = Random.Range(DurationMin, DurationMax);
			
			PipePool = new SimpleObjectPool<Pipe>(()=>{ 
				return PipeTemplate.Instantiate().Hide(); 
				// 这里应该涉及到四元数的内容
				 }, (pipe) =>
			{
				pipe.ResetData();
			},5);
		}

		private float mGenerateTime = 0;
		private float mDuration = 0;
		private void Update()
		{
			if (FlappyBird.GameState.Value == GameStates.NotStart)
			{
				return;
			}

			if (Time.time - mGenerateTime > mDuration)
			{
				mGenerateTime = Time.time;
				mDuration = Random.Range(DurationMin, DurationMax);

				Pipe pipe = PipePool.Allocate();
				pipe.Position(PipeGeneratePos.position)
					.LocalPositionY(Random.Range(5,-2)) // 这里应该涉及到四元数的内容
					.Show();
			}
		}

		private void OnDestroy()
		{
			PipePool.Clear();
			// PipePool = null;
		}
	}
}
