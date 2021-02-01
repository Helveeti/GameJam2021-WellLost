using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkCycleScript
{
    private CountingScript count;

    private GameObject[] anim;
    private int index, time;

    public WalkCycleScript(GameObject[] anim)
    {
        count = new CountingScript();

        index = 0; time = 0;

        this.anim = anim;
        anim[0].SetActive(true);

        for (int i = 1; i < anim.Length; i++)
        {
            anim[i].SetActive(false);
        }
    }

    public void updateSprites(GameObject[] obj)
    {
        deactive(anim);
        anim = obj;
    }

    public void deactive(GameObject[] obj) {
        for(int i = 0; i < obj.Length; i++)
        {
            obj[i].SetActive(false);
        }
    }

    public void deactive()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetActive(false);
        }

        index = 0;
    }

    public void prepareSprite()
    {
        anim[index].SetActive(true);
    }

    public void changeSprite(Vector2 position, Vector2 targetPosition) {
        time += 1;

        if(time >= 10)
        {

            if(position.x > targetPosition.x)
            {
                anim[index].SetActive(false);
                index -= 1;
                if (index < 0) index = (anim.Length -1);
                anim[index].SetActive(true);
            }
            else if(position.x < targetPosition.x)
            {
                anim[index].SetActive(false);
                index += 1;
                if (index >= anim.Length) index = 0;
                anim[index].SetActive(true);
            }

            time = 0;
        }
    }
}
