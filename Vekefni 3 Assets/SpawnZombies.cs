using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SpawnZombies : MonoBehaviour
{
    public bool inAction = true;
    public int maxinum;
    public float cooldown = 2;
    [ReadOnly] public int current;
    [SerializeField] [ReadOnly] private List<Transform> SpawnPoints;
    public GameObject zombieModel;
    // Start is called before the first frame update
    void Start()
    {
        Transform spt = GameObject.FindWithTag("Points").transform;
        SpawnPoints = spt.GetAllDeepChildren();
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(cooldown);
        if(inAction == true && current <= maxinum)
        {
            int picked = UnityEngine.Random.Range(1, SpawnPoints.Count - 1);
            Vector3 spawnLocation = SpawnPoints[picked].position;
            GameObject zombie = Instantiate(zombieModel);
            zombie.transform.position = spawnLocation;
            current += 1;
        }
    }
}
