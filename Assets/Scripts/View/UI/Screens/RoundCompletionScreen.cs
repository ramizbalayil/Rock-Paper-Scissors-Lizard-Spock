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

        public GameManager GameManager
        {
            get
            {
                if (gameManager == null)
                {
                    gameManager = GameManager.Instance;
                }
                return gameManager;
            }
        }
        #endregion

        #region Private Variables
        private GameManager gameManager;
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
            string summary;
            _playerScoreLabel.text = $"Score : {GameManager.Score}";

            _playerHandIcon.gameObject.SetActive(GameManager.PlayerConfig != null);

            _aIHandIcon.sprite = GameManager.AiConfig.UnitIcon;
            AudioManager.Instance.PlayUnitSFX(GameManager.AiConfig.UnitSound);

            _newHighScoreLabel.gameObject.SetActive(GameManager.Score > GameManager.HighScore);

            if (GameManager.PlayerConfig != null)
            {
                _playerHandIcon.sprite = GameManager.PlayerConfig.UnitIcon;
                summary = "Nice try! Try Again?";
            }
            else
            {
                summary = "You ran out of time!";
            }

            if (GameManager.Score > GameManager.HighScore)
            {
                summary = "You have a new HighScore!";
                _newHighScoreLabel.text = $"New High Score : {GameManager.Score}";
                AudioManager.Instance.PlayNewHighScoreVFX();
                GameManager.UpdateHighScore();
            }
            else
            {
                AudioManager.Instance.PlayLosingSFX();
            }

            _summaryLabel.text = summary;
        }
        #endregion
    }
}