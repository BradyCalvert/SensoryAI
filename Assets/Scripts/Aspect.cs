using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Aspects
{
    Player,
    Enemy
}
public class Aspect : MonoBehaviour
{

  

    Vector3 targetPos;
    public float moveSpeed = 5f, rotSpeed = 2f, minX=-45, maxX=45, minZ=-45, maxZ=45;



    public Aspects aspectToHunt;
    void Start()
    {
        GetNextPosition();
    }

    void Update()
    {
        //checkIF we are near the target point
        if(Vector3.Distance(transform.position,targetPos)<5)
        {
            GetNextPosition();
        }
        Vector3 tarPos = targetPos;
        tarPos.y = transform.position.y;
        Vector3 rotDirection = targetPos - transform.position;

        Quaternion tarRot = Quaternion.LookRotation(rotDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, tarRot, rotSpeed * Time.deltaTime);

        transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime));
    }

    void GetNextPosition()
    {
        targetPos = new Vector3(UnityEngine.Random.Range(minX, maxX), .5f, UnityEngine.Random.Range(minZ, maxZ));
    }
}
