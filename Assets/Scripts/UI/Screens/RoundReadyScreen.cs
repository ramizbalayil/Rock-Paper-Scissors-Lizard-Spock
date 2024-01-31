using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RPSLS.UI
{
    public class RoundReadyScreen : Screen
    {
        #region Properties
        public override string Id => nameof(RoundReadyScreen);
        #endregion

        #region Inspector Fields
        [SerializeField] private List<Animator> _animators;
        [SerializeField] private TextMeshProUGUI _timerLabel;

        #endregion

        #region Private Variables
        private readonly int READY_HASH = Animator.StringToHash("READY");
        private float _timer = 0f;
        #endregion

        #region Unity Methods

        private void OnEnable()
        {
            _timer = 3f;
            PlayAnimators(READY_HASH);
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            _timerLabel.text = _timer <= 0f ? "GO!" : Mathf.CeilToInt(_timer).ToString();
            if (_timer <= -1f)
            {
                ScreenManager.Instance.Show(nameof(GameScreen));
            }
        }
        #endregion

        #region Private Methods
        private void PlayAnimators(int hash)
        {
            foreach (Animator animator in _animators)
            {
                animator.Play(hash);
            }
        }
        #endregion
    }
}