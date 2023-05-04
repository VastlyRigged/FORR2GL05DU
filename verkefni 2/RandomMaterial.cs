using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour
{
    public Material[] materials;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        Material cm = materials[Random.Range(0, materials.Length)];
        mr.material = cm;
    }

}
