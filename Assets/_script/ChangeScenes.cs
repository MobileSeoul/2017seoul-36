using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScenes : MonoBehaviour {

    public GameObject _loadingPopup;
    public Text painterText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeGameScene()
    {
        GameController gc = GameObject.Find("StateController").GetComponent<GameController>();
        if (gc.loginCheck)
        {
            if (gc.markerCheck)
            {
                SceneManager.LoadScene("Painter");
            }
            else
            {
                painterText.text = "마커를 찾아야 열 수 있습니다";
                print("마커를 찾아야 열 수 있습니다.");
                Invoke("TextChange", 2f);
            }
        }
        else
        {
            painterText.text = "로그인 해주세요";
            print("로그인 해주세요");
            Invoke("TextChange", 2f);
        }
    }

    public void TextChange()
    {
        painterText.text = "마커를 찾으세요";
    }

    public void ToLogin()
    {
        GameController gc = GameObject.Find("StateController").GetComponent<GameController>();
        if (gc.loginCheck)
        {
            SceneManager.LoadScene("Info");
        }
        else
        {
            SceneManager.LoadScene("LoginForm");
        }
    }

    public void LoginToJoin()
    {
        SceneManager.LoadScene("JoinForm");
    }

    public void ToMain()
    {
        //_loadingPopup.SetActive(true);
        SceneManager.LoadScene("MainView");
    }

}
