using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed;
    public float spd1;
    public float spd2;
    public float spd3;
    public float spd4;

    public float decelspd;

    public float time1;
    public float time2;
    public float time3;

    public float timeBetweenPress;

    public float distanceToFinish;
    public GameObject endWall;

    bool won;

    Rigidbody2D rb;

    Animator myAnim;

    GameObject managerObject;
    GameManager managerScript;

    // Start is called before the first frame update
    void Start()
    {
        managerObject = GameObject.Find("ManagerHolder");
        managerScript = managerObject.GetComponent<GameManager>();

        endWall = GameObject.Find("EndWall");
        rb = this.GetComponent<Rigidbody2D>();
        myAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (managerScript.levelStarted && !managerScript.levelWon)
        {
            distanceToFinish = endWall.transform.position.x - transform.position.x;

            timeBetweenPress += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(timeBetweenPress < time3)
                {
                    speed = spd4;
                }
                else if(timeBetweenPress < time2 && timeBetweenPress > time3)
                {
                    speed = spd3;
                }
                else if (timeBetweenPress < time1 && timeBetweenPress > time2)
                {
                    speed = spd2;
                }
                else
                {
                    speed = spd1;
                }

                timeBetweenPress = 0;
            }

            rb.velocity = new Vector2(speed, 0f);
            speed *= decelspd;

        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            speed = 0;
        }

        if(speed > 0.1)
        {
            myAnim.SetBool("Schmovin", true);
            myAnim.speed = speed * 0.1f;
        }
        else
        {
            myAnim.SetBool("Schmovin", false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "wall")
        {
            speed = 0;
            myAnim.SetBool("Schmovin", false);
            managerScript.levelWon = true;
        }
        else if (collision.tag == "breakOne")
        {
            spd1 *= 0.5f;
            spd2 *= 0.5f;
            spd3 *= 0.5f;
            spd4 *= 0.5f;
        }
        else if (collision.tag == "breakTwo")
        {
            spd1 *= 0.3f;
            spd2 *= 0.3f;
            spd3 *= 0.3f;
            spd4 *= 0.3f;
        }
    }
}
