using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update() 
    {
        transform.Rotate(0, 1, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            Debug.Log("whoop");
            Destroy(this.gameObject);
        }
    }

}
