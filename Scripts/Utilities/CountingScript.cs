using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountingScript
{
    public float countDiversition(float position, float targetPosition)
    {
        float bigger = 0, smaller = 0;

        if (targetPosition > position)
        {
            bigger = targetPosition;
            smaller = position;
        }
        else
        {
            bigger = position;
            smaller = targetPosition;
        }

        return bigger - smaller;
    }
}
