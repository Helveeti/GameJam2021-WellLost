using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressControlScript
{
    private static ProgressControlScript instance = null;

    private bool flyer, bridgeSet, tryingOut, activateDoor, climbedOff;

    public static ProgressControlScript Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ProgressControlScript();
            }
            return instance;
        }
    }

    private ProgressControlScript()
    {
        flyer = false;
        bridgeSet = false;
        tryingOut = false;
        activateDoor = false;
        climbedOff = false;
    }

    public void setFlyer()
    {
        flyer = true;
    }

    public bool getFlyer()
    {
        return flyer;
    }

    public void setBridge()
    {
        bridgeSet = true;
    }

    public bool getBridge()
    {
        return bridgeSet;
    }

    public void setTryingOut()
    {
        tryingOut = true;
    }

    public bool getTryingOut()
    {
        return tryingOut;
    }

    public void setDoorActive()
    {
        activateDoor = true;
    }

    public bool getDoorActive()
    {
        return activateDoor;
    }

    public void setClimbed()
    {
        climbedOff = true;
    }

    public bool getClimbed()
    {
        return climbedOff;
    }

}
