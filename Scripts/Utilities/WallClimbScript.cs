using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimbScript : MonoBehaviour
{
    private bool wallDetected;

    private void Start()
    {
        wallDetected = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCharacterScript player = collision.GetComponent<PlayerCharacterScript>();

        if(player != null)
        {
            player.setWallJump(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerCharacterScript player = collision.GetComponent<PlayerCharacterScript>();

        if (player != null)
        {
            player.setWallJump(false);
        }
    }
}
