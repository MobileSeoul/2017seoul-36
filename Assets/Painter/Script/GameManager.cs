using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject linePrefab;
    public List<GameObject> linePrefabList = new List<GameObject>();

	[HideInInspector]
    public GameObject currentLine;
    public int currentLineNumber = 1;

	// Update is called once per frame
    void Update()
    {
        if (currentLine == null)
        {
            currentLine = Instantiate(linePrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            linePrefabList.Add(currentLine);
        }      
    }
}
