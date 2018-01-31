using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class MenuPainter : MonoBehaviour {

    public Material colorPrefabMaterial;
    public GameObject drawLine;
    public Shader shader;
    public Color _color;
    public GameObject[] colorANDpan;
    public Image[] imageStatus;
    public Color[] colorPens;
    private bool i = true;
    public GameObject[] GAMEOBJECTSCOLORPEN;

    void Awake()
    {
        GAMEOBJECTSCOLORPEN = GameObject.FindGameObjectsWithTag("GAMEOBJECTSCOLORPEN");
    }
	// Use this for initialization
	void Start () {

        drawLine.GetComponent<DrawLine>().material = colorPrefabMaterial;
        colorPrefabMaterial.color = colorPens[1];

        colorANDpan[0].active = false;
        colorANDpan[1].active = false;
	}
	  
    public void ClickButton(int idCAP) //����, �귯������ ����/ ����:1, ��:0
    {
        

        colorANDpan[0].active = false;
        colorANDpan[1].active = false;
            if (i)
            {
                
                colorANDpan[idCAP].active = true;
                i = false;
            }
            else
            { 
               
                   colorANDpan[idCAP].active = false;
                i = true;
            }
        
    }
    public void ColorButton(int idColor) //�� ����� idColor: ����ȣ
    {
        colorPrefabMaterial = new Material(shader);
        drawLine.GetComponent<DrawLine>().material = colorPrefabMaterial;
        colorPrefabMaterial.color = colorPens[idColor];
        for (int i = 0; i < GAMEOBJECTSCOLORPEN.Length ; i++)
        {
            GAMEOBJECTSCOLORPEN[i].GetComponent<Image>().color = colorPens[idColor];
        }
      
    }
    public void ScalePen(float idScale) //�� ���� ����, idScale: �� �����ȣ
    {
        drawLine.GetComponent<DrawLine>().lineWidth = idScale;
    }
    public void Destroy()
    {
        for (int i = 0; i <  gameObject.GetComponent<GameManager>().linePrefabList.Count; i++)
        {
            Destroy(gameObject.GetComponent<GameManager>().linePrefabList[i]);
        }
       
 

    }
     public void ScreenShot()
     {
         colorANDpan[0].active = false;
         colorANDpan[1].active = false;

         string path = Application.persistentDataPath + "/Screenshot.png";
             ScreenCapture.CaptureScreenshot(path);
             Debug.Log(path);
     }
    
    /*
    public void capture()
    {
    
        if (Application.isEditor == true)
        {
            Application.CaptureScreenshot("num_"+Time.time.ToString()+".png");
        }
        else
        {
            Application.CaptureScreenshot("../../../../DCIM/Camera/num_" + Time.time.ToString() + ".png");
        }
    }
    */
   
    public void ClosePallete()
    {
        colorANDpan[0].active = false;
        colorANDpan[1].active = false;
    }
}



///////

