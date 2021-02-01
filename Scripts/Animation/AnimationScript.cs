using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public bool isStory, isEnding;
    private bool freeze;
    private StoryScript story;

    public GameObject[] anim;
    private int index;
    private float speed;
    public float time;

    private void Start()
    {
        story = new StoryScript();

        index = 0; speed = 0f;
        freeze = false;

        for (int i = 1; i < anim.Length; i++)
        {
            anim[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("Esc pressed.");
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        if (!freeze) 
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
        if (index >= anim.Length) {
            if (isStory)
            {
                story.nextScene();
            }
            else if (isEnding)
            {
                freeze = true;
                anim[anim.Length-1].SetActive(true);
                Debug.Log("Roll the credits.");
            }
            else
            {
                Destroy(this);
            }
        }
        else
        {
            anim[index].SetActive(true);
        }
    }
}
