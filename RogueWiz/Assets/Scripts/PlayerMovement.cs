using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;

    Vector2 direction;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        TakeInput();
        PlayerMove();
    }

    void TakeInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
    }

    void PlayerMove()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (direction.x != 0 || direction.y != 0)
        {
            SetAnimatorMovement(direction);
        }
        else
        {
            anim.SetLayerWeight(1, 0);
        }
    }

    void SetAnimatorMovement(Vector2 dir)
    {
        anim.SetLayerWeight(1, 1);

        anim.SetFloat("xDir", dir.x);
        anim.SetFloat("yDir", dir.y);
    }
}
