using System.Collections.Generic;
using UnityEngine;

namespace RPSLS.UI
{
    public class ScreenManager : MonoBehaviour
    {
        public static ScreenManager Instance { get; private set; }

        #region Inspector Fields
        [SerializeField] private Screen _startScreen;
        [SerializeField] private List<Screen> _screens;
        #endregion

        #region Private Variables
        private string _currentScreenId;
        #endregion

        #region Unity Methods
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }
            Instance = this;
        }

        private void Start()
        {
            _currentScreenId = string.Empty;
            HideAllScreens();
            Show(_startScreen.Id);
        }
        #endregion

        #region Public Methods
        public void Show(string screenId)
        {
            if (_currentScreenId == screenId) return;

            HideAllScreens();
            foreach (Screen screen in _screens)
            {
                if (screen.Id == screenId)
                {
                    _currentScreenId = screenId;
                    screen.gameObject.SetActive(true);
                }
            }
        }
        #endregion

        #region Private Methods
        private void HideAllScreens()
        {
            foreach (Screen screen in _screens)
            {
                screen.gameObject.SetActive(false);
            }
        }
        #endregion
    }
}