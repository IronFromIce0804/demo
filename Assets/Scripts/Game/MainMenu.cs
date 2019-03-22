using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
       // SceneManager.LoadScene(0);

    }
	
	// Update is called once per frame
	void Update () {
        
        //GameObject.FindGameObjectWithTag("die").SetActive(false);

    }

    public void StartGame()
    {
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("MainMenu").SetActive(false);
    }
    public void ExitGame()
    {
        //#if UNITY_EDITOR
        //        UnityEditor.EditorApplication.isPlaying = false;
        //#else
        //Application.Quit();
        //#endif
    }

}
