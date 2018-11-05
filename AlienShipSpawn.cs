using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShipSpawn : MonoBehaviour {

    #region GameObjects
    public GameObject alienShip;
    GameObject pointsObject;
    GameObject rocketObject;
    #endregion

    public Animator spaceShipAnimator;

    #region Components
    Points points;
    RocketControls rocketControls;
    #endregion
    bool spawnShip;

    public float timeSpawned;
    public float timeToSpawn;

	// Use this for initialization
	void Start () {
        alienShip = GameObject.Find("mothership_fbx");
       
        pointsObject = GameObject.Find("Points");
        rocketObject = GameObject.Find("Rocket");

        points = pointsObject.GetComponent<Points>();
        rocketControls = rocketObject.GetComponent<RocketControls>();
        //spaceShipAnimator = alienShip.GetComponent<Animator>();

        spawnShip = false;

        timeToSpawn = 60;
        timeSpawned = 30;
        //alienShip.SetActive(false);

    }

    void Awake()
    {
        alienShip = GameObject.Find("mothership_fbx");
        spaceShipAnimator = alienShip.GetComponent<Animator>();
        spaceShipAnimator.SetBool("Leave", false);
    }


    // Update is called once per frame
    void Update () {

        SpawningShip();

        if (alienShip.activeSelf == true)
        {
           
            

            if (timeSpawned < 5)
            {
                spaceShipAnimator.SetBool("Leave", true);
            }

            timeSpawned -= Time.deltaTime;
            if (rocketControls.getNumberOfBoostsUsed() == 3 || timeSpawned < 0)
            {
                spawnShip = false;
                timeSpawned = Random.Range(15, 30);
            }

        }

        timeToSpawn -= Time.deltaTime;

        if (points.getPoints() == 1000 || timeToSpawn < 0)
        {
            spawnShip = true;
            timeToSpawn = Random.Range(40, 60);
        }

        

        
    

	}

    void SpawningShip()
    {
        if(spawnShip == true)
        {
            alienShip.SetActive(true);
        }else if(spawnShip == false)
        {
            alienShip.SetActive(false);
        }
    }

}
