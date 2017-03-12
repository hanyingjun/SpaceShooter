using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    int asteroidCount;
    [SerializeField]
    float spawnWidth;//控制小行星生成的左右幅度宽 
    [SerializeField]
    float spawnGap;
    [SerializeField]
    float startWait;
    [SerializeField]
    float waveWait;
    public GameObject[] asteroids;//当有同一类gameobject需要声明的时候，可以将它们统一声明为gameobject数组。

    public GUIText scoreText;
    private int totalScore;//记录玩家当前总得分,默认初始为0分。
    public GUIText gameOverText;
    public GUIText restartText;

    private bool gameOver;
    private bool restart;


    // Use this for initialization
    void Start()
    {
        gameOver = false;
        restart = false;
        scoreText.text = "Score: " + totalScore;
        gameOverText.text = "";
        restartText.text = "";
        StartCoroutine(SpawnWave());
        UpdateScore();
    }

    void Update()
    {
        if(restart==true&&Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator SpawnWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < asteroidCount; i++)
            {
                GameObject asteroid = asteroids[Random.Range(0, asteroids.Length)];//这里首先声明一个实际生成的asteroid，并表示asteroid是随机从数组中取出的一个成员。

                Vector3 spawnPosition = new Vector3(0,Random.Range(-spawnWidth, spawnWidth),transform.position.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(asteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnGap);
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver)
            {
                restart = true;
                restartText.text = "按下R键以继续游戏...";
                break;
            }
        }
    }
    
    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "Game Over";
        
    }

    void UpdateScore()//用来控制刷新屏幕上的显示玩家分数
    {
        scoreText.text = "Score: " + totalScore;
    }

    public void AddScore(int scoreValue)
    {
        totalScore += scoreValue;
        UpdateScore();
    }
}
