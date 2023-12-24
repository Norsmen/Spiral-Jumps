using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    public float bounceForce = 400f;
    //public GameObject splitPrefab;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other)
    {
        rb.velocity = new Vector3(rb.velocity.x, bounceForce * Time.deltaTime, rb.velocity.z);
        //GameObject newsplit = Instantiate(splitPrefab, new Vector3(transform.position.x, other.transform.position.y, transform.position.z),transform.rotation);
        string materialName = other.transform.GetComponent<MeshRenderer>().material.name;
        

        if (materialName == "Safe (Instance)")
        {
            Debug.Log("safezone");
        }
        if (materialName == "UnSafe (Instance)")
        {
            GameManager.gameOver = true;
        }
        if (materialName == "CenterCylinder (Instance)")
        {
            GameManager.LevelWin = true;
           
        }
    }
}
