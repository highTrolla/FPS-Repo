using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public float cameraY;
    public float c_speedY;

    public float cameraX;
    public float c_speedX;

    public float rot;

    float m_PreviousCamY;

    public float speed;

    public float damage;

    //public SpriteRenderer m_SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cameraY = c_speedY * Time.deltaTime * Input.GetAxis("Mouse Y");


        if(cameraY != m_PreviousCamY)
        {
            transform.rotation *= Quaternion.Euler (new Vector3(-cameraY, 0, 0));
            
        }      
        m_PreviousCamY = cameraY;



        if (Input.GetKey(KeyCode.Mouse0))
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           // m_SpriteRenderer.color = Color.red;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
          //  m_SpriteRenderer.color = Color.green;
        }


    }

    void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.Log(hit.transform);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Hurt(damage);
            }
        }
    }

}
