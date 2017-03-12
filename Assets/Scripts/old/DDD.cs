using UnityEngine;
using System.Collections;

public class DDD : MonoBehaviour
{

	// Use this for initialization
	void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
	

	
}
