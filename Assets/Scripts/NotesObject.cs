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
    [SerializeField] private GameObject _keyPos;
    public GameObject missEffect, perfectEffect;
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
            //GameManager.instance.NoteHit();
            if (Math.Abs(transform.position.y ) > Math.Abs(_keyPos.transform.position.y + 0.15) )
            {
                Debug.Log("NormalHit");
                GameManager.instance.NormalHit();
               
            }
            else if (Math.Abs(transform.position.y ) > Math.Abs(_keyPos.transform.position.y + 0.05) )
            {
               
                Debug.Log("GoodHit");
                GameManager.instance.GoodHit();
            }
            else  
            {
                Debug.Log("PerfectHit");
                GameManager.instance.PerfectHit();
                Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
            }
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
                Instantiate(missEffect, transform.position, perfectEffect.transform.rotation);

            }
        }
    }

  
}
