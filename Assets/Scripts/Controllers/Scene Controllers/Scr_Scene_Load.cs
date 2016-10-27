using UnityEngine;
using System.Collections;

public class Scr_Scene_Load : MonoBehaviour {

    public string NextScene;

	// Use this for initialization
	void Start ()
    {
        Scr_GameController.instance.sceneController.LoadScene(NextScene);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
