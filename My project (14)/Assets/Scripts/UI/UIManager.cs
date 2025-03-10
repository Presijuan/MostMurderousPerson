using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;

public class UIManager : MonoBehaviour
{
    private WaveManager waveManager;
    public TMP_Text wave;
    public TMP_Text score;
    public TMP_Text bullets;
    public TMP_Text health;
    
    void Update()
    {
        string waveText = "Wave: " + (int) waveManager.currentRound;
        wave.text = waveText;
    }
    void LateUpdate()
    {
        
    }
}
