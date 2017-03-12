using UnityEngine;
using System.Collections;

public class DestroyByHit : MonoBehaviour
{
    public GameObject playerExplosion;
    public GameObject explosion;
    public GameObject powItem;

    //private GameController gameController;
    private PlayerController playerController;
    private SpawnEnemy spawnEnemy;
    private int waveEnemyLeft;      //记录SpawnEnemy脚本中单波敌人的数量

    //public int asteroidPoint=10;

    void Start()
    {
        #region
        //if(gameControllerObject.tag=="GameController")                      //这种写法unity不知道gameController的tag是啥，必须要我们主动为其搭建关系，用他去寻找
        //{
        //    gameController=gameControllerObject.GetComponent<GameController>();
        //}
        //if (gameController == null)
        //{
        //    Debug.Log("Can't find 'GameController' component");
        //}

        //GameObject gameControllerObject = GameObject.FindWithTag("GameController");//这里使用的寻找tag方法是FindWithTag   

        //if(gameControllerObject)
        //{
        //    gameController = gameControllerObject.GetComponent<GameController>();
        //}
        //if(gameController==null)
        //{
        //    Debug.Log("Can't find 'GameController' component");
        //}
        #endregion                        
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        //waveEnemyLeft = spawnEnemy.waveEnemyCount[spawnEnemy.waveCount];
    }


    void OnTriggerEnter(Collider other)
    {
        //CompareTag判断该gameObject的tag是否和括号里写的一致，返回布尔值
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))          //如果敌人collider进入Boundary或其他敌人的collider，那么不发生任何情况
        {
            return;
        }

        if (other.gameObject.tag == "Player")                                   //如果撞击的是玩家，那么播放主角爆炸画面
        {
            Instantiate(playerExplosion, other.gameObject.transform.position, Quaternion.identity);
            //gameController.GameOver();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        if (explosion != null)                                                  //如果敌人的爆炸特效发生，播放爆炸(因为外面留空了，这里一般来说不会读到)
        {
            Instantiate(explosion, transform.position, transform.rotation);     
            Destroy(gameObject);                                                //消除敌人物体
            Destroy(other.gameObject);                                          //消除撞击到敌人的物体（玩家子弹or玩家本身）
            playerController.boltCount--;                                       //玩家子弹计数器-1  

            //waveEnemyLeft--;                                                    //敌人死亡，那么从这一波的敌人残存数量-1

            //if (waveEnemyLeft == 0  /*&& spawnEnemy.DropPowUpItem()*/)
            //{
            //    Instantiate(powItem, transform.position, transform.rotation);   //
            //}
        }
    }
}
