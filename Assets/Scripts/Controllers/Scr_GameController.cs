using UnityEngine;
using System.Collections;

public class Scr_GameController : MonoBehaviour {

    public static Scr_GameController instance;
    public Scr_SceneController sceneController;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        gameObject.AddComponent<Scr_SceneController>();
        sceneController = GetComponent<Scr_SceneController>();
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
