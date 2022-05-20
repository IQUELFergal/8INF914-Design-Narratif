using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementManager : MonoBehaviour
{
    Player player;
    new Rigidbody2D rigidbody2D;
    bool canMove = false;

    private void Awake()
    {
        player = GetComponent<Player>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    public void Move(Vector2 direction, float speed)
    {
        if (canMove)
        {
            rigidbody2D.velocity = direction * speed;
        }
    }

    public void Stop()
    {
        rigidbody2D.velocity = Vector2.zero;
    }
}
