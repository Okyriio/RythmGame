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
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress) && canBePressed)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator" )
        {
            canBePressed = true;
        }
    }

  
}
