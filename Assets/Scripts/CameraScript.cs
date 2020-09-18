using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public MovementScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<MovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.distanceToFinish >= 15f)
        {
            transform.position = new Vector3(player.transform.position.x + 7.31f, transform.position.y, transform.position.z);
        }
    }
}
