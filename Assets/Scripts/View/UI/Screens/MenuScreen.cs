using RPSLS.Game;
using System;
using UltimateClean;
using UnityEngine;
using UnityEngine.UI;

namespace RPSLS.UI
{
    public class MenuScreen : Screen
    {
        #region Properties
        public override string Id => nameof(MenuScreen);
        #endregion

        #region Unity Methods
        private void Start()
        {
            GameManager.Instance.OnHighScoreUpdated += OnHighScoreUpdated;
        }

        private void Destroy()
        {
            GameManager.Instance.OnHighScoreUpdated -= OnHighScoreUpdated;
        }
        #endregion

        #region Inspector Fields
        [SerializeField] private CleanButton _playButton;
        [SerializeField] private TMPro.TextMeshProUGUI _highScoreLabel;
        #endregion

        #region Public Methods

        public void OnPlayButtonPressed()
        {
            ScreenManager.Instance.Show(nameof(RoundReadyScreen));
        }
        #endregion

        #region Private Methods
        private void OnHighScoreUpdated(int highScore)
        {
            _highScoreLabel.text = $"HighScore : {highScore}";
        }
        #endregion
    }
}