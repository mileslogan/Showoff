using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float menuTimer;

    public bool levelStarted;
    public bool levelWon;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Manager");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelStarted && !levelWon)
        {
            if(menuTimer > 0)
            {
                menuTimer -= Time.deltaTime;
            }
            else
            {
                menuTimer = 0;
            }

            if (Input.GetKeyDown(KeyCode.Space) && menuTimer <= 0)
            {
                StartLevel();
            }
        }

        if (levelWon)
        {
            if(menuTimer > 0)
            {
                menuTimer -= Time.deltaTime;
            }
            else
            {
                menuTimer = 0;
            }

            if (Input.GetKeyDown(KeyCode.Space) && menuTimer <= 0)
            {
                SwitchLevel();
            }
        }
    }

    void StartLevel()
    {
        levelStarted = true;
        menuTimer = 3;
    }

    void SwitchLevel()
    {
        menuTimer = 3;
        levelStarted = false;
        levelWon = false;
        //increase index by 1
    }
}
