using RPSLS.Config;
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
        [SerializeField] private TMPro.TextMeshProUGUI _scoreLabel;

        #endregion

        #region Private Variables
        private GameManager _gameManager;
        #endregion

        #region Unity Methods
        private void OnEnable()
        {
            GameManager.OnGameOver += OnGameOver;
            GameManager.OnAIHandSet += OnGameReset;
            GameManager.OnRoundComplete += OnRoundComplete;
            GameManager.StartGame();
        }

        private void Update()
        {
            _timerProgress.fillAmount = GameManager.GetTimerProgress();
            _timerLabel.text = $"Timer : {Mathf.CeilToInt(GameManager.GetTimer())}s";
            _scoreLabel.text = $"Score : {GameManager.Score}";
        }

        private void OnDisable()
        {
            GameManager.OnGameOver -= OnGameOver;
            GameManager.OnAIHandSet -= OnGameReset;
            GameManager.OnRoundComplete -= OnRoundComplete;
        }
        #endregion

        #region Private Methods
        private void OnGameOver()
        {
            ScreenManager.Instance.Show(nameof(RoundCompletionScreen));
        }

        private void OnGameReset(UnitConfig aiConfig)
        {
            AudioManager.Instance.PlayTimerSFX();
            _aiUnit.SetupUnit(aiConfig);
        }

        private void OnRoundComplete(UnitConfig config)
        {
            AudioManager.Instance.PlayRoundCompleteSFX();
            AudioManager.Instance.PlayUnitSFX(config.UnitSound);
        }
        #endregion
    }
}