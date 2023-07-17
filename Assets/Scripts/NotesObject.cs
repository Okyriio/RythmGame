using System;
using System.Collections;
using System.Collections.Generic;
using MidiJack;
using UnityEngine;

public class NotesObject : MonoBehaviour
{
    // Start is called before the first frame update
  
    public KeyCode keyToPress;
    public bool canBePressed;
    public bool obtained = false;
	public ScreenShaker shake;
	private float _magn = 0.3f;
	private float _duration = 0.25f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress) && canBePressed)
        {
			shake.TriggerShake(_magn,_duration);
            obtained = true;
            gameObject.SetActive(false);
            GameManager.instance.NoteHit();
        }
        if (Input.GetKeyDown(keyToPress) && !canBePressed)
        {
            GameManager.instance.NoteMiss();
        }
	
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator" )
        {
            canBePressed = true;
        }
        
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" )
        {
            canBePressed = false;
            if (!obtained)
            {
                GameManager.instance.NoteMiss();

            }
        }
    }

  
}
