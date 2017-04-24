using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public GameObject target;

    public float moveSpeed = 10f;
    public float rotSpeed = 2f;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Vector3.Distance(transform.position, target.transform.position) < 5.0f)
            return;

        Vector3 targetPos = target.transform.position;
        targetPos.y = transform.position.y;

        Vector3 rotDir = targetPos - transform.position;


        Quaternion targetRotation = Quaternion.LookRotation(rotDir);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);

        transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime));
  }
}
