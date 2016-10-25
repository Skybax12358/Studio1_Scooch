using UnityEngine;
using System.Collections;

public class Scr_Level : MonoBehaviour {

    public GameObject ParkTarget;
    public GameObject PlayerSpawn;

    void Awake()
    {
        FindLevelObjects();
    }

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void FindLevelObjects()
    {
        for (int index = 0; index < transform.childCount; index++)
        {
            if (transform.GetChild(index).tag == "ParkTarget")
            {
                ParkTarget = transform.GetChild(index).gameObject;
            }
            else if(transform.GetChild(index).tag == "PlayerSpawn")
            {
                PlayerSpawn = transform.GetChild(index).gameObject;
            }
        }
    }
}
