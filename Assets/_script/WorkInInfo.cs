using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorkInInfo : MonoBehaviour {

    public Text userid;
    public GameObject _loadingPopup;

    void Start () {
        GameController gc = GameObject.Find("StateController").GetComponent<GameController>();
        userid.text = gc.userid;
    }
	
	void Update () {
		
	}

    public void LogoutClick()
    {
        GameController gc = GameObject.Find("StateController").GetComponent<GameController>();
        if (gc.loginCheck)
        {
            _loadingPopup.SetActive(true);
            gc.loginCheck = false;
            gc.userid = "";
            SceneManager.LoadScene("MainView");
        }
    }
}
