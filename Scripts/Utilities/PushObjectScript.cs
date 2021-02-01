using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObjectScript : MonoBehaviour
{
    private float horizontal;
    private Rigidbody2D rigib;

    private ProgressControlScript progCtrl;

    void Start()
    {
        progCtrl = ProgressControlScript.Instance;
        rigib = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCharacterScript obj = collision.GetComponent<PlayerCharacterScript>();

        if (obj != null)
        {
            if (progCtrl.getTryingOut())
            {
                Vector2 position = rigib.position;
                Vector2 targetPosition = position;
                targetPosition.x = position.x + 1f * horizontal;

                RaycastHit2D raycast = Physics2D.Raycast(position, targetPosition, 1);
                if (raycast.collider != null && raycast.collider.CompareTag("Wall"))
                {
                    Debug.Log("Wall.");
                }
                else if (targetPosition.x < position.x)
                {
                    //obj.setPushing();
                    rigib.MovePosition(targetPosition);
                }
            }
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerCharacterScript obj = collision.GetComponent<PlayerCharacterScript>();

        if (obj != null)
        {
            obj.finishPushing();
        }
    }
    */
}
