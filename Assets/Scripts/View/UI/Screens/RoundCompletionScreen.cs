using RPSLS.Game;
using UltimateClean;
using UnityEngine;
using UnityEngine.UI;

namespace RPSLS.UI
{
    public class RoundCompletionScreen : Screen
    {
        #region Properties
        public override string Id => nameof(RoundCompletionScreen);
        #endregion

        #region Inspector Fields
        [SerializeField] private CleanButton _mainMenuButton;
        [SerializeField] private CleanButton _tryAgainButton;

        [SerializeField] private Image _playerHandIcon;
        [SerializeField] private Image _aIHandIcon;

        [SerializeField] private TMPro.TextMeshProUGUI _playerScoreLabel;
        [SerializeField] private TMPro.TextMeshProUGUI _summaryLabel;
        [SerializeField] private TMPro.TextMeshProUGUI _newHighScoreLabel;
        #endregion

        #region Unity Methods
        private void OnEnable()
        {
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonPressed);
            _tryAgainButton.onClick.AddListener(OnTryAgainButtonPressed);

            SetupScreen();
        }
        #endregion

        #region Private Methods
        private void OnMainMenuButtonPressed()
        {
            ScreenManager.Instance.Show(nameof(MenuScreen));
        }

        private void OnTryAgainButtonPressed()
        {
            ScreenManager.Instance.Show(nameof(RoundReadyScreen));
        }

        private void SetupScreen()
        {
            GameManager gameManager = GameManager.Instance;
            string summary = string.Empty; ;
            _playerScoreLabel.text = $"Score : {gameManager.Score}";

            _playerHandIcon.gameObject.SetActive(gameManager.PlayerConfig != null);

            _aIHandIcon.sprite = gameManager.AiConfig.UnitIcon;
            AudioManager.Instance.PlayUnitSFX(gameManager.AiConfig.UnitSound);

            if (gameManager.PlayerConfig != null)
            {
                _playerHandIcon.sprite = gameManager.PlayerConfig.UnitIcon;
                summary = "Nice try! Try Again?";
            }
            else
            {
                summary = "You ran out of time!";
            }

            if (gameManager.Score > gameManager.HighScore)
            {
                summary = "You hasve a new HighScore!";
                _newHighScoreLabel.text = $"New High Score : {gameManager.Score}";
                AudioManager.Instance.PlayNewHighScoreVFX();
                gameManager.UpdateHighScore();
            }
            else
            {
                AudioManager.Instance.PlayLosingSFX();
            }

            _summaryLabel.text = summary;
            _newHighScoreLabel.gameObject.SetActive(gameManager.Score > gameManager.HighScore);
        }
        #endregion
    }
}