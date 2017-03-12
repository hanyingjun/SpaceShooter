using UnityEngine;
using System.Collections;

public class BoltMove : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float angularSpeed;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * angularSpeed;
        rb.velocity =transform.TransformDirection(Vector3.forward) * speed;
        //rb.velocity = Vector3.forward * speed;
    }
   
}
