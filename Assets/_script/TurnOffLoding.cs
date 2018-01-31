using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffLoding : MonoBehaviour {

    public GameObject _loadingPopup;

    // Use this for initialization
    void Start () {
        _loadingPopup.SetActive(false);
    }

}
