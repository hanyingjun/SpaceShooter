using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{
    [SerializeField]
    float scrollSpeed;//背景卷轴上下位移速度
    [SerializeField]
    float tileSize;

    private Vector3 startPosition;

    //一套很标准的卷轴重复公式
    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        float newPosition= Mathf.Repeat(Time.time*scrollSpeed,tileSize);
        transform.position = startPosition + Vector3.forward * newPosition; 
    }
}
