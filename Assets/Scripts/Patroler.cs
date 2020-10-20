using UnityEngine;

public class Patroler : MonoBehaviour
{
    public Enemy enemy;
    public float timer;
    public float patrolTime;
    public float speed;
    public float rotDegrees;

    public Vector3 patrolRot;

    void Start()
    {
        enemy.canSee = false;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (enemy.aggro == false)
        {
         //   transform.eulerAngles = patrolRot;
         //  patrolRot = transform.eulerAngles;
            timer += Time.deltaTime;
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            if (timer > patrolTime)
            {
                transform.Rotate(0, rotDegrees, 0);
                timer = 0;
            }

        }
        else
        {

        }
    }

    

}
