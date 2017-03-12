using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public float angularSpeed;
    public string componentName = "EnemyMove";

    void Start()
    {
        //enemyRB = GetComponent<Rigidbody>();
        //rb.angularVelocity = Random.insideUnitSphere * angularSpeed;
        //rb.velocity =transform.TransformDirection(Vector3.forward) * speed;
        //rb.velocity = Vector3.forward * speed;
    }

    void Update()
    {
        transform.position+= -transform.forward * speed * Time.deltaTime;
    }
}
