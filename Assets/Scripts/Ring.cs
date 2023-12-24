using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private Transform player;
    public GameObject[] childrings;
    float radius = 100f;
    float force = 500f;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    private void Update()
    {
        if (transform.position.y > player.position.y )
        {
            GameManager.noOfPassingRings++;
            for (int i = 0; i < childrings.Length; i++)
            {
                childrings[i].GetComponent<Rigidbody>().isKinematic = false;
                childrings[i].GetComponent<Rigidbody>().useGravity = true;

                Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
                foreach (Collider newCollider in colliders)
                {
                    Rigidbody rb = newCollider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(force, transform.position, radius);
                    }
                }
                childrings[i].GetComponent<MeshCollider>().enabled = false;
                childrings[i].transform.parent = null;
                Destroy(childrings[i].gameObject, 2f);
                Destroy(this.gameObject, 5f);
            }
            this.enabled = false;
        }


        {
            
        }
    }
}
