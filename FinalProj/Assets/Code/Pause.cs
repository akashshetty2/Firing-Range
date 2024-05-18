using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject menu;
    private bool menuOn;

    /* Doesn't actually pause the game, but brings up the menu for the user to change settings. */

    // Start is called before the first frame update
    void Start()
    {
	menuOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            menu.SetActive(true);
	    menuOn = true;
            Time.timeScale = 0;
        } 
	else if (menu.activeInHierarchy == false) 
	{
	   menuOn = false;
	   Time.timeScale = 1;  
	}

    }

    public bool getMenuStatus()
    {
	return menuOn;
    }
}
