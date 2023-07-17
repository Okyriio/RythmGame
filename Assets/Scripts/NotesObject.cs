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
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress) && canBePressed)
        {
            obtained = true;
            gameObject.SetActive(false);
            GameManager.instance.NoteHit();
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
