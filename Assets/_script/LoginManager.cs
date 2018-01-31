using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour {
    public Text _errorText;  // 로그인 에러 표시
    public InputField _idInputField;  // 아이디 입력 필드
    public InputField _pwInputField;  // 비밀번호 입력 필드

    public GameObject _loadingPopup;

    void Start()
    {

    }

    // 로그인 버튼 클릭
    public void OnLoginButtonClick()
    {
        _errorText.text = "";

        if (_idInputField.text.Trim().Length <= 0 || _pwInputField.text.Trim().Length <= 0)
        {
            _errorText.text = "아이디 또는 비밀번호를 입력하세요.";
            return;
        }

        StartCoroutine("LoginNetCoroutine");
    }

    IEnumerator LoginNetCoroutine()
    {
        string url = "http://tcon.dothome.co.kr/login.php";
        WWWForm form = new WWWForm();
        form.AddField("user_id", _idInputField.text);
        form.AddField("user_pw", _pwInputField.text);

        WWW loginClient = new WWW(url, form);

        _loadingPopup.SetActive(true);

        yield return loginClient;

        if (loginClient.error == null)
        {
            Dictionary<string, object> responseData = GameData.MiniJSON.jsonDecode(loginClient.text) as Dictionary<string, object>;
            string result = responseData["RESULT"].ToString();

            if (result.Trim() == "LOGIN_SUCCESS")
            {
                GameController gc  = GameObject.Find("StateController").GetComponent<GameController>();
                gc.loginCheck = true;
                gc.userid = _idInputField.text;
                SceneManager.LoadScene("MainView");
                print("로그인 성공");
            }
            else
            {
                _loadingPopup.SetActive(false);
                print("로그인 실패");
                _errorText.text = "아이디나 비밀번호가 틀렸습니다.";
            }
        }
        else
        {
            _loadingPopup.SetActive(false);
            print("서버 연결 실패");
            _errorText.text = "서버에 연결할 수 없습니다.";
        }
    }
}
