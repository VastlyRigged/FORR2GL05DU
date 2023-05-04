using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFunction : MonoBehaviour
{
    public SpawnCan sc;
    public SpawnBomb sb;
    public GameObject goUI; //Stands for game over User Interface
    // Start is called before the first frame update
    void Start()
    {
        goUI = GameObject.Find("GameOverUI");
        sc = gameObject.GetComponent<SpawnCan>();
        sb = gameObject.GetComponent<SpawnBomb>();
        goUI.SetActive(false);
    }
    public void GameOver()
    {
        goUI.SetActive(true);
        sc.enabled = false;
        sb.enabled = false;
        
    }
}
