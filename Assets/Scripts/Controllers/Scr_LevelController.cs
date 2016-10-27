using UnityEngine;
using System.Collections;

public class Scr_LevelController : MonoBehaviour {

    GameObject playerCar;
    CarControl scr_CarControl;

    public bool playerInPark;
    public bool playerParked;

	// Use this for initialization
	void Start ()
    {
        playerCar = GameObject.FindGameObjectWithTag("Player");
        scr_CarControl = playerCar.GetComponent<CarControl>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetAxis("Reset") > 0)
        {
            Scr_GameController.instance.sceneController.ResetScene();
        }
	}
}
