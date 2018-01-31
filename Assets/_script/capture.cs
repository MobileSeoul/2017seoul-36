using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class capture : MonoBehaviour {

    int i_height = Screen.height;   // 스크린 세로길이
    int i_width = Screen.width;     // 스크린 가로길이
    public Text screenshotText;
    public Text memoSaveText;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PainterCapture()
    {
        StartCoroutine(ScreenShot());
        memoSaveText.text = "메모가 저장되었습니다";
        Invoke("TextChange2", 2f);
    }
    public void MainCameraCapture()
    {
        StartCoroutine(ScreenShot2());
        screenshotText.text = "캡쳐되었습니다";
        Invoke("TextChange", 2f);
    }

    public void TextChange()
    {
        screenshotText.text = "마커를 찾으세요";
    }

    public void TextChange2()
    {
        memoSaveText.text = "메모를 남겨주세요";
    }

    IEnumerator ScreenShot()    //페인터 스크린샷 - 엑스부분,메뉴부분 제외하고 캡쳐
    {
        //double h = i_height * 0.821; //탑바,언더바 제외한 길이
        //double hTop = i_height * 0.075; //탑바 길이
        //double hUnder = i_height * 0.103; //언더바 길이
        string filepath = "number_" + Time.time.ToString() + ".png";
       
        string targetFileURI = "ftp://tcon1.dothome.co.kr/html/image/" + filepath;
        string userID = "tcon1";
        string password = "tcon2017";

        double h = i_height - i_width * 2 * 0.17;//탑바,언더바 제외한 길이
        double hUnder = i_width * 0.17; //언더바 길이

        yield return new WaitForEndOfFrame();
        byte[] imageByte;  //스크린샷을 Byte로 저장.Texture2D use 
        Texture2D tex = new Texture2D(Screen.width, (int)h, TextureFormat.RGB24, true);
        //2d texture객체 생성. 생성할 화면의 너비 높이
        tex.ReadPixels(new Rect(0, (float)hUnder, Screen.width,(float)h), 0, 0, true);
        //현재 화면을 픽셀 단위로 읽음. 왼쪽 아래 너비 높이
        tex.Apply();
        //읽어 들인것을 적용. 
        imageByte = tex.EncodeToPNG();
        //읽어 드린 픽셀을 Byte[]에 PNG 형식으로 인코딩
        DestroyImmediate(tex);
        //Byte[]에 넣었으니 Texture 2D 객체는 바로 파괴(메모리관리) 
        File.WriteAllBytes("mnt/sdcard/DCIM/Camera/"+filepath, imageByte);
        UploadFTPFile("mnt/sdcard/DCIM/Camera/" + filepath, targetFileURI, userID, password);

        GameController gc = GameObject.Find("StateController").GetComponent<GameController>();

        string url = "http://tcon1.dothome.co.kr/memosave.php";
        WWWForm form = new WWWForm();
        form.AddField("user_id", gc.userid);
        form.AddField("image_link", "http://tcon1.dothome.co.kr/image/" + filepath);
        form.AddField("cur_loca", gc.position);

        WWW MemoSaveClient = new WWW(url, form);

        yield return MemoSaveClient;

        if (MemoSaveClient.error == null)
        {
            Dictionary<string, object> responseData = GameData.MiniJSON.jsonDecode(MemoSaveClient.text) as Dictionary<string, object>;
            string result = responseData["RESULT"].ToString();

            if (result.Trim() == "SAVE_SUCCESS")
            {
                print("저장 성공");
            }
            else
            {
                print("저장 실패");
            }
        }
        else
        {
            print("서버 연결 실패");
        }
    }

    public bool UploadFTPFile(string sourceFilePath, string targetFileURI, string userID, string password)
    {
        try
        {
            Uri targetFileUri = new Uri(targetFileURI);

            FtpWebRequest ftpWebRequest = WebRequest.Create(targetFileUri) as FtpWebRequest;

            ftpWebRequest.Credentials = new NetworkCredential(userID, password);
            ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;

            FileStream sourceFileStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read);
            Stream targetStream = ftpWebRequest.GetRequestStream();

            byte[] bufferByteArray = new byte[1024];

            while (true)
            {
                int byteCount = sourceFileStream.Read(bufferByteArray, 0, bufferByteArray.Length);

                if (byteCount == 0)
                {
                    break;
                }
                targetStream.Write(bufferByteArray, 0, byteCount);
            }
            targetStream.Close();
            sourceFileStream.Close();
        }
        catch
        {
            return false;
        }
        return true;
    }

    IEnumerator ScreenShot2()   //메인카메라 스크린샷 - 화면 전체 캡쳐
    {
        yield return new WaitForEndOfFrame();
        byte[] imageByte; 
        Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
        tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, true);
        tex.Apply();
        imageByte = tex.EncodeToPNG();
        DestroyImmediate(tex);
        File.WriteAllBytes("mnt/sdcard/DCIM/Camera/number_" + Time.time.ToString() + ".png", imageByte);
    }
}
