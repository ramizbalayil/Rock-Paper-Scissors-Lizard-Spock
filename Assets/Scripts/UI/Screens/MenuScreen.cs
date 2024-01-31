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

        #region Inspector Fields
        [SerializeField] private CleanButton _playButton;
        #endregion

        #region Public Methods

        public void OnPlayButtonPressed()
        {
            ScreenManager.Instance.Show(nameof(RoundReadyScreen));
        }
        #endregion
    }
}