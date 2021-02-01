using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderTextScript : MonoBehaviour
{
    private ProgressControlScript progCtrl;

    public bool isFlyer, isVineBridge, isTryingOut;

    public string[] line;
    public Text textKupla;
    public GameObject background, extraBackground;
    public int showExBg, endExBg;

    private PlayerCharacterScript player;
    private bool active;
    private float timer;
    private char[] letters;
    private int index, lineRound;
    private string tempLine;

    private int tryingOutCount;

    private void Start()
    {
        progCtrl = ProgressControlScript.Instance;

        letters = line[0].ToCharArray();
        textKupla.text = "";
        background.SetActive(false);
        active = false;
        timer = 2f; index = 0; lineRound = 0;
        tryingOutCount = 0;

        if (extraBackground != null) extraBackground.SetActive(false);
    }

    private void Update()
    {
        if (active)
        {
            player.setFreeze();
            background.SetActive(true);

            timer -= 0.1f;
            if (timer <= 0 && index < letters.Length)
            {
                timer += 1f;
                tempLine += letters[index];
                textKupla.text = tempLine;
                index += 1;
            }
            else if (Input.GetKeyDown("space") && index >= letters.Length)
            {
                lineRound += 1;

                if (lineRound >= showExBg && lineRound <= endExBg) extraBackground.SetActive(true);
                else if (extraBackground != null) extraBackground.SetActive(false);

                if (lineRound < line.Length)
                {
                    index = 0;
                    textKupla.text = "";
                    tempLine = null;
                    letters = null;
                    letters = line[lineRound].ToCharArray();
                    timer += 1f;
                }
                else if (lineRound >= line.Length)
                {
                    textKupla.text = "";
                    player.unFreeze();
                    background.SetActive(false);

                    if(isFlyer)
                    {
                        ProgressControlScript.Instance.setFlyer();
                    }else if (isTryingOut)
                    {
                        ProgressControlScript.Instance.setTryingOut();
                    }

                    Destroy(this);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        player = other.GetComponent<PlayerCharacterScript>();

        if (player != null && (isVineBridge && progCtrl.getFlyer()) || player != null && !isVineBridge)
        {
            if (isTryingOut && tryingOutCount <= 3) {
                tryingOutCount += 1;
            }
            else active = true;
        }
    }
}
