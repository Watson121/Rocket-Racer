using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RocketStats : MonoBehaviour {

    int health;
    GameObject rocketObject;
    public float time;
    GameObject bottomPart, middlePart, topPart;
    GameObject fire1, fire2, exp1, exp2;

	// Use this for initialization
	void Start () {

        bottomPart = GameObject.Find("Rocket_bottom");
        middlePart = GameObject.Find("Rocket_middle");
        topPart = GameObject.Find("Rocket_top");

        fire1 = GameObject.Find("SmallFire1");
        fire2 = GameObject.Find("SmallFire2");
        exp1 = GameObject.Find("SmallExp1");
        exp2 = GameObject.Find("SmallExp2");

        health = 3;
        rocketObject = this.gameObject;
        time = 4;

        fire1.SetActive(false);
        fire2.SetActive(false);
        exp1.SetActive(false);
        exp2.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if(health == 2)
        {
            bottomPart.SetActive(false);
            fire1.SetActive(true);
            exp1.SetActive(true);
        }
        else if(health == 1)
        {
            middlePart.SetActive(false);
            fire1.SetActive(false);
            exp1.SetActive(false);
            fire2.SetActive(true);
            exp2.SetActive(true);
        }

		if(health == 0)
        {
            rocketObject.SetActive(false);
           

        }
	}

    public int getHealth()
    {
        return health;
    }

    public void increaseHealth()
    {
        if (health != 3)
        {
            health++;
        }
    }

    public void decreaseHealth()
    {
        if (health != 0)
        {
            health--;
        }
    }



}
