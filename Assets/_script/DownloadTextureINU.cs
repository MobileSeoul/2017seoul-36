using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownloadTextureINU : MonoBehaviour
{

    private Text _errorText;  //  에러 표시
    public Texture2D mTex0 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex1 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex2 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex3 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex4 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex5 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex6 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex7 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex8 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex9 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex10 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex11 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex12 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex13 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex14 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex15 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex16 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex17 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex18 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex19 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex20 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex21 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex22 = new Texture2D(4, 4, TextureFormat.DXT1, false);
    public Texture2D mTex23 = new Texture2D(4, 4, TextureFormat.DXT1, false);

    public Sprite sprite;

    public SpriteRenderer spriteRen0;
    public SpriteRenderer spriteRen1;
    public SpriteRenderer spriteRen2;
    public SpriteRenderer spriteRen3;
    public SpriteRenderer spriteRen4;
    public SpriteRenderer spriteRen5;
    public SpriteRenderer spriteRen6;
    public SpriteRenderer spriteRen7;
    public SpriteRenderer spriteRen8;
    public SpriteRenderer spriteRen9;
    public SpriteRenderer spriteRen10;
    public SpriteRenderer spriteRen11;
    public SpriteRenderer spriteRen12;
    public SpriteRenderer spriteRen13;
    public SpriteRenderer spriteRen14;
    public SpriteRenderer spriteRen15;
    public SpriteRenderer spriteRen16;
    public SpriteRenderer spriteRen17;
    public SpriteRenderer spriteRen18;
    public SpriteRenderer spriteRen19;
    public SpriteRenderer spriteRen20;
    public SpriteRenderer spriteRen21;
    public SpriteRenderer spriteRen22;
    public SpriteRenderer spriteRen23;

    IEnumerator Start()
    {


        string[] result = new string[24];
        string url = "http://tcon1.dothome.co.kr/memo_2.php";
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
            result[6] = responseData["8"].ToString();
            result[7] = responseData["9"].ToString();
            result[8] = responseData["10"].ToString();
            result[9] = responseData["11"].ToString();
            result[10] = responseData["12"].ToString();
            result[11] = responseData["13"].ToString();
            result[12] = responseData["14"].ToString();
            result[13] = responseData["15"].ToString();
            result[14] = responseData["16"].ToString();
            result[15] = responseData["17"].ToString();
            result[16] = responseData["18"].ToString();
            result[17] = responseData["19"].ToString();
            result[18] = responseData["20"].ToString();
            result[19] = responseData["21"].ToString();
            result[20] = responseData["22"].ToString();
            result[21] = responseData["23"].ToString();
            result[22] = responseData["24"].ToString();
            result[23] = responseData["25"].ToString();
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

        spriteRen0.GetComponent<SpriteRenderer>().sprite = sprite;
        url0 = result[1];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex1);
        sprite = Sprite.Create(mTex1, new Rect(0, 0, mTex1.width, mTex1.height), new Vector2(0, 0), 100);
        spriteRen1.GetComponent<SpriteRenderer>().sprite = sprite;
        url0 = result[2];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex2);
        sprite = Sprite.Create(mTex2, new Rect(0, 0, mTex2.width, mTex2.height), new Vector2(0, 0), 100);
        spriteRen2.GetComponent<SpriteRenderer>().sprite = sprite;
        url0 = result[3];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex3);
        sprite = Sprite.Create(mTex3, new Rect(0, 0, mTex3.width, mTex3.height), new Vector2(0, 0), 100);
        spriteRen3.GetComponent<SpriteRenderer>().sprite = sprite;
        url0 = result[4];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex4);
        sprite = Sprite.Create(mTex4, new Rect(0, 0, mTex4.width, mTex4.height), new Vector2(0, 0), 100);
        spriteRen4.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[5];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex5);
        sprite = Sprite.Create(mTex5, new Rect(0, 0, mTex5.width, mTex5.height), new Vector2(0, 0), 100);
        spriteRen5.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[6];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex6);
        sprite = Sprite.Create(mTex6, new Rect(0, 0, mTex6.width, mTex6.height), new Vector2(0, 0), 100);
        spriteRen6.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[7];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex7);
        sprite = Sprite.Create(mTex7, new Rect(0, 0, mTex7.width, mTex7.height), new Vector2(0, 0), 100);
        spriteRen7.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[8];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex8);
        sprite = Sprite.Create(mTex8, new Rect(0, 0, mTex8.width, mTex8.height), new Vector2(0, 0), 100);
        spriteRen8.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[9];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex9);
        sprite = Sprite.Create(mTex9, new Rect(0, 0, mTex9.width, mTex9.height), new Vector2(0, 0), 100);
        spriteRen9.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[10];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex10);
        sprite = Sprite.Create(mTex10, new Rect(0, 0, mTex10.width, mTex10.height), new Vector2(0, 0), 100);
        spriteRen10.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[11];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex11);
        sprite = Sprite.Create(mTex11, new Rect(0, 0, mTex11.width, mTex11.height), new Vector2(0, 0), 100);
        spriteRen11.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[12];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex12);
        sprite = Sprite.Create(mTex12, new Rect(0, 0, mTex12.width, mTex12.height), new Vector2(0, 0), 100);
        spriteRen12.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[13];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex13);
        sprite = Sprite.Create(mTex13, new Rect(0, 0, mTex13.width, mTex13.height), new Vector2(0, 0), 100);
        spriteRen13.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[14];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex14);
        sprite = Sprite.Create(mTex14, new Rect(0, 0, mTex14.width, mTex14.height), new Vector2(0, 0), 100);
        spriteRen14.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[15];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex15);
        sprite = Sprite.Create(mTex15, new Rect(0, 0, mTex15.width, mTex15.height), new Vector2(0, 0), 100);
        spriteRen15.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[16];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex16);
        sprite = Sprite.Create(mTex16, new Rect(0, 0, mTex16.width, mTex16.height), new Vector2(0, 0), 100);
        spriteRen16.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[17];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex17);
        sprite = Sprite.Create(mTex17, new Rect(0, 0, mTex17.width, mTex17.height), new Vector2(0, 0), 100);
        spriteRen17.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[18];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex18);
        sprite = Sprite.Create(mTex18, new Rect(0, 0, mTex18.width, mTex18.height), new Vector2(0, 0), 100);
        spriteRen18.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[19];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex19);
        sprite = Sprite.Create(mTex19, new Rect(0, 0, mTex19.width, mTex19.height), new Vector2(0, 0), 100);
        spriteRen19.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[20];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex20);
        sprite = Sprite.Create(mTex20, new Rect(0, 0, mTex20.width, mTex20.height), new Vector2(0, 0), 100);
        spriteRen20.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[21];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex21);
        sprite = Sprite.Create(mTex21, new Rect(0, 0, mTex21.width, mTex21.height), new Vector2(0, 0), 100);
        spriteRen21.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[22];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex22);
        sprite = Sprite.Create(mTex22, new Rect(0, 0, mTex22.width, mTex22.height), new Vector2(0, 0), 100);
        spriteRen22.GetComponent<SpriteRenderer>().sprite = sprite;

        url0 = result[23];
        www0 = new WWW(url0);
        yield return www0;
        www0.LoadImageIntoTexture(mTex23);
        sprite = Sprite.Create(mTex23, new Rect(0, 0, mTex23.width, mTex23.height), new Vector2(0, 0), 100);
        spriteRen23.GetComponent<SpriteRenderer>().sprite = sprite;

    }
}

