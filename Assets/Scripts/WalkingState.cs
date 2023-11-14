using UnityEngine;

public class WalkingState : PlayerState
{
    float moveSpeed = 5f;
    bool grounded = true;
    //bool initialGrounded = true;

    public override void Enter(Player player)
    {
        Rigidbody2D rig = player.GetComponent<Rigidbody2D>();
        if (player.transform.localScale.y == 0.5f)
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + .75f, player.transform.position.z);
        player.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        Move(rig);
        RaycastHit2D hit1 = Physics2D.Raycast(player.transform.position - new Vector3(.55f, 1.2f, 0f), player.transform.TransformDirection(Vector2.down), .05f);
        RaycastHit2D hit2 = Physics2D.Raycast(player.transform.position - new Vector3(-.55f, 1.2f, 0f), player.transform.TransformDirection(Vector2.down), .05f);
        //Debug.Log("hit = " + hit.collider.name);
        if (!hit1 && !hit2)
        {
            grounded = false;
            //initialGrounded = false;
        }
    }
    public override PlayerState HandleInput(Player player)
    {
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && grounded)
            return new StandingState();
        else if (Input.GetKeyDown(KeyCode.S))
            return new CrawlingState();
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
        RaycastHit2D hit1 = Physics2D.Raycast(player.transform.position - new Vector3(.55f, 1.2f, 0f), player.transform.TransformDirection(Vector2.down), .05f);
        RaycastHit2D hit2 = Physics2D.Raycast(player.transform.position - new Vector3(-.55f, 1.2f, 0f), player.transform.TransformDirection(Vector2.down), .05f);
        //Debug.Log("hit = " + hit.collider.name);
        if (!hit1 && !hit2)
        {
            grounded = false;
        }
        else
        {
            grounded = true;
            moveSpeed = 5f;
        }
    }

    void Move(Rigidbody2D rig)
    {
        float x = Input.GetAxis("Horizontal");
        float y = rig.velocity.y;

        rig.velocity = new Vector2(x * moveSpeed, y);
    }
}