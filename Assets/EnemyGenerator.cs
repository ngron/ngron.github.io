using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[System.Serializable]
public class EGConfig
{
    public float whenTheySpawn;

    public int count;
    public GameObject prefab;
    
}

public class EnemyGenerator : MonoBehaviour {


    //public GameObject Player;

    private GameObject timeText;

    public List<EGConfig> configList;

    public float timeRemaining = 60f;


    //TIME UPのテキスト
    private GameObject timeUpText;
    //GameOverのテキスト
    private GameObject gameOverText;
    //プレイヤを取得
    GameObject player;
    //タップしてゲーム再開
    bool tap = false;

    // Use this for initialization
    void Start () {

        //GameObject player = Instantiate(Player) as GameObject;
        //player.transform.position = new Vector3(0, 3, 0);

        timeText = GameObject.Find("TimeText");

        timeUpText = GameObject.Find("TimeUpText");

        gameOverText = GameObject.Find("GameOverText");

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update () {


        if (timeRemaining < 0 && timeRemaining > -1)
        {
      
              //Debug.Log("Time over.");
              timeRemaining = -1f;
        }
        else if (configList.Count > 0)
        {
            foreach (var config in configList)
            { 
                    if (config.whenTheySpawn > this.timeRemaining)
                    {
                        System.Text.StringBuilder builder = new System.Text.StringBuilder();
                        builder.AppendLine("[Spawn]");
                        builder.AppendLine("Time remaining: " + timeRemaining);
                        builder.AppendLine("m_whenTheySpawn: " + config.whenTheySpawn);
                        builder.AppendLine("m_count: " + config.count);
                        builder.AppendLine("m_prefab: " + config.prefab.name);
                        //Debug.Log(builder.ToString());
                        
                        for (int i = 0; i < config.count; i++)
                            Instantiate(config.prefab, new Vector3(Random.Range(-40,40), config.prefab.transform.position.y, Random.Range(-40,40)), config.prefab.transform.rotation);
                        configList.Remove(config);
                        break;
                    }
             }

        }
        if(Input.GetMouseButtonDown(0) && tap)
        {
            //GameSceneを読み込む
            SceneManager.LoadScene("GameScene");
        }

        //時間を引いていく
        timeRemaining -= Time.deltaTime;

        //時間を表示
        timeText.GetComponent<Text>().text = timeRemaining.ToString("F2"); //小数2桁にして表示

        //0秒以下になった時
        if (timeRemaining <= 0)
        {
        //TIME UPを表示
            timeUpText.GetComponent<Text>().text = "TIME UP";
           //時間を消す
            Destroy(timeText);
            //プレイヤを消す
            Destroy(player);
            //タップできるようになる
            tap = true;
        }









        //if (time <= 50)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        GameObject skeleton = Instantiate(Skeleton) as GameObject;
        //        skeleton.transform.position = new Vector3(Random.Range(-30,30), skeleton.transform.position.y, Random.Range(-30,30));

        //    }
        //}
        //}
        //if (time <= 40)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        GameObject skeleton = Instantiate(Skeleton) as GameObject;
        //        skeleton.transform.position = new Vector3(random, skeleton.transform.position.y, random);
        //    }
        //    time = 60;
        //}
        //if (time <= 30)
        //{
        //    GameObject boss = Instantiate(Boss) as GameObject;
        //    boss.transform.position = new Vector3(random, boss.transform.position.y, random);
        //}
        //time = 60;

        //if (time <= 20)
        //{
        //    GameObject skeleton = Instantiate(Skeleton) as GameObject;
        //    skeleton.transform.position = new Vector3(random, skeleton.transform.position.y, random);
        //}

    }
}
