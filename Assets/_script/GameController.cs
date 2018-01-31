using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int loadIndex;
    private static int loadCount;

    public bool loginCheck = false;// 로그인확인
    public bool markerCheck = false;   // 마커인식확인
    public string position = "";    // 인식된 마커이름을 여기 넣어서 현재 위치 확인
    public string userid = "";

    void Awake()
    {

        loadIndex = loadCount;
        loadCount++;
        print("Awake : " + gameObject.name + ", index is " + loadIndex);

        if (loadIndex == 0)
        {
            print("DontDestroyOnLoad function call");
            DontDestroyOnLoad(gameObject);
            // 가장 처음에 로드 되었을 때 할일들을 여기에 작성.
            // 일종의 Initialize
        }
        else
        {
            print("Remove existing objects");
            // 두 번 이상 해당 씬에 로드되어 기존 오브젝트와 유지된 오브젝트가 중첩됨.
            // 그러므로 여기서 기존 Scene에 올라가는 오브젝트를 제거함.
            Destroy(gameObject);
        }
    }
}