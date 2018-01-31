using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JoinManager : MonoBehaviour {

    // 로딩중 팝업
    public GameObject _loadingPopup;

    public InputField _idInputField;
    public InputField _pwInputField;
    public InputField _rePwInputField;
    public InputField _emInputField;

    public Text _errorText;
    public Text allowText;

    // 회원 가입
    public void OnJoinOkButtonClick()
    {
        // 비번과 확인 비번 비교
        if (_pwInputField.text.Trim() != _rePwInputField.text.Trim())
        {
            _pwInputField.text = _rePwInputField.text = "";
            _errorText.text = "확인 비밀번호가 틀립니다.";
            return;
        }

        if (_idInputField.text == "" || _pwInputField.text == "" || _emInputField.text == "")
        {
            _errorText.text = "항목을 모두 작성해 주세요.";
            return;
        }

        else if (allowText.text == "0")
        {
            _errorText.text = "아이디 중복확인을 해 주세요.";
            return;
        }

        StartCoroutine("JoinNetCoroutine");
    }

    IEnumerator JoinNetCoroutine()
    {

        string url = "http://tcon.dothome.co.kr/join.php";

        // 입력 폼 객체 생성
        WWWForm form = new WWWForm();
        form.AddField("user_id", _idInputField.text);
        form.AddField("user_pw", _pwInputField.text);
        form.AddField("user_em", _emInputField.text);

        WWW joinClient = new WWW(url, form);

        _loadingPopup.SetActive(true);

        yield return joinClient;
        // 테스트용 지연

        if (joinClient.error == null)
        {
            print("응답 성공 : " + joinClient.text);
            // 가입 성공과 실패를 판단하여 가입창을 다시 띄움
            // Dictionary<string, object> resultMessage = GameData.MiniJSON.jsonDecode(client.text) as Dictionary<string, object>;
            Dictionary<string, object> responseData = GameData.MiniJSON.jsonDecode(joinClient.text) as Dictionary<string, object>;
            string result = responseData["RESULT"].ToString();

            if (result.Trim() == "JOIN_SUCCESS")
            {
                _loadingPopup.SetActive(false);
                SceneManager.LoadScene("LoginForm");
            }
            else
            {
                _errorText.text = "회원 가입 실패";
                _loadingPopup.SetActive(false);
            }
        }
        else
        {
            print("응답 실패 : " + joinClient.error);
            _loadingPopup.SetActive(false);
        }
    }
}
