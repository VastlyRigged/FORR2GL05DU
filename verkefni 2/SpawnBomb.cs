using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnBomb : MonoBehaviour
{
    public Transform map;
    public GameObject bombModel;
    public float spawnCoolDown;
    public int maxinum = 10;
    [ReadOnly] public int contemporaryBombs;
    [Space]
    [SerializeField] [ReadOnly] private Area AreaOfMap;
    public Vector3 show;

    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.FindWithTag("Map").transform;
        if (map != null)
        {
            Transform t = map.FindDeepChild("Ground");
            AreaOfMap.xAxis = (t.localScale.x - 15f) / 2 - 10f;
            AreaOfMap.zAxis = (t.localScale.z - 15f) / 2 - 10f;
            AreaOfMap.height = t.localScale.y + t.localPosition.y + 0.5f;
        }
        else
        {
            Debug.LogError("No map selected");
        }
        StartCoroutine(Spawn());
        
    }
    //Starting Coroutine to spawn can
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnCoolDown);
        if (contemporaryBombs < maxinum) //Making sure the bombs does not overreach the limit.
        {
            //Making sure the can spawns inside of the map.
            float x = UnityEngine.Random.Range(-AreaOfMap.xAxis, AreaOfMap.xAxis);
            float z = UnityEngine.Random.Range(-AreaOfMap.zAxis, AreaOfMap.zAxis);

            Vector3 v = new(x, AreaOfMap.height, z);
            GameObject c = Instantiate(bombModel);
            c.transform.parent = map.transform;
            c.transform.localPosition = v;
            c.transform.parent = null;
            contemporaryBombs += 1;
        }
        StartCoroutine(Spawn());
    }
    [Serializable]
    public struct Area //Content whithin this struct stores the numbers used to calculate the area where can should be able to spawn.
    {
        [ReadOnly] public float xAxis;
        [ReadOnly] public float zAxis;
        [ReadOnly] public float height;
    }
}
