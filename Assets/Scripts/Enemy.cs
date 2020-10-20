using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor.Experimental.GraphView;
using UnityEditor;

public class Enemy : MonoBehaviour
{
    public float maxHP;
    public float currentHP;
    public Renderer rend;
    public float heal;
    public bool aggro;
    public GameObject bullet;

    public static float deathCount;

    public bool canSee;

    public float timer;
    public float shotInterval;
    public bool firstShot;

    Color colorStart = Color.red;
    Color colorEnd = Color.white;

    public float colorValue;

    private Transform target;
    public float rotSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        target = GameObject.Find("Player").transform;
        firstShot = false;
        deathCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        colorValue = currentHP / maxHP;
        rend.material.color = Color.Lerp(colorStart, colorEnd, colorValue);

        if (currentHP <= 0)
        {
            print("plzdie");
            transform.DOPunchScale(Vector3.one * 0.1f, 0.1f).OnComplete(Kill);
        }
        else if (currentHP < maxHP)
        {
            currentHP += heal * Time.deltaTime;
        }

        if (canSee == true)
       {
            transform.LookAt(target.position);
       }

        if (aggro == true)
        {
            timer += Time.deltaTime;

            if (!firstShot)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                firstShot = true;
            }

            if (timer > shotInterval)
            {
                print("fire!");
                Instantiate(bullet, transform.position, transform.rotation);
                timer = 0;
            }            
        }
        else
        {
            firstShot = false;
        }

    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Player player = hit.transform.GetComponent<Player>();
            if (player != null) 
            {
                aggro = true;
                canSee = true;
            }
            else
            {
                aggro = false;
            }
        }
        Debug.DrawRay(transform.position, transform.forward, Color.green);
    }

    public void Hurt (float amount)
    {
        currentHP -= amount * Time.deltaTime;
    }

    private void Kill()
    {
        deathCount += 1;
        Destroy(this.gameObject);
    }
}
