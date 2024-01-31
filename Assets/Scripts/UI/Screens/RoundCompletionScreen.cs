using System;
using UltimateClean;
using UnityEngine;

namespace RPSLS.UI
{
    public class RoundCompletionScreen : Screen
    {
        #region Properties
        public override string Id => nameof(RoundCompletionScreen);
        #endregion

        #region Inspector Fields
        [SerializeField] private CleanButton _mainMenuButton;
        [SerializeField] private CleanButton _nextRoundButton;
        #endregion

        #region Unity Methods
        private void OnEnable()
        {
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonPressed);
            _nextRoundButton.onClick.AddListener(OnNextRoundButtonPressed);
        }
        #endregion

        #region Private Methods
        private void OnMainMenuButtonPressed()
        {
            ScreenManager.Instance.Show(nameof(MenuScreen));
        }

        private void OnNextRoundButtonPressed()
        {
            ScreenManager.Instance.Show(nameof(RoundReadyScreen));
        }
        #endregion
    }
}