using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{

    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBs;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 50;
    public int currentMulti;
    public int multiplierTracker;
    public int[] multiplierTresh;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiText;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentMulti = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBs.hasStarted = true;
                theMusic.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("HIt on time");

        multiplierTracker++;

        if (currentMulti - 1 < multiplierTresh.Length)
        {
            if (multiplierTresh[currentMulti - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMulti++;
            }
        }

        multiText.text = "Multiplier: x" + currentMulti;
        
        currentScore += scorePerNote * currentMulti;
        scoreText.text = "Score:" + currentScore;
    }

    public void NoteMiss()
    {
        Debug.Log("MISSED IT");
        currentMulti = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMulti;
    }
}

