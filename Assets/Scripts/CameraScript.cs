using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public MovementScript playerScript;

    GameObject managerObject;
    GameManager managerScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<MovementScript>();

        managerObject = GameObject.Find("ManagerHolder");
        managerScript = managerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(managerScript.currentLevel <= 4)
        {
            if (playerScript.distanceToFinish >= 15f)
            {
                transform.position = new Vector3(player.transform.position.x + 7.31f, transform.position.y, transform.position.z);
            }
        }
        else if (managerScript.currentLevel >=5)
        {
            transform.position = new Vector3(player.transform.position.x + 7.31f, transform.position.y, transform.position.z);
        }
    }
}
