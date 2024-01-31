using RPSLS.Config;
using RPSLS.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RPSLS.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        #region Inspector Fields
        [SerializeField] private UnitData _unitData;
        #endregion

        #region Properties
        public UnitConfig AiConfig => _aiConfig;
        public UnitConfig PlayerConfig => _playerConfig;
        public int Score => _score;
        #endregion

        #region Private Variables
        private int _score;
        private float _timer;
        private bool _gameRunning;
        private UnitConfig _aiConfig;
        private UnitConfig _playerConfig;

        private List<List<int>> _outcomeMatrix = new List<List<int>> {
            new List<int> { 0, -1, 1, 1, -1 },  // ROCK
            new List<int> { 1, 0, -1, -1, 1 },  // PAPER 
            new List<int> { -1, 1, 0, 1, -1 },  // SCISSORS
            new List<int> { -1, 1, -1, 0, 1 },  // LIZARD
            new List<int> { 1, -1, 1, -1, 0 },  // SPOCK
        };

        private int[][] _outcomeMatrix1 = new int[][] {
            new int[] { 0, -1, 1, 1, -1 },    // ROCK
            new int[] { 1, 0, -1, -1, 1 },    // PAPER 
            new int[] { -1, 1, 0, 1, -1 },    // SCISSORS
            new int[] { -1, 1, -1, 0, 1 },    // LIZARD
            new int[] { 1, -1, 1, -1, 0 },    // SPOCK
        };
        #endregion

        #region Public Variables
        public Action OnGameOver;
        public Action<UnitConfig> OnAIHandSet;
        public Action<UnitConfig> OnUnitSelected;
        public Action<UnitConfig> OnRoundComplete;
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
            }
        }
        #endregion

        #region Public Methods
        public void StartGame()
        {
            _score = 0;
            OnUnitSelected += OnUnitSelectedByPlayer;
            ResetGame();
        }

        public void ResetGame()
        {
            _gameRunning = true;
            _timer = _unitData.PlayerTurnTimer;
            _aiConfig = null;
            _playerConfig = null;

            SetAIHand();

            OnAIHandSet?.Invoke(_aiConfig);
        }

        public void StopGame()
        {
            _gameRunning = false;
            OnUnitSelected -= OnUnitSelectedByPlayer;
            OnGameOver?.Invoke();
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

        private void CompareHands(UnitConfig playerConfig, UnitConfig aiConfig)
        {
            _gameRunning = false;

            int result = _outcomeMatrix[(int)playerConfig.UnitType][(int)aiConfig.UnitType];
            if (result == -1)
            {
                _playerConfig = playerConfig;
                StopGame();
            }
            else
            {
                _score += 1;
                OnRoundComplete(playerConfig);
                ResetGame();
            }
        }
        #endregion
    }
}