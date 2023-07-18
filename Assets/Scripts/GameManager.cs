using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBs;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 50;
    public int scorePerGoodNote = 75;
    public int scorePerPerfectNote = 100;
    public int currentMulti;
    public int multiplierTracker;
    public int[] multiplierTresh;

    public float totalNotes, normalHitNotes, perfectHitNotes, missHitNotes;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiText;

    public GameObject endScreen;
    public TextMeshProUGUI normalScoreText, perfectScoreText,missedScoreText, totalNotesText,totalScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentMulti = 1;
        totalNotes = FindObjectsOfType<NotesObject>().Length;
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
        else
        {
            if (!theMusic.isPlaying && !endScreen.activeInHierarchy)
            {
                endScreen.SetActive(true);
                normalScoreText.text = "" + normalHitNotes;
                perfectScoreText.text = "" + perfectHitNotes;
                missedScoreText.text = "" + missHitNotes;
                totalNotesText.text = "" + totalNotes;
                totalScoreText.text = "" + currentScore;
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
        // currentScore += scorePerNote * currentMulti;
        scoreText.text = "Score:" + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote* currentMulti;
        normalHitNotes++;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote* currentMulti;
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote* currentMulti;
        perfectHitNotes++;
        NoteHit();
    }

    public void NoteMiss()
    {
        Debug.Log("MISSED IT");
        currentMulti = 1;
        missHitNotes++;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMulti;
    }
}

