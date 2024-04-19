using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroWait : MonoBehaviour
{
    public int waitTime;
    void Start()
    {
        StartCoroutine(waitForLevel());
        
    }

    IEnumerator waitForLevel()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(1);
    }

}
