using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    float moveSpeed = 5f;
    [SerializeField] int HP = 10;
    GameObject currentFloor;
    [SerializeField] TextMeshProUGUI HPText;
    int Score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    float scoreTime = 0f;
    [SerializeField] GameObject replayButton;
    [SerializeField] TextMeshProUGUI dieText;
    [SerializeField] GameObject startButton;
    void Start()
    {
        Time.timeScale = 0;
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
            //游戏结束
            Die();
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
            //游戏结束
            Die();
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
            scoreText.text = "地下" + Score.ToString() + "层";
        }
    }

    void Die()
    {
        Time.timeScale = 0;
        replayButton.SetActive(true);
        dieText.gameObject.SetActive(true);
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void StartPlay()
    {
        Time.timeScale = 1;
        startButton.SetActive(false);
    }
}
