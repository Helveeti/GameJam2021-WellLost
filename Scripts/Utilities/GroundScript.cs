using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerCharacterScript player = other.GetComponent<PlayerCharacterScript>();

        if (player)
        {
            Debug.Log("Ground detected. " + rigid.position.y);
        }
    }
}
