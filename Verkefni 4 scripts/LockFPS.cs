using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LockFPS : MonoBehaviour
{
    public int targetFPS = 60;
    public int vsync = 0;
    public bool _lock_;
    public TextMeshProUGUI text;
    private bool hasTextUI = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool fix = false;
    // Update is called once per frame
    void Update()
    {

        if (text != null)
        {
            if(fix == false)
            {
                StartCoroutine(GetFPS());
                fix = true;
            }
        }
        else
        {
            if(fix == true)
            {
                StopAllCoroutines();
                fix = false;
            }
        }
        if (_lock_ == true)
        {
            QualitySettings.vSyncCount = vsync;
            Application.targetFrameRate = targetFPS;
        }
        else
        {
            QualitySettings.vSyncCount = 1;
            Application.targetFrameRate = -1;
        }
    }
    IEnumerator GetFPS()
    {
        text.text = "FPS: " + FramesPerSecond.DetermineFPS();
        yield return new WaitForSeconds(1);
        StartCoroutine(GetFPS());
    }
}
