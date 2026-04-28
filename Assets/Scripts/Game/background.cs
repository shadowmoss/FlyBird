using System;
using UnityEngine;
using QFramework;

namespace QFramework.FlappyBird
{
	public partial class background : ViewController
	{
		void Start()
		{
			// Code Here
		}

		private void Update()
		{
			transform.Translate(-1f * Time.deltaTime, 0, 0);
		}
	}
}
