using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EGConfig
{
    public float whenTheySpawn;

    public int count;
    public GameObject prefab;
    
}

public class EnemyGenerator : MonoBehaviour {


    private GameObject timeText;

    public List<EGConfig> configList;

    public float timeRemaining = 60f;




    // Use this for initialization
    void Start () {

        timeText = GameObject.Find("TimeText");

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
                            Instantiate(config.prefab, new Vector3(Random.Range(-30,30), config.prefab.transform.position.y, Random.Range(-30,30)), config.prefab.transform.rotation);
                        configList.Remove(config);
                        break;
                    }
             }

        }

        timeRemaining -= Time.deltaTime;

        if (timeRemaining < 0) return;
        timeText.GetComponent<Text>().text = timeRemaining.ToString("F2"); //小数2桁にして表示



        
        
        
        
        
        
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
