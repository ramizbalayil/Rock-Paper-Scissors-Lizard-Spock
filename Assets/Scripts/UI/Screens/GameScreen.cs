using RPSLS.Game;
using System;
using System.Collections.Generic;
using UltimateClean;
using UnityEngine;

namespace RPSLS.UI
{
    public class GameScreen : Screen
    {
        #region Properties
        public override string Id => nameof(GameScreen);
        public GameManager GameManager
        {
            get
            {
                if (_gameManager == null)
                {
                    _gameManager = GameManager.Instance;
                }
                return _gameManager;
            }
        }
        #endregion

        #region Inspector Fields
        [SerializeField] private Unit _aiUnit;
        [SerializeField] private SlicedFilledImage _timerProgress;
        [SerializeField] private TMPro.TextMeshProUGUI _timerLabel;

        #endregion

        #region Private Variables
        private GameManager _gameManager;
        #endregion

        #region Unity Methods
        private void OnEnable()
        {
            GameManager.StartGame();
            GameManager.OnTimerComplete += OnTimerComplete;

            _aiUnit.SetupUnit(GameManager.GetAIHand());
        }

        private void Update()
        {
            _timerProgress.fillAmount = GameManager.GetTimerProgress();
            _timerLabel.text = $"Timer : {Mathf.CeilToInt(GameManager.GetTimer())}s";
        }

        private void OnDisable()
        {
            GameManager.OnTimerComplete -= OnTimerComplete;
        }
        #endregion

        #region Private Methods
        private void OnTimerComplete()
        {
            ScreenManager.Instance.Show(nameof(RoundCompletionScreen));
        }
        #endregion
    }
}