using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void FixedUpdate()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1))
        {
            Debug.Log(hit.transform.name);


            Player player = hit.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Hurt();
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        Debug.DrawRay(transform.position, transform.forward, Color.red);

    }

}
