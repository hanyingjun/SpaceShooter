using UnityEngine;
using System.Collections;

public class DestroyByExit : MonoBehaviour
{
    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
        if(other.tag=="PlayerBolt")
        {
            playerController.boltCount--;
        }
            
    }
}
