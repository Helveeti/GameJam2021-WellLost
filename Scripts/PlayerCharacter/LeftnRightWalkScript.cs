using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftnRightWalkScript
{
    private CountingScript count;

    private GameObject[] left, right;
    private int index, time;

    public LeftnRightWalkScript(GameObject[] left, GameObject[] right)
    {
        count = new CountingScript();

        index = 0; time = 0;

        this.left = left;
        this.right = right;
        right[0].SetActive(true);

        for (int i = 1; i < right.Length; i++)
        {
            right[i].SetActive(false);
        }

        deactive(left);
    }

    public void updateSprites(GameObject[] left, GameObject[] right)
    {
        deactive(left, right);
        this.left = left;
        this.right = right;
    }

    public void deactive(GameObject[] obj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            obj[i].SetActive(false);
        }
    }

    public void deactive(GameObject[] left, GameObject[] right)
    {
        for (int i = 0; i < left.Length; i++)
        {
            left[i].SetActive(false);
            right[i].SetActive(false);
        }
    }

    public void deactive()
    {
        for (int i = 0; i < left.Length; i++)
        {
            left[i].SetActive(false);
            right[i].SetActive(false);
        }

        index = 0;
    }

    public void prepareSprite(string s)
    {
        if (s.Equals("Left"))
        {
            left[index].SetActive(true);
        }
        else
        {
            right[index].SetActive(true);
        }
    }

    public void changeSprite(Vector2 position, Vector2 targetPosition)
    {
        time += 1;

        if (time >= 10)
        {

            if (position.x > targetPosition.x)
            {
                deactive(right);

                left[index].SetActive(false);
                index -= 1;
                if (index < 0) index = (left.Length - 1);
                left[index].SetActive(true);
            }
            else if (position.x < targetPosition.x)
            {
                deactive(left);

                right[index].SetActive(false);
                index += 1;
                if (index >= right.Length) index = 0;
                right[index].SetActive(true);
            }

            time = 0;
        }
    }
}
