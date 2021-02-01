using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterScript : MonoBehaviour
{
    private PlayerModeController playerController;
    private CountingScript count;

    public GameObject[] headOff, headOn, torsoOnRight, torsoOnLeft, fullTorsoRight, fullTorsoLeft,
        fullBodyRight, fullBodyLeft, pushingLeft, pushingRight;
    public GameObject lightOff, lightOn;

    private bool freeze, animFreeze, jump, wallClimb, pushing;
    private bool firstXHit, xLeft, xRight;
    private float speed = 0.1f, time;

    private float horizontal, vertical;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        freeze = false; animFreeze = false; jump = false;
        firstXHit = false; xLeft = false; xRight = false;
        wallClimb = false; pushing = false;

        playerController = PlayerModeController.Instance;
        playerController.setModes(headOff, headOn, torsoOnRight, torsoOnLeft, fullTorsoRight, fullTorsoLeft,
            fullBodyRight, fullBodyLeft, pushingLeft, pushingRight, lightOff, lightOn);
        count = new CountingScript();

        time = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("Esc pressed.");
            Application.Quit();
        }else if (Input.GetKeyDown("up") && !(freeze))
        {
            jump = true;
        }

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 position = getPosition();
        Vector2 targetPosition = position;
        targetPosition.x = position.x + speed * horizontal;

        float x = count.countDiversition(targetPosition.x, position.x);
        float y = count.countDiversition(targetPosition.y, position.y);

        RaycastHit2D raycast = Physics2D.Raycast(position, targetPosition, 1);
        if(raycast.collider != null && raycast.collider.CompareTag("Wall"))
        {
            Vector3 nextPos = position;

            if(x > y && firstXHit != true) {
                firstXHit = true;

                if (targetPosition.x > position.x)
                {
                    xRight = true;
                    xLeft = false;
                }
                else
                {
                    xLeft = true;
                    xRight = false;
                }
            }

            if (xRight)
            {

                if (targetPosition.x < nextPos.x) nextPos.x = targetPosition.x;
                playerController.changeSprite(nextPos, position);
                rb.MovePosition(nextPos);
            }
            else if (xLeft)
            {
                if (targetPosition.x > nextPos.x) nextPos.x = targetPosition.x;
                playerController.changeSprite(nextPos, position);
                rb.MovePosition(nextPos);
            }

        }
        else if(freeze != true && animFreeze != true)
        {
            playerController.changeSprite(position, targetPosition);

            if (raycast.collider == null || (raycast.collider != null && !(raycast.collider.CompareTag("Wall"))))
            {
                xRight = false; xLeft = false;
                firstXHit = false;
            }

            if (jump)
            {
                float jumpHeight = playerController.getJumpHeight();

                time += 0.1f;

                if(time <= 1f)
                {
                    targetPosition.y += jumpHeight;
                }else if(time >= 1f && time <= 1.90f && !wallClimb){
                    targetPosition.y -= jumpHeight;
                }else if(time >= 1.90f || wallClimb && time >= 1f)
                {
                    jump = false;
                    time = 0f;
                }
            }

            rb.MovePosition(targetPosition);
        }else if (animFreeze)
        {
            playerController.deactive();
            animFreeze = false;
            freeze = true;
        }
    }

    public Vector2 getPosition()
    {
        return rb.position;
    }

    public void setPosition(Vector2 newPos)
    {
        rb.MovePosition(newPos);
    }

    public void prepareSprite()
    {
        playerController.prepareSprite();
    }

    public void levelUp()
    {
        playerController.levelUp();
    }

    public int getLevel()
    {
        return playerController.getLevel();
    }

    public void setFreeze()
    {
        freeze = true;
    }

    public void setAnimationFreeze()
    {
        animFreeze = true;
    }

    public void unFreeze()
    {
        freeze = false;
        animFreeze = false;
    }

    public void setWallJump(bool b)
    {
        wallClimb = b;
    }

    public void setPushing() {
        if (!pushing)
        {
            playerController.deactive();
            playerController.preparePushSprite();

            pushing = true;
        }
    }

    public void finishPushing()
    {
        if (pushing)
        {
            playerController.deactive();
            playerController.prepareSprite();

            pushing = false;
        }
    }
}
