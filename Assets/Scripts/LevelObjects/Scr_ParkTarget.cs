using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scr_ParkTarget : MonoBehaviour {

    [SerializeField]
    List<Collider> playerColliders;
    Collider parkTargetCollider;
    public int colliderRequirements;
    public int currentColliders;

    [SerializeField]
    Material activeMaterial;
    [SerializeField]
    Material inactiveMaterial;
    [SerializeField]
    Material completeMaterial;

    // Use this for initialization
    void Start ()
    {
        parkTargetCollider = GetComponent<Collider>();
        colliderRequirements = playerColliders.Count;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Scr_LevelController.instance.playerParked)
        {
            GetComponent<Renderer>().material = completeMaterial;
        }
        else if(currentColliders == colliderRequirements)
        {
            Scr_LevelController.instance.playerInPark = true;
            GetComponent<Renderer>().material = activeMaterial;
        }
        else
        {
            Scr_LevelController.instance.playerInPark = false;
            GetComponent<Renderer>().material = inactiveMaterial;
        }
    }

    void OnTriggerEnter(Collider _other)
    {
        if(playerColliders.Contains(_other))
        {
            currentColliders += 1;
        }
    }

    void OnTriggerExit(Collider _other)
    {
        if (playerColliders.Contains(_other))
        {
            currentColliders -= 1;
        }
    }
}
