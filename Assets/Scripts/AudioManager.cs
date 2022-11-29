using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public void TurnSoundOn() {
        AudioListener.pause = false;
    }

    public void TurnSoundOff() {
        AudioListener.pause = true;
    }
}