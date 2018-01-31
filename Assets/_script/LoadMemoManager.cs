using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadMemoManager : MonoBehaviour
{
    private Text _errorText;  //  에러 표시


    void Start()
    {
        StartCoroutine("LoadMemoNetCoroutine");
    }

    
    IEnumerator LoadMemoNetCoroutine()
    {
        string url = "http://tcon1.dothome.co.kr/memo_1.php";
        WWW memoClient = new WWW(url);

        yield return memoClient;

        if (memoClient.error == null)
        {
            Dictionary<string, object> responseData = GameData.MiniJSON.jsonDecode(memoClient.text) as Dictionary<string, object>;
            string result = responseData["2"].ToString(); // 2부터 시작함 2부터 제일 최근그림링크 스트링으로 있슴 

            print(result);
        }
        else
        {
            print("서버 연결 실패");
        }
    }
}
