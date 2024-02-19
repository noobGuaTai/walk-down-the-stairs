using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    float moveSpeed = 5f;
    int health = 10;
    GameObject currentFloor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //左右移动
        Transform transform = GetComponent<Transform>();
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }

        
    }

    //碰撞判断
    void OnCollisionEnter2D(Collision2D other)
    {
    
        Debug.Log("碰到了" + other.gameObject.tag);

        if(other.gameObject.tag == "NormalFloor")
        {
            if(other.contacts[0].normal == Vector2.up)
            {
                currentFloor = other.gameObject;
                health += 1;
                if(health > 10)
                {
                    health = 10;
                } 
            }  
        }
        if(other.gameObject.tag == "NailsFloor")
        {
            if(other.contacts[0].normal == Vector2.up)
            {
                currentFloor = other.gameObject;
                health -= 1;
                if(health < 1)
                {
                    Debug.Log("寄");
                } 
            }
        }
        if(other.gameObject.tag == "TopWall")
        {
            Debug.Log("current" + currentFloor.name);
            currentFloor.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "DeathLine")
        {
            Debug.Log("寄");
        }
    }
}
