using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed;
    public float spd1;
    public float spd2;
    public float spd3;

    public float decelspd;

    public float time1;
    public float time2;

    public float timeBetweenPress;

    public float distanceToFinish;
    public GameObject endWall;

    bool won;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        endWall = GameObject.Find("EndWall");
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!won)
        {
            distanceToFinish = endWall.transform.position.x - transform.position.x;

            timeBetweenPress += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(timeBetweenPress < time2)
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
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "wall")
        {
            won = true;
        }
    }
}
