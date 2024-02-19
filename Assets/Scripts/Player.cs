using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    float moveSpeed = 5f;
    [SerializeField] int HP = 10;
    GameObject currentFloor;
    [SerializeField] TextMeshProUGUI HPText;
    int Score = 0;
    [SerializeField] TextMeshProUGUI ScoreText;
    float scoreTime = 0f;
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

        ChangeScore();
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
                ChangeHP(1);
            }  
        }
        if(other.gameObject.tag == "NailsFloor")
        {
            if(other.contacts[0].normal == Vector2.up)
            {
                currentFloor = other.gameObject;
                ChangeHP(-3);
            }
        }
        if(other.gameObject.tag == "TopWall")
        {
            Debug.Log("current" + currentFloor.name);
            currentFloor.GetComponent<BoxCollider2D>().enabled = false;
            ChangeHP(-3);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "DeathLine")
        {
            Debug.Log("寄");
        }
    }

    void ChangeHP(int change)
    {
        HP += change;
        if(HP > 10)
        {
            HP = 10;
        }
        if(HP < 0)
        {
            HP = 0;
        }
        HPText.text = "HP:" + HP;
    }

    void ChangeScore()
    {
        scoreTime += Time.deltaTime;
        if(scoreTime > 2f)
        {
            Score++;
            scoreTime = 0f;
            ScoreText.text = "地下" + Score.ToString() + "层";
        }
    }
}
