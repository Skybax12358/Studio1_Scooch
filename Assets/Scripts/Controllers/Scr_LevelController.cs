using UnityEngine;
using System.Collections;

public class Scr_LevelController : MonoBehaviour {

    public GameObject playerCar;
    CarControl scr_CarControl;

    public static Scr_LevelController instance;

    public bool playerInPark;
    public bool playerParked;

    Scr_SceneController sceneController = new Scr_SceneController();

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start ()
    {
        scr_CarControl = playerCar.GetComponent<CarControl>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if((playerInPark) && (scr_CarControl.statuse == CarStause.Stopped))
        {
            playerParked = true;
        }
        else
        {
            playerParked = false;
        }

        if(Input.GetAxis("Reset") > 0)
        {
            sceneController.ResetScene();
        }
	}
    


    void ResetCar()
    {
        //playerCar.
    }
}
