using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Perspective : Sense {
    int fieldOfView = 45;//degree
    int viewDistance = 100;


    GameObject playerObj;
    Vector3 rayDir;
    protected override void Initialize()
    {
        //Find player position
       playerObj = GameObject.FindWithTag("Player");
    }

    protected override void UpdatedSense()
    {
        elapsedTime += Time.deltaTime;


            if(elapsedTime>=detectionRate)
        {
            DetectAspect();
        }
    }
    void DetectAspect()
    {
        RaycastHit hit;
        //get the direction from the currnet opiosition to the players positon

        rayDir = playerObj.transform.position - transform.position;



        //check the angel beteween teh air forwarc vector and dir vector and air and playuer

        if(Vector3.Angle(rayDir,transform.forward)<fieldOfView)
        {
            if (Physics.Raycast(transform.position, rayDir, out hit, viewDistance))
            {
                Aspect aspect = hit.collider.GetComponent<Aspect>();


                if (aspect != null)
                {
                    if (aspect.aspectToHunt == aspectName)
                    {
                        Debug.Log("EnemyDetected");
                    }
                }
            }
        }
    }


}
