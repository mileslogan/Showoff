using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float menuTimer;
    public float levelTimer;

    public bool levelStarted;
    public bool levelWon;

    public int currentLevel;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Manager");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        levelStarted = false;
        levelWon = false;
        menuTimer = 3;
        levelTimer = 0;
        currentLevel = 1;
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
        else if(levelStarted && !levelWon)
        {
            levelTimer += Time.deltaTime;
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
                if(currentLevel <= 5)
                {
                    SwitchLevel();
                }
                else if(currentLevel == 6)
                {
                    Application.Quit();
                }

            }
        }
    }

    void StartLevel()
    {
        levelStarted = true;
        menuTimer = 3;
        levelTimer = 0;
    }

    void SwitchLevel()
    {
        menuTimer = 3;
        if (currentLevel < 5)
        {
            levelStarted = false;
            levelWon = false;
        }
        currentLevel++;
        if(SceneManager.GetActiveScene().buildIndex <= 3)
        {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
        }
    }
}
