using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdCheck : MonoBehaviour {

    public InputField _idInputField;
    public Text _errorText;
    public Text allowText;

    public GameObject _loadingPopup;

    public void OnIdCheckButtonClick()
    {
        if (_idInputField.text == "")
        {
            _errorText.text = "아이디를 입력해 주세요.";
            return;
        }

        StartCoroutine("IdCheckCoroutine");
    }

    public void ChangeAllowState(int i)
    {
        allowText.text = i.ToString();
    }

    IEnumerator IdCheckCoroutine()
    {
        string url = "http://tcon.dothome.co.kr/IdCheck.php";

        WWWForm form = new WWWForm();
        form.AddField("user_id", _idInputField.text);

        WWW idCheckClient = new WWW(url, form);

        _loadingPopup.SetActive(true);

        yield return idCheckClient;

        if (idCheckClient.error == null)
        {
            print("응답 성공 : " + idCheckClient.text);
            Dictionary<string, object> responseData = GameData.MiniJSON.jsonDecode(idCheckClient.text) as Dictionary<string, object>;
            string result = responseData["RESULT"].ToString();

            if (result.Trim() == "JOIN_DENY")
            {
                _errorText.text = "아이디가 중복되었습니다.";
                _loadingPopup.SetActive(false);
                yield break;
            }
            else
            {
                _errorText.text = "사용 가능한 아이디 입니다.";
                ChangeAllowState(1);
                _loadingPopup.SetActive(false);
                yield break;
            }
        }
        else
        {
            _errorText.text = "서버 연결 오류";
            _loadingPopup.SetActive(false);
            yield break;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
