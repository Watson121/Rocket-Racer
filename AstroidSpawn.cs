using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AstroidSpawn : MonoBehaviour {

    public GameObject astroidPrefab;
    GameObject rocket;
    Transform startPos;
    Transform endPos;
    [SerializeField]
    float spawnTime;

	// Use this for initialization
	void Start () {
        startPos = this.transform.GetChild(0);
        endPos = this.transform.GetChild(1);
        spawnTime = Random.Range(1, 6);
        rocket = GameObject.Find("Rocket");
    }
	
	// Update is called once per frame
	void Update () {


    if (rocket.activeSelf == true)
        {
            spawnTime -= Time.deltaTime;

            if(spawnTime < 0)
            {
                GameObject newAstroid;
                AstroidScript astroidScript;
                newAstroid = Instantiate(astroidPrefab, startPos.position, transform.rotation) as GameObject;
                astroidScript = newAstroid.GetComponent<AstroidScript>();
                astroidScript.setStart(startPos);
                astroidScript.setEnd(endPos);
                spawnTime = Random.Range(3,6);
            }      
        }
    }
}
