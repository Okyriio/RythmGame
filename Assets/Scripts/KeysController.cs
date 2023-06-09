using System.Collections;
using System.Collections.Generic;
using MidiJack;
using UnityEngine;

public class KeysController : MonoBehaviour
{
    private SpriteRenderer _spRend;
    public Sprite KeysDefault;

    public Sprite KeysPressed;
    
    public MidiChannel keyToPress;

    public int noteNumber;

    
    // Start is called before the first frame update
    void Start()
    {
        _spRend = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
      if (MidiDriver.Instance.GetKeyDown(keyToPress, noteNumber))
      {
          _spRend.sprite = KeysPressed;
      }
      
      if (MidiDriver.Instance.GetKeyUp(keyToPress, noteNumber))
      {
          _spRend.sprite = KeysDefault;
      }
        
    }
}
