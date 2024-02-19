using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform transform = GetComponent<Transform>();
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);

        //阶梯超出范围后，删除并从下边重新生成
        
        if(transform.position.y > 5f)
        {
            FloorManager floorManager = transform.parent.GetComponent<FloorManager>();
            floorManager.SpawnFloor(gameObject.tag);
            Destroy(gameObject);
        }
    }
}
