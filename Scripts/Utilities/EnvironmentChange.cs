using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentChange : MonoBehaviour
{
    public GameObject before;
    public GameObject after;
    public GameObject coll;

    private ProgressControlScript progCtrl;

    private void Start()
    {
        progCtrl = ProgressControlScript.Instance;
        before.SetActive(true);
        after.SetActive(false);
        coll.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerCharacterScript player = collision.GetComponent<PlayerCharacterScript>();

        if(player != null && progCtrl.getFlyer())
        {
            before.SetActive(false);
            after.SetActive(true);
            coll.SetActive(false);

            progCtrl.setBridge();

            Destroy(this);
        }
    }
}
