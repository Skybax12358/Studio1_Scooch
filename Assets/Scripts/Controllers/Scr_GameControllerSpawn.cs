using UnityEngine;
using System.Collections;

public class Scr_GameControllerSpawn : MonoBehaviour {

    [SerializeField]
    GameObject gameController;

    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("GameController") == false)
        {
            Debug.Log("Spawn character controller");
            GameObject GameController = Instantiate<GameObject>(gameController);
        }
        Destroy(this.gameObject);
    }
}
