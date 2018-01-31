using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawLine : MonoBehaviour 
{
    [HideInInspector]
    public LineRenderer line;

    private GameManager manager;

    //Status clicking mouse
    private bool isMousePressed = false;

    //list coordinates mouse for line
    private List<Vector3> pointsList = new List<Vector3>();

    //Material line (color lines)
    //[HideInInspector]
    public Material material;

    //Position mouse in background
    private Vector3 mousePos;

    //Line Scale
    [Range(0.1f, 1.0f)]
    public float lineWidth = 0.1f;

    public bool infoForDraw = true;

	//	-----------------------------------	
	void Awake()
	{       
		// Create line renderer component and set its property
		line = gameObject.AddComponent<LineRenderer>();
		line.useWorldSpace = false;
		line.material =  material;
		line.SetVertexCount(0);
        line.SetWidth(lineWidth, lineWidth);
		manager = (GameManager)GameObject.FindObjectOfType(typeof(GameManager));   
	}

    void Start()
    {
        line.sortingOrder = manager.linePrefabList.Count;
    }
	//	-----------------------------------	
    void Update()
    {
        Control();
    }

    void Control()
    { 
                // If mouse button down, remove old line.
                if (Input.GetMouseButtonDown(0))
                {                   
                        isMousePressed = true;
                        line.SetVertexCount(0);
                        pointsList.RemoveRange(0, pointsList.Count);                 
                }
                else if (Input.GetMouseButtonUp(0))
                {
                     isMousePressed = false;
                        manager.currentLine = null;
                        this.enabled = false;                    
                }

                // Drawing line when mouse is moving(presses)
                if (isMousePressed)
                {                   
                    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mousePos.z = 0;
                    if (!pointsList.Contains(mousePos))
                    {
                        pointsList.Add(mousePos);
                        line.SetVertexCount(pointsList.Count);
                        line.SetPosition(pointsList.Count - 1, (Vector3)pointsList[pointsList.Count - 1]);
                    }
                }
    }
}