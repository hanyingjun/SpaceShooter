using UnityEngine;
using System.Collections;

public class EvasiveManager : MonoBehaviour
{
    public float dodge;
    public Vector2 startWait;
    public Vector2 manueverTime;
    public Vector2 manuverWait;
    public float smoothing;
    private float currentSpeed;
    private float targetManeuver;
    public float tilt;
    private Rigidbody rb;
    public Boundary boundary;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = rb.velocity.z;
        StartCoroutine(Evade());
    }

    IEnumerator Evade()
    {
        //这里的startWait.x和startWait.y就是方便random的最大值和最小值，作者为了少声明一个变量用了vector2来替代
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y)); //随机出一个时间，敌人在该随机时间之后进行回避
        
        //WaitForSeconds协程是等待该时间过去之后然后执行下面代码
        while(true)
        {
            //Mathf.sign用来判断括号里的参数正负，返回一个-1or1的值。
            targetManeuver = Random.Range(1,dodge)*-Mathf.Sign(transform.position.y); //这里保证targetManeuver的值（接下来的物体y方向）始终朝向画面中心
            yield return new WaitForSeconds(Random.Range(manueverTime.x,manueverTime.y)); //再次等待一段随机时间后执行下列代码——移动时间
            targetManeuver = 0; //复位移动系数数值
            yield return new WaitForSeconds(Random.Range(manuverWait.x,manuverWait.y)); //再次等待一段随机时间——移动之间的等待时间
        }
    }

    // Update is called once per frame
    void FixedUpdate()//因为飞船刚体移动，所以用FixedUpdate
    {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing); //水平方向上，以每秒smoothing的速度移动飞机，直至targetManeuver
        rb.velocity = new Vector3(newManeuver,0.0f,currentSpeed); //得到此时飞机的速度Vector3
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.zMin, boundary.zMax), 0.0f, Mathf.Clamp(rb.position.z, boundary.yMin, boundary.yMax));//限制敌人移动范围
        rb.rotation = Quaternion.Euler(0, 0, rb.velocity.x * -tilt);//
    }
}
