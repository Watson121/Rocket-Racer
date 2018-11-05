using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCloud : MonoBehaviour {

    GameObject gasObject;
    GameObject playerObject;
    RocketStats rocketStats;
    RocketControls rocketControls;

    Transform startPos;
    Transform endPos;
    float speed;
    int healthOfPlayer;

    // Use this for initialization
    void Start()
    {

        gasObject = this.gameObject;
        playerObject = GameObject.Find("Rocket");
        rocketStats = playerObject.GetComponent<RocketStats>();
        rocketControls = playerObject.GetComponent<RocketControls>();
        speed = 8 * Time.deltaTime;
        healthOfPlayer = rocketStats.getHealth();
    }

    public void setStart(Transform start)
    {
        startPos = start;
    }

    public void setEnd(Transform end)
    {
        endPos = end;
    }

    // Update is called once per frame
    void Update()
    {

        healthOfPlayer = rocketStats.getHealth();

        gasObject.transform.position = Vector3.MoveTowards(transform.position, endPos.position, speed);

        if (gasObject.transform.position == endPos.position)
        {
            Destroy(gasObject);
        }

        if (playerObject.activeSelf == false)
        {
            Destroy(gasObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (rocketControls.getFilter() == false)
        {
            if (other.tag == "RocketMain")
            {
                rocketStats.decreaseHealth();
            }
        }
        else if (rocketControls.getFilter() == true)
        {
            if (other.tag == "Filter")
            {


            }
        }

    }
}
