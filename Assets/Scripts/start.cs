using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class start : MonoBehaviour {
	[SerializeField]
	private player target;
    [SerializeField]
    private Button startBtn;
    [SerializeField]
	private InputField MyNameTxt;
	[SerializeField]
	private WaveDisplay wave;
    // Use this for initialization
    void Start () {
        startBtn.onClick.AddListener(go);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void go()
    {
        Debug.Log(MyNameTxt.text);
        this.gameObject.SetActive(false);
		wave.gameObject.SetActive(true);
		target.GameStart();
    }
}
