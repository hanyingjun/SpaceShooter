using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float zMin, zMax, yMin, yMax;
}
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;
    Rigidbody rb;
    [SerializeField]
    float tilt;
    public GameObject bolt;
    public Transform[] shotSpawns;//如果想要发射多枚子弹，可以将发射位置声明为数组
    public Transform shotSpawn;

    [SerializeField]
    float fireGap;
    private float nextFireTime;

    public Boundary boundary;
    public int boltCount;

    void FixedUpdate()
    {   
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(0.0f, moveVertical,moveHorizontal);
        rb = GetComponent<Rigidbody>();
        rb.velocity = movement * speed;//主角位移
        rb.rotation = Quaternion.Euler(0, 0,moveVertical * tilt);//这里旋转是以z轴为轴线旋转
        rb.position = new Vector3(0,Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax), Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));//限制飞机在屏幕范围内活动
    }

    void Update()
    {
        if (Input.GetButton("Fire2") && Time.time >= nextFireTime && boltCount<=3)
        {
            nextFireTime = Time.time + fireGap;
                Instantiate(bolt, shotSpawn.position, shotSpawn.rotation);
            boltCount++;
        }
        


        //if (Input.GetButton("Fire2") && Time.time >= nextFireTime)
        //{
        //    nextFireTime = Time.time + fireGap;
        //    foreach (var shotSpawn in shotSpawns)
        //    {
        //        Instantiate(bolt, shotSpawn.position, shotSpawn.rotation);
        //    }
        //}
    }
}
