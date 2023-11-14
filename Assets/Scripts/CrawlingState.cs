using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlingState : PlayerState
{
    float moveSpeed = 3f;
    bool grounded = true;
    bool initialGrounded = true;

    public override void Enter(Player player)
    {
        Rigidbody2D rig = player.GetComponent<Rigidbody2D>();
        Move(rig);
        Transform tr = player.GetComponent<Transform>();
        if (player.transform.localScale.y == 1.5f)
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - .75f, player.transform.position.z);
        tr.localScale = new Vector3(1.5f, 0.5f, 1.5f);
        RaycastHit2D hit1 = Physics2D.Raycast(player.transform.position - new Vector3(.5f, .26f, 0f), player.transform.TransformDirection(Vector2.down), 0.05f);
        RaycastHit2D hit2 = Physics2D.Raycast(player.transform.position - new Vector3(-.5f, .26f, 0f), player.transform.TransformDirection(Vector2.down), 0.05f);
        //Debug.Log("hit = " + hit.collider.name);
        if (!hit1 && !hit2)
        {
            grounded = false;
            initialGrounded = false;
        }
    }
    public override PlayerState HandleInput(Player player)
    {
        if (Input.GetKeyUp(KeyCode.S))
            return new WalkingState();
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && grounded)
            return new DuckingState();
        if (Input.GetKeyDown(KeyCode.Space))
            return new JumpingState();
        return null;
    }

    public override void Update(Player player)
    {
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        if (Input.GetKey(KeyCode.D))
            sr.flipX = false;
        else if (Input.GetKey(KeyCode.A))
            sr.flipX = true;
        Rigidbody2D rig = player.GetComponent<Rigidbody2D>();
        Move(rig);
        RaycastHit2D hit1 = Physics2D.Raycast(player.transform.position - new Vector3(.5f, .51f, 0f), player.transform.TransformDirection(Vector2.down), 0.05f);
        RaycastHit2D hit2 = Physics2D.Raycast(player.transform.position - new Vector3(-.5f, .51f, 0f), player.transform.TransformDirection(Vector2.down), 0.05f);
        //Debug.Log("hit = " + hit.collider.name);
        if (!hit1 && !hit2)
        {
            grounded = false;
            if (!initialGrounded || !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                moveSpeed = 1.5f;
        }
        else
        {
            grounded = true;
            moveSpeed = 3f;
        }
    }

    void Move(Rigidbody2D rig)
    {
        float x = Input.GetAxis("Horizontal");
        float y = rig.velocity.y;

        rig.velocity = new Vector2(x * moveSpeed, y);
    }
}
