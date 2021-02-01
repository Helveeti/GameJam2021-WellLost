using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbScript : MonoBehaviour
{
    public bool isVineBridge, reUsable;

    public float x, y;
    private DestinationControllerScript destination;
    private ProgressControlScript progCtrl;

    public GameObject[] anim;
    private int index;
    private float speed;
    public float time;
    private bool unfreeze;

    private void Start()
    {
        progCtrl = ProgressControlScript.Instance;

        index = 0; speed = 0.0f;
        unfreeze = false;

        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (unfreeze)
        {
            if (speed >= time)
            {
                nextChange();
                speed = 0;
            }

            speed += 1;
        }
    }

    private void nextChange()
    {
        anim[index].SetActive(false);
        index += 1;
        if (index >= anim.Length)
        {
            destination.move();
            destination.freeFreeze();

            if(!reUsable) Destroy(this);
            else
            {
                index = 0;
                unfreeze = false;
                speed = 0;
            }
        }
        else
        {
            anim[index].SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        PlayerCharacterScript player = coll.GetComponent<PlayerCharacterScript>();

        if(player != null && player.getLevel() >= 2 && !isVineBridge || player != null && progCtrl.getBridge() && isVineBridge)
        {
            player.setAnimationFreeze();
            destination = new DestinationControllerScript(x, y, player.getPosition());
            destination.setPlayerInstance(player);
            unfreeze = true;
            anim[0].SetActive(true);
        }
    }
}
