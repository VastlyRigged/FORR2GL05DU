using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeTexture : MonoBehaviour
{
    public Texture[] textures;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        Texture chosenTexture = textures[Random.Range(0, textures.Length)];
        //mr.material = chosenTexture;
    }

}
