using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
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
        }else if (progCtrl.getClimbed())
        {
            SceneManager.LoadScene("EndingScene");
        }
    }

    private void nextChange()
    {
        anim[index].SetActive(false);
        index += 1;
        if (index >= anim.Length)
        {
            index = 0;
            unfreeze = false;
            speed = 0;
            progCtrl.setClimbed();
        }
        else
        {
            anim[index].SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        PlayerCharacterScript player = coll.GetComponent<PlayerCharacterScript>();

        if (player != null && progCtrl.getDoorActive())
        {
            player.setAnimationFreeze();
            unfreeze = true;
            anim[0].SetActive(true);
        }
    }
}
