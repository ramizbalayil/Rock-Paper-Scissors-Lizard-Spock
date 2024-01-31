using RPSLS.Config;
using System;
using UnityEngine;

namespace RPSLS.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        #region Inspector Fields
        [SerializeField] private UnitData _unitData;
        #endregion

        #region Private Variables
        private int _score;
        private float _timer;
        private bool _gameRunning;
        private UnitConfig _aiConfig;
        #endregion

        #region Public Variables
        public Action OnTimerComplete;
        public Action<UnitConfig> OnUnitSelected;
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

        private void Update()
        {
            if (_gameRunning && _timer > 0)
            {
                _timer -= Time.deltaTime;
            }

            if (_gameRunning && _timer <= 0)
            {
                StopGame();
                OnTimerComplete?.Invoke();
            }
        }
        #endregion

        #region Public Methods
        public void StartGame()
        {
            _score = 0;
            _timer = _unitData.PlayerTurnTimer;
            _gameRunning = true;
            OnUnitSelected += OnUnitSelectedByPlayer;
            SetAIHand();
        }

        public void StopGame()
        {
            _gameRunning = false;
        }

        public UnitConfig GetAIHand()
        {
            return _aiConfig;
        }

        public float GetTimerProgress()
        {
            return _timer/_unitData.PlayerTurnTimer;
        }

        public float GetTimer()
        {
            return _timer;
        }
        #endregion

        #region Private Methods
        private void OnUnitSelectedByPlayer(UnitConfig config)
        {
            CompareHands(config, _aiConfig);
        }

        private void SetAIHand()
        {
            _aiConfig = _unitData.Data[UnityEngine.Random.Range(0, _unitData.Data.Count)];
        }

        private int CompareHands(UnitConfig playerConfig, UnitConfig aiConfig)
        {
            return 0;
        }
        #endregion
    }
}