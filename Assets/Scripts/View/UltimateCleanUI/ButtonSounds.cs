// Copyright (C) 2015-2021 gamevanilla - All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement.
// A Copy of the Asset Store EULA is available at http://unity3d.com/company/legal/as_terms.

using RPSLS.UI;
using UnityEngine;

namespace UltimateClean
{
    /// <summary>
    /// This component goes together with a button object and contains
    /// the audio clips to play when the player rolls over and presses it.
    /// </summary>
    public class ButtonSounds : MonoBehaviour
    {
        public AudioClip pressedSound;
        public AudioClip rolloverSound;

        public void PlayPressedSound()
        {
            AudioManager.Instance.PlayUiSFX(pressedSound);
        }

        public void PlayRolloverSound()
        {
            AudioManager.Instance.PlayUiSFX(rolloverSound);
        }
    }
}