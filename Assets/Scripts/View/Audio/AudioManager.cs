using UnityEngine;

namespace RPSLS.UI
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        #region Inspector Fields
        [Header("Audio Sources")]
        [SerializeField] private AudioSource _unitAudioSource;
        [SerializeField] private AudioSource _bgAudioSource;
        [SerializeField] private AudioSource _uIAudioSource;

        [Header("Audio Clips")]
        [SerializeField] private AudioClip _roundCompleteSFX;
        [SerializeField] private AudioClip _newHighScoreSFX;
        [SerializeField] private AudioClip _losingSFX;
        [SerializeField] private AudioClip _countdownTimer;
        [SerializeField] private AudioClip _gameTimer;

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
        #endregion

        #region Public Methods
        public void PlayUnitSFX(AudioClip clip)
        {
            _unitAudioSource.PlayOneShot(clip);
        }

        public void PlayBgSFX(AudioClip clip, bool loop = false)
        {
            _bgAudioSource.clip = clip;
            _bgAudioSource.loop = loop;
            _bgAudioSource.Play();
        }

        public void PlayUiSFX(AudioClip clip)
        {
            _uIAudioSource.PlayOneShot(clip);
        }

        public void PlayRoundCompleteSFX()
        {
            PlayBgSFX(_roundCompleteSFX);
        }

        public void PlayLosingSFX()
        {
            PlayBgSFX(_losingSFX);
        }

        public void PlayNewHighScoreVFX()
        {
            PlayBgSFX(_newHighScoreSFX);
        }

        public void PlayCountDownTimerSFX()
        {
            PlayBgSFX(_countdownTimer);
        }

        public void PlayTimerSFX()
        {
            PlayBgSFX(_gameTimer, true);
        }

        public void StopAllSounds()
        {
            _bgAudioSource.Stop();
            _unitAudioSource.Stop();
            _uIAudioSource.Stop();
        }
        #endregion
    }
}