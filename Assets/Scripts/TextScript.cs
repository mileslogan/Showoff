using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public GameObject textBox;

    public Text topText;
    public Text middleText;
    public Text timeText;

    public GameObject waitObject;
    public Text waitText;

    public GameObject pressObject;
    public Text pressText;

    public RectTransform iconTransform;
    Vector3 iconPos1 = new Vector3 (-46.5f, 8f, 0);
    Vector3 iconPos2 = new Vector3 (52.5f, 32.3f, 0);

    GameObject managerObject;
    GameManager managerScript;

    int menuTimerInt;
    float levelTimerCondensed;

    public string Top11;
    public string Top12;
    public string Top21;
    public string Top22;
    public string Top31;
    public string Top32;
    public string Top41;
    public string Top42;
    public string Top51;
    public string Top52;
    public string Top53;

    public string Middle11;
    public string Middle21;
    public string Middle31;
    public string Middle41;
    public string Middle51;
    public string Middle52;
    public string Middle53;

    public string Middle02;

    public string Press1;
    public string Press2;
    public string Press3;

    // Start is called before the first frame update
    void Start()
    {
        managerObject = GameObject.Find("ManagerHolder");
        managerScript = managerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!managerScript.levelStarted || managerScript.levelWon)
        {
            textBox.SetActive(true);
            DisplayText(managerScript.currentLevel);
        }
        else
        {
            textBox.SetActive(false);
        }

    }

    void DisplayText(int level)
    {
        if(managerScript.menuTimer > 0)
        {
            pressObject.SetActive(false);
            waitObject.SetActive(true);
            menuTimerInt = Mathf.FloorToInt(managerScript.menuTimer);
            waitText.text = "Wait " + menuTimerInt + " sec";
        }
        else
        {
            pressObject.SetActive(true);
            waitObject.SetActive(false);
        }

        if(level == 1 && !managerScript.levelStarted)
        {
            topText.text = Top11;
            middleText.alignment = TextAnchor.UpperLeft;
            middleText.text = Middle11;
            timeText.enabled = false;
            pressText.text = Press1;
            iconTransform.localPosition = iconPos1;
        }
        else if (level == 1 && managerScript.levelWon)
        {
            topText.text = Top12;
            middleText.alignment = TextAnchor.MiddleLeft;
            middleText.text = Middle02;
            timeText.enabled = true;
            LevelTimerToTenth();
            timeText.text = levelTimerCondensed + " sec";
            pressText.text = Press2;
            iconTransform.localPosition = iconPos2;
        }

        if (level == 2 && !managerScript.levelStarted)
        {
            topText.text = Top21;
            middleText.alignment = TextAnchor.UpperLeft;
            middleText.text = Middle21;
            timeText.enabled = false;
            pressText.text = Press1;
            iconTransform.localPosition = iconPos1;
        }
        else if (level == 2 && managerScript.levelWon)
        {
            topText.text = Top22;
            middleText.alignment = TextAnchor.MiddleLeft;
            middleText.text = Middle02;
            timeText.enabled = true;
            LevelTimerToTenth();
            timeText.text = levelTimerCondensed + " sec";
            pressText.text = Press2;
            iconTransform.localPosition = iconPos2;
        }

        if (level == 3 && !managerScript.levelStarted)
        {
            topText.text = Top31;
            middleText.alignment = TextAnchor.UpperLeft;
            middleText.text = Middle31;
            timeText.enabled = false;
            pressText.text = Press1;
            iconTransform.localPosition = iconPos1;

        }
        else if (level == 3 && managerScript.levelWon)
        {
            topText.text = Top32;
            middleText.alignment = TextAnchor.MiddleLeft;
            middleText.text = Middle02;
            timeText.enabled = true;
            LevelTimerToTenth();
            timeText.text = levelTimerCondensed + " sec";
            pressText.text = Press2;
            iconTransform.localPosition = iconPos2;
        }

        if (level == 4 && !managerScript.levelStarted)
        {
            topText.text = Top41;
            middleText.alignment = TextAnchor.UpperLeft;
            middleText.text = Middle41;
            timeText.enabled = false;
            pressText.text = Press1;
            iconTransform.localPosition = iconPos1;
        }
        else if (level == 4 && managerScript.levelWon)
        {
            topText.text = Top42;
            middleText.alignment = TextAnchor.MiddleLeft;
            middleText.text = Middle02;
            timeText.enabled = true;
            LevelTimerToTenth();
            timeText.text = levelTimerCondensed + " sec";
            pressText.text = Press2;
            iconTransform.localPosition = iconPos2;
        }

        if (level == 5 && !managerScript.levelStarted)
        {
            topText.text = Top51;
            middleText.alignment = TextAnchor.UpperLeft;
            middleText.text = Middle51;
            timeText.enabled = false;
            pressText.text = Press1;
            iconTransform.localPosition = iconPos1;

        }
        else if (level == 5 && managerScript.levelWon)
        {
            topText.text = Top52;
            middleText.alignment = TextAnchor.UpperLeft;
            middleText.text = Middle52;
            timeText.enabled = false;
            pressText.text = Press3;
            iconTransform.localPosition = iconPos2;
        }
        else if (level == 6)
        {
            topText.text = Top53;
            middleText.alignment = TextAnchor.UpperLeft;
            middleText.text = Middle53;
            timeText.enabled = false;
            pressText.text = Press3;
            iconTransform.localPosition = iconPos2;
        }
    }

    void LevelTimerToTenth()
    {
        levelTimerCondensed = managerScript.levelTimer * 10f;
        levelTimerCondensed = Mathf.FloorToInt(levelTimerCondensed);
        levelTimerCondensed *= .1f;
    }
}
