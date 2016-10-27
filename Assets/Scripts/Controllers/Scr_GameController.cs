using UnityEngine;
using System.Collections;

public class Scr_GameController : MonoBehaviour {

    public static Scr_GameController instance;

    public Scr_SceneController sceneController;

    public Scr_LevelController levelController;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        gameObject.AddComponent<Scr_SceneController>();
        sceneController = GetComponent<Scr_SceneController>();

        gameObject.AddComponent<Scr_LevelController>();
        levelController = GetComponent<Scr_LevelController>();
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
