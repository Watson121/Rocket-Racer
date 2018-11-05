using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHealth : MonoBehaviour {

    int health;

    // Use this for initialization
    void Awake() {
        health = 3;
    }

    
    public int getShieldHealth ()
    {
        return health;
    }

    public void decreaseHealth()
    {
        health--;
    }


}
