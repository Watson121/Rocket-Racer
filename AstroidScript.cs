using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidScript : MonoBehaviour {

    GameObject astroidObject;
    GameObject playerObject;
    GameObject shieldObject;

    RocketStats rocketStats;
    RocketControls rocketControls;
    ShieldHealth shieldHealth;

    Transform startPos;
    Transform endPos;
    float speed;
    int healthOfPlayer;

	// Use this for initialization
	void Start () {
        astroidObject = this.gameObject;
        playerObject = GameObject.Find("Rocket");
     
        rocketStats = playerObject.GetComponent<RocketStats>();
        rocketControls = playerObject.GetComponent<RocketControls>();
        
        speed = 3 * Time.deltaTime;
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
	void Update () {

        healthOfPlayer = rocketStats.getHealth();

        if (healthOfPlayer == 3)
        {
            speed = 3 * Time.deltaTime;
        }else if(healthOfPlayer == 2)
        {
            speed = 6 * Time.deltaTime;
        }else if(healthOfPlayer == 1)
        {
            speed = 9 * Time.deltaTime;
        }

        astroidObject.transform.position = Vector3.MoveTowards(transform.position, endPos.position, speed);

        if(astroidObject.transform.position == endPos.position)
        {
            Destroy(astroidObject);
        }

        if (playerObject.activeSelf == false)
        {
            Destroy(astroidObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "RocketMain")
        {
            rocketStats.decreaseHealth();
            Destroy(astroidObject);
        }

        if (rocketControls.getShield() == true)
        {
            shieldObject = GameObject.Find("Shield");
            shieldHealth = shieldObject.GetComponent<ShieldHealth>();

            if (other.tag == "Shield")
            {
                shieldHealth.decreaseHealth();
                Destroy(astroidObject);
            }
        }

    }
}
