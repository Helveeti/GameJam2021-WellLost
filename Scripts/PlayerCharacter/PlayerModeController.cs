using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModeController
{
    private static PlayerModeController instance = null;
    private WalkCycleScript walkCycle;
    private LeftnRightWalkScript advancedWalk;

    private GameObject[] headOff, headOn, torsoOnRight, torsoOnLeft, fullTorsoRight, fullTorsoLeft,
        fullBodyRight, fullBodyLeft, pushingLeft, pushingRight;
    private GameObject lightOff, lightOn;
    private int level;

    public static PlayerModeController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerModeController();
            }
            return instance;
        }
    }

    private PlayerModeController() {
        level = 0;
    }

    public WalkCycleScript getWalkInstance()
    {
        return walkCycle;
    }

    public void setModes(GameObject[] headOff, GameObject[] headOn, GameObject[] torsoOnRight, GameObject[] torsoOnLeft, GameObject[] fullTorsoRight, GameObject[] fullTorsoLeft, GameObject[] fullBodyRight, GameObject[] fullBodyLeft, GameObject[] pushingLeft, GameObject[] pushingRight, GameObject lightOff, GameObject lightOn)
    {
        this.headOff = headOff;
        this.headOn = headOn;
        this.torsoOnRight = torsoOnRight;
        this.torsoOnLeft = torsoOnLeft;
        this.fullTorsoRight = fullTorsoRight;
        this.fullTorsoLeft = fullTorsoLeft;
        this.fullBodyRight = fullBodyRight;
        this.fullBodyLeft = fullBodyLeft;
        this.pushingLeft = pushingLeft;
        this.pushingRight = pushingRight;

        this.lightOff = lightOff;
        this.lightOn = lightOn;

        walkCycle = new WalkCycleScript(headOff);
        advancedWalk = new LeftnRightWalkScript(torsoOnLeft, torsoOnRight);
        advancedWalk.deactive();
        advancedWalk.deactive(fullTorsoLeft, fullTorsoRight);
        advancedWalk.deactive(fullBodyLeft, fullBodyRight);
        advancedWalk.deactive(pushingLeft, pushingRight);
        walkCycle.deactive(headOn);
        walkCycle.deactive(torsoOnRight);
        walkCycle.deactive(torsoOnLeft);
        lightOff.SetActive(true);
        lightOn.SetActive(false);
    }

    public void levelUp()
    {
        level += 1;

        switch (level)
        {
            case 0:
                walkCycle.updateSprites(headOff);
                break;
            case 1:
                lightOff.SetActive(false);
                walkCycle.updateSprites(headOn);
                lightOn.SetActive(true);
                walkCycle.prepareSprite();
                break;
            case 2:
                advancedWalk.prepareSprite("Right");
                break;
            case 3:
                advancedWalk.updateSprites(fullTorsoLeft, fullTorsoRight);
                advancedWalk.prepareSprite("Left");
                break;
            case 4:
                advancedWalk.updateSprites(fullBodyLeft, fullBodyRight);
                advancedWalk.prepareSprite("Right");
                break;
        }
    }

    public void changeSprite(Vector2 position, Vector2 targetPosition)
    {
        if(level <= 1) walkCycle.changeSprite(position, targetPosition);
        else if(level >= 2) advancedWalk.changeSprite(position, targetPosition);
    }

    public void preparePushSprite()
    {
        advancedWalk.updateSprites(pushingLeft, pushingRight);
        advancedWalk.prepareSprite("Left");
    }

    public void prepareSprite()
    {
        if (level <= 1) walkCycle.prepareSprite();
        else if (level == 2) advancedWalk.prepareSprite("Left");
        else if (level == 4 && level == 3) advancedWalk.prepareSprite("Right");
    }

    public void deactive() 
    {
        if (level <= 1) walkCycle.deactive();
        else if (level >= 2) advancedWalk.deactive();
    }

    public float getJumpHeight() {
        float temp = 0f;

        switch (level)
        {
            case 0:
                temp = 0f;
                break;
            case 1:
                temp = 0.1f;
                break;
            case 2:
                temp = 0.2f;
                break;
            case 3:
                temp = 0.25f;
                break;
            case 4:
                temp = 0.3f;
                break;
        }

        return temp;
    }

    public int getLevel() {
        return level;
    }
}
