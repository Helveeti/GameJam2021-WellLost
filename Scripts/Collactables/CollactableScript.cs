using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollactableScript : MonoBehaviour
{
    private PlayerCharacterScript controller;

    public GameObject[] anim;
    private int index;
    public float time;
    private bool unfreeze, destruct;
    private float speed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.rotation = 45f;

        speed = 0f;

        /* Pick up animation */

        unfreeze = false; destruct = false;
        index = 0; time = 0f;

        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if (unfreeze)
        {
            if(index == 0)
            {
                anim[0].SetActive(true);
                index += 1;
            }
            else if (time >= 20f)
            {
                anim[0].SetActive(false);
                nextChange();
                time = 0;
            }

            time += 1f;
        }
        else
        {
            if (speed >= 3f)
            {
                rb.rotation += 1f;
                speed = 0;
            }

            speed += 1f;
        }
    }

    private void nextChange()
    {
        anim[index].SetActive(false);
        index += 1;
        if (index >= anim.Length)
        {
            destruct = true;
            unfreeze = false;
        }
        else anim[index].SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        PlayerCharacterScript controller = coll.GetComponent<PlayerCharacterScript>();

        if (controller != null)
        {
            controller.setAnimationFreeze();
            unfreeze = true;
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        PlayerCharacterScript controller = coll.GetComponent<PlayerCharacterScript>();

        if (controller != null && destruct)
        {
            controller.levelUp();
            controller.unFreeze();
            Destroy(gameObject);
        }

    }
}
