using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushedObjectTargetScript : MonoBehaviour
{
    public GameObject activate, pushedBarrel, placedBarrel;
    private ProgressControlScript progCtrl;

    private void Start()
    {
        activate.SetActive(false);
        pushedBarrel.SetActive(true);
        placedBarrel.SetActive(false);

        progCtrl = ProgressControlScript.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PushObjectScript obj = collision.GetComponent<PushObjectScript>();

        if(obj != null)
        {
            activate.SetActive(true);
            pushedBarrel.SetActive(false);
            placedBarrel.SetActive(true);
            Destroy(obj);
            progCtrl.setDoorActive();
            Destroy(this);
        }
    }
}
