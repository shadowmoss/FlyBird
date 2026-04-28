using System.Collections;
using System.Collections.Generic;
using QFramework;
using QFramework.Example;
using UnityEngine;

namespace QFramework.FlappyBird
{
    public enum GameStates
    {
        NotStart,
        Started,
        GameOver
    }

    public class FlappyBird : Architecture<FlappyBird>
    {
        public static BindableProperty<int> Score = new BindableProperty<int>();
        public static BindableProperty<int> BestScore = new BindableProperty<int>();
        public static BindableProperty<GameStates> GameState = new BindableProperty<GameStates>();
        protected override void Init()
        {
            GameState.RegisterWithInitValue(state =>
            {
                if (state == GameStates.Started)
                {
                    Score.Value = 0;
                }
                else if (state == GameStates.GameOver)
                {
                    
                    // Debug.Log("Game Over!");
                    Time.timeScale = 0;
                    UIKit.OpenPanel<UIGameOver>();
                }
                else if(state == GameStates.NotStart)
                {
                    Time.timeScale = 1;
                }
            });

            BestScore.Value = PlayerPrefs.GetInt(nameof(BestScore));
            BestScore.Register(bestScore =>
            {
                PlayerPrefs.SetInt(nameof(BestScore),bestScore);
            });
            Score.RegisterWithInitValue(score =>
            {
                if (score > BestScore.Value)
                {
                    BestScore.Value = score;
                }
            });
        }
        // 这个类似于Java的注解的方法，应该涉及C#的反射工具集。我记得是叫Attribute。
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void InitFramework()
        {
            ResKit.Init();
            var _ = FlappyBird.Interface;
        }
    }
}

