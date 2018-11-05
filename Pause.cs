using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    bool paused;
    GameObject pasuedMenu;
	GameObject uiMenu;

	void Start () {
        paused = false;
        pasuedMenu = GameObject.Find("PauseMenu");
		uiMenu = GameObject.Find ("Canvas");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
        }
        pasuedGame();

    }

    void pasuedGame()
    {
        if(paused == true)
        {
            Time.timeScale = 0;
            pasuedMenu.SetActive(true);
			uiMenu.SetActive (false);
        }
        else if(paused == false)
        {
            Time.timeScale = 1;
            pasuedMenu.SetActive(false);
			uiMenu.SetActive (true);
        }
    }

    public void Unpause()
    {
        paused = false;
    }


}
