using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vuforia_Random : MonoBehaviour {

    public GameObject RandPrefab;  // 생성할 기둥의 정보 담을 공간

    public int Maximum = 10;   // 미리 생성해놓을 기둥의 갯수
    public float spwanRate = 5;     // 몇초마다 생성 할꺼냐
    public float yMin = -1;    // 랜덤으로 생성할 y값의 최소
    public float yMax = 3.5f;  // 랜덤으로 생성할 y값의 최대
    public float xMin = -1;    // 랜덤으로 생성할 y값의 최소
    public float xMax = 3.5f;


    GameObject[] Randoms;           // 기둥을 담아놓는 배열
    int currentRandom = 0;          // 현재 생성된 기둥의 인덱스 0, 1, 2, 3, 4, 0...
	void Start()
    {
        // 1. 기둥 주소를 담아놓을수있게 5개기둥 할당
        Randoms = new GameObject[Maximum];

        for (int i = 0; i < Maximum; ++i)
        {
            // 프리팹을 복사해서 기둥을 진짜 생성하여 배열에 담아놓는다.
            Randoms[i] = (GameObject)Instantiate(RandPrefab);
            // ()GameObject를 하이어아키뷰에 생성한다.
            Randoms[i].transform.position = new Vector2(100, 100);
        }

        // 코루틴 : 사용자가 정의한 매 시간마다 함수를 호출한다.
        StartCoroutine("SpawnLoop");
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            // 스포너 원래 위치값 저장
            Vector2 pos = transform.position;

            // y값을 랜덤으로 변경
            pos.x = Random.Range(xMin, xMax);
            pos.y = Random.Range(yMin, yMax);

            // 변경된 위치를 미리 생성해놓은 친구의 위치로 변경한다.
            Randoms[currentRandom].transform.position = pos;

            // 배열 크기보다 커지면 0으로 변경
            if (++currentRandom >= Maximum)
                currentRandom = 0;

            yield return new WaitForSeconds(spwanRate);
        }
    }
}
