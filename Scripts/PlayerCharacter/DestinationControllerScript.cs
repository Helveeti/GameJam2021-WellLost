using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationControllerScript
{
    private float x, y;
    private Vector2 position;

    private PlayerCharacterScript player;

    public DestinationControllerScript(float x, float y, Vector2 position)
    {
        this.x = x;
        this.y = y;
        this.position = position;
    }

    public void setPlayerInstance(PlayerCharacterScript player) {
        this.player = player;
    }

    public void move()
    {
        position.x = x;
        position.y = y;

        player.setPosition(position);

        player.prepareSprite();
        player.unFreeze();
    }

    public void freeFreeze()
    {
        player.prepareSprite();
        player.unFreeze();
    }
}
