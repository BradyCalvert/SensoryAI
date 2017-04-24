using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sense : MonoBehaviour {

    public bool shouldDebug = true;
    public Aspects aspectName = Aspects.Enemy;
    public float detectionRate = 1f;
    protected float elapsedTime = 0f;
    protected virtual void Initialize() { }
    protected virtual void UpdatedSense() { }

	// Use this for initialization
	void Start () {
        elapsedTime = 0f;
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
        UpdatedSense();
	}
}
