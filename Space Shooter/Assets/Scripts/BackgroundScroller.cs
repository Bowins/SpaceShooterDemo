using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

    [SerializeField] float backgroundScrollSpeed = 0.7f;
    [SerializeField] float backgroundSideScrollSpeed;
    Material myMaterial;
    Vector2 offSet;

	// Use this for initialization
	void Start () {
        backgroundSideScrollSpeed = Random.Range(-0.2f, 0.2f);
        myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(backgroundSideScrollSpeed, backgroundScrollSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
		
	}
}
