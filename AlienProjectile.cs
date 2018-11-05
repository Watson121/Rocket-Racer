using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienProjectile : MonoBehaviour {

    GameObject alienObject;
    GameObject playerObject;
    public GameObject shieldObject;

    RocketStats rocketStats;
    RocketControls rocketControls;
    ShieldHealth shieldHealth;

    Transform startPos;
    Transform endPos;
    float speed;
    int healthOfPlayer;

    // Use this for initialization
    void Start () {

        alienObject = this.gameObject;
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
    void Update () {

        healthOfPlayer = rocketStats.getHealth();

        alienObject.transform.position = Vector3.MoveTowards(transform.position, endPos.position, speed);

        if (alienObject.transform.position == endPos.position)
        {
            Destroy(alienObject);
        }

        if (playerObject.activeSelf == false)
        {
            Destroy(alienObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RocketMain")
        {
            rocketStats.decreaseHealth();
            Destroy(alienObject);
        }

        if (rocketControls.getShield() == true)
        {
            shieldObject = GameObject.Find("Shield");
            shieldHealth = shieldObject.GetComponent<ShieldHealth>();

            if (other.tag == "Shield")
            {
                shieldHealth.decreaseHealth();
                Destroy(alienObject);
            }
        }

    }

}
