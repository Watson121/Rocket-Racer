using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour {

    int points;
    int boostPoints;

    GameObject pointTextGameObject;
    GameObject playerObject;
    RocketStats rocketStats;
    RocketControls rocketControls;

    Text pointText;
    float time;

	// Use this for initialization
	void Start () {
        pointTextGameObject = this.gameObject;
        pointText = pointTextGameObject.GetComponent<Text>();

        playerObject = GameObject.Find("Rocket");
        rocketStats = playerObject.GetComponent<RocketStats>();
        rocketControls = playerObject.GetComponent<RocketControls>();

        points = 0;
        time = 1;
    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;

        if (playerObject.activeSelf == true)
        {
            if (time < 0)
            {
                if (rocketControls.getBoost() == true)
                {
                    points = points + 100;
                }

                if (rocketStats.getHealth() == 3)
                {
                    points = points + 5;
                }
                else if (rocketStats.getHealth() == 2)
                {
                    points = points + 10;
                }
                else if (rocketStats.getHealth() == 1)
                {
                    points = points + 20;
                }
                time = 0.1f;
            }
         }
        
        
        pointText.text = points.ToString();
    }

    public int getPoints()
    {
        return points;
    }

}
