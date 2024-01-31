using RPSLS.Config;
using System;
using UltimateClean;
using UnityEngine;
using UnityEngine.UI;

namespace RPSLS.Game
{
    public class Unit : MonoBehaviour
    {
        #region Properties
        public UnitConfig UnitConfig => _unitConfig;
        #endregion

        #region Inspector Variables
        [Header("Config")]
        [SerializeField] private UnitConfig _unitConfig;

        [Header("Unit Properties")]
        [SerializeField] private bool _isAI;

        [Header("Components")]
        [SerializeField] private Image _unitIcon;
        [SerializeField] private TMPro.TextMeshProUGUI _unitLabel;
        [SerializeField] private CleanButton _unitButton;
        #endregion

        #region Unity Methods
        private void Awake()
        {
            SetupUnit(_unitConfig);
            if (!_isAI)
            {
                _unitButton.onClick.AddListener(OnUnitSelected);
            }
        }
        #endregion

        #region Public Methods
        public void SetupUnit(UnitConfig unitConfig)
        {
            if (unitConfig != null)
            {
                _unitIcon.sprite = unitConfig.UnitIcon;
                _unitLabel.text = unitConfig.UnitName;
            }
            _unitConfig = unitConfig;
        }
        #endregion

        #region Private Methods
        private void OnUnitSelected()
        {
            GameManager.Instance.OnUnitSelected.Invoke(_unitConfig);
        }
        #endregion
    }
}