﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] spawnPositions;  //每一波敌人的生成位置
    public GameObject[] enemies;        //所有敌人的种类
    public float[] enemyGap;            //单波敌人出现时每个敌人之间的生成时间差
    public float[] timeBetweenEnemies;  //每一波敌人之间出现的时间间隔
    public int[] waveEnemyCount;        //每一波的敌人数量写在这

    public string[] enemyMove;          //控制敌人的移动脚本名称
    //public Component[] enemyShoot;    //控制敌人的攻击脚本

    public float startWait = 2;         //开场等待时间

    [HideInInspector]
    public int waveCount;               //记录当前波数

    public bool[] dropPowUp;            //该波敌人是否掉落升级道具
    public bool[] dropBomb;             //该波敌人是否掉落全屏雷

    //private GameObject bossDetector;  //检测boss是否存在的探测器

    void Start()
    {
        StartCoroutine(SpawnEnemyWave());
    }

    IEnumerator SpawnEnemyWave()
    {
        yield return new WaitForSeconds(startWait);                                 //等待开场时间
        while (true)
        {
            for (int j = 0; j < waveEnemyCount[waveCount]; j++)                     //当前这一波敌人数量有多少个，就循环多少次
            {
                Spawn(waveCount);                                                   //生成单个敌人
                yield return new WaitForSeconds(enemyGap[waveCount]);               //生成之后停顿gap时间
            }
            waveCount++;                                                            //上一波敌人全部生成，波数计算器+1
            yield return new WaitForSeconds(timeBetweenEnemies[waveCount]);         //等待波之间的时间间隔
        }
    }

    void Update()
    {
        
    }

    void Spawn(int waveCount)
    {
		//具体克隆的实体对象
        GameObject go = Instantiate(enemies[waveCount],
			spawnPositions[waveCount].position, spawnPositions[waveCount].rotation);
		//对于引用对象先判断是否为空，
// 		if (go != null)
// 		{
// 			//先get组件对象，如果没有再在下面add,防止一个脚本对象上多个同样的脚本，引起不必要的bug
// 			EnemyMove em = go.GetComponent<EnemyMove>();
// 			//同样空判断处理
// 			if (em == null)
// 			{
// 				em = go.AddComponent<EnemyMove>();
// 			}
// 		}
    }

    //public bool DropPowUpItem()
    //{
    //    return dropPowUp[waveCount];
    //}

    //public bool DropBombUpItem()
    //{
    //    return dropBomb[waveCount];
    //}
}
