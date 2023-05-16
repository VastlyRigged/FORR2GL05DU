using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFunction : MonoBehaviour
{
    public GameObject goUI; //Stands for game over User Interface
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        goUI = GameObject.Find("GameOverUI");
        goUI.SetActive(false);
    }
    public void GameOver()
    {
        goUI.SetActive(true);
        gameObject.GetComponent<SpawnZombies>().inAction = false;
        Camera.main.cullingMask = layer;
        StartCoroutine(DisablePlayer());
    }
    private IEnumerator DisablePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject player = GameObject.FindWithTag("Player");
        player.SetActive(false);
    }
}
