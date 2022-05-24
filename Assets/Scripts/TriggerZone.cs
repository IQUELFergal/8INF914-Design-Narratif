using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] UnityEvent eventTriggeredOnEnter;
    [SerializeField] UnityEvent eventTriggeredOnStay;
    [SerializeField] UnityEvent eventTriggeredOnExit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            eventTriggeredOnEnter?.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            eventTriggeredOnStay?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            eventTriggeredOnExit?.Invoke();
        }
    }
}
