using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove_S : MonoBehaviour
{
    public float sinFrequency = 1;  //修正sin函数在单位时间（s）内的周期次数 的系数
    public float sinAmplitude = 1;
    public float speed = 1;
    public float enemyRotation=10;

    private float verticalOffset=0;
    private float time;

    
    // Use this for initialization
    void Start()
    {
       
    }

    void Update()
    {
        Move_SCurve();
    }

    void Move_SCurve()
    {
        time += Time.deltaTime;                                             //增量时间，游戏开始开始增长

        transform.position -= verticalOffset * transform.right;             //消除上一个update的y方向修正值

        transform.position += -transform.forward * speed * Time.deltaTime;  //追加横向位移增量_注意这里不使用增量时间

        verticalOffset = Mathf.Sin(time * sinFrequency) * sinAmplitude;     //verticalOffset在这里是sin函数的y值，随着时间在-1到1之间变动，这里算出一个新的y方向修正值

        transform.position += verticalOffset * -transform.right;
    }
}
