using UnityEngine;
using System.Collections;


public class EnemyMove_L : MonoBehaviour
{
    public float horizontalSpeed;
    public float horizontalMoveTime;

    public float turnSpeed=Mathf.Infinity;             // 敌人进入折返抛物线的速度
    public float p;                                    // y²= -2px 抛物线的修正系数p,修正抛物线弧度开口
    public float VerticalGrowSpeed;                    // 
    public float backValue;                            //折返抛物线往回拉的幅度


    private float time;
    private float gameObjectHeight;

    void Start()
    {
        gameObjectHeight = transform.position.y;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time <= horizontalMoveTime)
        {
            MoveHorizontal();
        }
        else if (transform.position == new Vector3(0, 0, 0))
        {
            Debug.Log("already reached the origin point ");
        }
        else
        {
            gameObjectHeight += Time.deltaTime * VerticalGrowSpeed;
            Vector3 newPostion = new Vector3(0.0f, gameObjectHeight, backValue-(gameObjectHeight * gameObjectHeight) / 2 * p);
            transform.position = Move_LCurve(newPostion);
        }


    }

    void MoveHorizontal()
    {
        transform.position += -transform.forward * horizontalSpeed * Time.deltaTime;
    }

    //void Move_LCurve()
    //{
    //    transform.position -= verticalOffset * transform.right;             //消除上一个update的y方向修正值

    //    transform.position += -transform.forward * turnspeed * Time.deltaTime;  //追加横向位移增量_注意这里不使用增量时间

    //    verticalOffset = Mathf.Sin(time * sinFrequency) * sinAmplitude;     //verticalOffset在这里是sin函数的y值，随着时间在-1到1之间变动，这里算出一个新的y方向修正值

    //    transform.position += verticalOffset * -transform.right;
    //}

    Vector3 Move_LCurve(Vector3 targetPosition)
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, turnSpeed);
        return  newPosition;
    }
}
