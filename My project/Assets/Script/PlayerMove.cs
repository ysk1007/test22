using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movespeed = 1f;
    public float jumppower = 1f;
    public int jumpcount = 1;
    Rigidbody2D Rigid;

    // Start is called before the first frame update
    void Start()
    {
        Rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

    }

    void FixedUpdate()
    {
        Move();
    }

   void Move()
    {
        Vector3 moveVelocity = Vector3.zero;  // x,y,z를 0으로 저장
        float h = Input.GetAxisRaw("Horizontal");
        if (h < 0)
        {
            moveVelocity = Vector3.left;  //좌측이동
        }
        else if(h > 0)
        {
            moveVelocity = Vector3.right; // 우측이동
        }
        transform.position += moveVelocity * movespeed * Time.deltaTime;
    }

    void Jump()
    {
        if (jumpcount == 0)
        {
            return;
        }

        Rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumppower);
        Rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
        jumpcount -= 1;
       
    }
}
