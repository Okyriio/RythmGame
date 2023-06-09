using System.Collections;
using System.Collections.Generic;
using MidiJack;
using UnityEngine;
using UnityEngine.UIElements;

public class BeatScroller : MonoBehaviour
{
    public float beatTeampo;

    public bool hasStarted;
    // Start is called before the first frame update
    void Start()
    {
        beatTeampo = beatTeampo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
            transform.position -= new Vector3(0f, beatTeampo * Time.deltaTime,0f);
        }
    }
}
