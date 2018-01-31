using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownloadUserMemo : MonoBehaviour
{

    private Text _errorText;  //  에러 표시
    public Texture2D mTex0 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex1 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex2 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex3 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex4 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex5 = new Texture2D(4, 4, TextureFormat.DXT1, false);

    public Sprite sprite;

    //public SpriteRenderer spriteRen0;
    //public SpriteRenderer spriteRen1;
    //public SpriteRenderer spriteRen2;
    //public SpriteRenderer spriteRen3;
    //public SpriteRenderer spriteRen4;
    //public SpriteRenderer spriteRen5;

    public Image img0;
    public Image img1;
    public Image img2;
    public Image img3;
    public Image img4;
    public Image img5;

    IEnumerator Start()
    {


        string[] result = new string[6];
        string url = "http://tcon1.dothome.co.kr/usermemo.php";
        WWW memoClient = new WWW(url);

        yield return memoClient;

        if (memoClient.error == null)
        {
            Dictionary<string, object> responseData = GameData.MiniJSON.jsonDecode(memoClient.text) as Dictionary<string, object>;

            result[0] = responseData["2"].ToString(); // 2부터 시작함 2부터 제일 최근그림링크 스트링으로 있슴 
            result[1] = responseData["3"].ToString();
            result[2] = responseData["4"].ToString();
            result[3] = responseData["5"].ToString();
            result[4] = responseData["6"].ToString();
            result[5] = responseData["7"].ToString();
            print(result);
        }
        else
        {
            print("서버 연결 실패");
        }

        string url0 = result[0];
        WWW www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex0);
        sprite = Sprite.Create(mTex0, new Rect(0, 0, mTex0.width, mTex0.height), new Vector2(0, 0), 100);
        img0.sprite = sprite;
        //spriteRen0.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[1];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex1);
        sprite = Sprite.Create(mTex1, new Rect(0, 0, mTex1.width, mTex1.height), new Vector2(0, 0), 100);
        img1.sprite = sprite;
        //spriteRen1.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[2];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex2);
        sprite = Sprite.Create(mTex2, new Rect(0, 0, mTex2.width, mTex2.height), new Vector2(0, 0), 100);
        img2.sprite = sprite;
        // spriteRen2.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[3];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex3);
        sprite = Sprite.Create(mTex3, new Rect(0, 0, mTex3.width, mTex3.height), new Vector2(0, 0), 100);
        img3.sprite = sprite;
        // spriteRen3.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[4];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex4);
        sprite = Sprite.Create(mTex4, new Rect(0, 0, mTex4.width, mTex4.height), new Vector2(0, 0), 100);
        img4.sprite = sprite;
        //  spriteRen4.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[5];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex5);
        sprite = Sprite.Create(mTex5, new Rect(0, 0, mTex5.width, mTex5.height), new Vector2(0, 0), 100);
        img5.sprite = sprite;
        //  spriteRen5.GetComponent<SpriteRenderer>().sprite = sprite;

    }
}

