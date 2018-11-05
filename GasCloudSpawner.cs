using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCloudSpawner : MonoBehaviour
{

    public GameObject gasProjectilePrefab;
    GameObject rocket;
    Transform startPos;
    Transform endPos;
    [SerializeField]
    float spawnTime;


    // Use this for initialization
    void Start()
    {
        startPos = this.transform.GetChild(0);
        endPos = this.transform.GetChild(1);
        spawnTime = 30;
        rocket = GameObject.Find("Rocket");
    }

    // Update is called once per frame
    void Update()
    {

        if (rocket.activeSelf == true)
        {
            spawnTime -= Time.deltaTime;

            if (spawnTime < 0)
            {
                GameObject newProjectile;
                GasCloud gasProjectile;
                newProjectile = Instantiate(gasProjectilePrefab, startPos.position, transform.rotation) as GameObject;
                gasProjectile = newProjectile.GetComponent<GasCloud>();
                gasProjectile.setStart(startPos);
                gasProjectile.setEnd(endPos);
                spawnTime = Random.Range(30, 40);
            }
        }

    }

}