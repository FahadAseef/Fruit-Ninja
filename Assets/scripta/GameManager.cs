using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject livespan;
    public GameObject playapnel;
    public GameObject overgame;
    //public GameObject scoretext;

    private void Start()
    {
        Time.timeScale = 0;
    }
    public void playbuttonpressed()
    {
        Time.timeScale = 1;
        livespan.SetActive(true);
        playapnel.SetActive(false);
        overgame.SetActive(false);       
        //scoretext.SetActive(true);
    }


}
