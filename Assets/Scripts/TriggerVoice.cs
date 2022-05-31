using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVoice : MonoBehaviour
{
    private AudioSource voice;

    private void Start()
    {
        voice = transform.GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        { 
            Debug.Log("ontrigger");
            voice.Play();
        }
    }
}
