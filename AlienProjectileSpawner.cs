using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienProjectileSpawner : MonoBehaviour {

    public GameObject alienProjectilePrefab;
    GameObject rocket;
    Transform startPos;
    Transform endPos;
    [SerializeField]
    float spawnTime;


    // Use this for initialization
    void Start () {
        startPos = this.gameObject.transform;
        endPos = this.transform.GetChild(0);
        spawnTime = 3;
        rocket = GameObject.Find("Rocket");
    }
	
	// Update is called once per frame
	void Update () {

        if (rocket.activeSelf == true)
        {
            spawnTime -= Time.deltaTime;

            if (spawnTime < 0)
            {
                GameObject newProjectile;
                AlienProjectile alienProjectile;
                newProjectile = Instantiate(alienProjectilePrefab, startPos.position, transform.rotation) as GameObject;
                alienProjectile = newProjectile.GetComponent<AlienProjectile>();
                alienProjectile.setStart(startPos);
                alienProjectile.setEnd(endPos);
                spawnTime = Random.Range(1, 3);
            }
        }

    }
}
