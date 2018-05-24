using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadQ : MonoBehaviour {
    [SerializeField]
    private string scene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Onclick()
    {
        SceneManager.LoadScene(scene);
    }
}
