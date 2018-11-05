using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Death : MonoBehaviour {

    float time;
    GameObject rocket;
    public GameObject exp; 

	// Use this for initialization
	void Start () {
        rocket = GameObject.Find("Rocket");
        time = 4;
        exp.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        exp.transform.position = rocket.transform.position;
        if (rocket.activeInHierarchy == false)
        {
            time -= Time.deltaTime;
            exp.SetActive(true);
           

            if (time < 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
