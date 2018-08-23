using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreenDelay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(DelayLoadLevel());
        
    }
	
	// Update is called once per frame
	void Update () {
       

    }

    private IEnumerator DelayLoadLevel()
    {

        
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene("Seed");
    }
}
