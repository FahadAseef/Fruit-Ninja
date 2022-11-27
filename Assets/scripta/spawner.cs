using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawner : MonoBehaviour
{
    public GameObject fruits;
    public Transform[] spawnpoint;
    public float mindelay=0.1f;
    public float maxdelay=1f;
    GameObject[] fruitinstaarray;
    public Image[] heartimage;
    int life = 3;
    public Sprite heartbroke;
    public GameObject gameoverpopup;
    public static int score;
    public static Text scoretext;
    public Text endscore;
    public int timeremaining = 180;
    public Text timetext;


    private void Start()
    {
        score = 0;
        scoretext=GameObject.Find("score").GetComponent<Text>();
        StartCoroutine(spawnfn());
        InvokeRepeating("timer", 1, 1);
    }



    IEnumerator spawnfn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(mindelay,maxdelay));
            Transform spawnpoints = spawnpoint[Random.Range(0, spawnpoint.Length)];
            GameObject fruitinsta = Instantiate(fruits, spawnpoints.position, transform.rotation);
            StartCoroutine(destroyfn(fruitinsta));
        }
    }

    IEnumerator destroyfn(GameObject currentfruit)
    {
        yield return new WaitForSeconds(5f);
        if(currentfruit != null)
        {
            Debug.Log("missed");
            heartimage[3 - life].sprite = heartbroke;
            life--;
            if(life <= 0)
            {
                gameover();
            }
            Destroy(currentfruit);
        }
    }

    void timer()
    {
        if (timeremaining > 0)
        {
            timeremaining--;
            int minute = timeremaining / 60;
            int second = timeremaining - minute * 60;
            timetext.text = "time : " + minute + "m" + second + "s";
        }
        else
        {
            gameover();
        }
    }

    void gameover()
    {
        Time.timeScale = 0;
        gameoverpopup.SetActive(true);
        endscore.text = "score : " + score;
        life = 3;
    }

}
