using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;

    public float cameraX;
    public float c_speedX;
    public Text Health;
    public int HP;

    void Start()
    {

    }

    void Update()
    {

        string hpStr;

        hpStr = "HP:";
        for (int i = 0; i < HP; i++)
        {
            hpStr += " ♥";
        }

        Health.text = hpStr;


        cameraX += c_speedX * Input.GetAxis("Mouse X");

        transform.eulerAngles = new Vector3(0, cameraX, 0);


        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
 
        if (HP == 0)
        {
            WorldManager.Load(WorldManager.Scene.Title);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "MedKit")
        {
            Debug.Log("heal");
            HP += 1;
        }
    }

    public void Hurt()
    {
        HP -= 1;
    }
}
