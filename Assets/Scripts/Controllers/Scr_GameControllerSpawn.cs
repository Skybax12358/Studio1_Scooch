using UnityEngine;
using System.Collections;

public class Scr_GameControllerSpawn : MonoBehaviour {

    [SerializeField]
    GameObject gameController;

    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("GameController") == false)
        {
            GameObject GameController = Instantiate<GameObject>(gameController);
        }
        Destroy(this.gameObject);
    }
}
