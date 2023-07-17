using System.Collections;
using System.Collections.Generic;
using MidiJack;
using UnityEngine;

public class KeysController : MonoBehaviour
{
    private SpriteRenderer _spRend;
    public Sprite KeysDefault;

    public Sprite KeysPressed;
    
    public KeyCode keyToPress;


    
    // Start is called before the first frame update
    void Start()
    {
        _spRend = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(keyToPress))
      {
          _spRend.sprite = KeysPressed;
      }
      
      if (Input.GetKeyUp(keyToPress))
      {
          _spRend.sprite = KeysDefault;
      }
        
    }
}
