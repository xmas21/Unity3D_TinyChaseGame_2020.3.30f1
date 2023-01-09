using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody rig;
    Joystick joystick;
    Transform tf_this;
    GameManager gameManager;

    float f_moveSpeed = 5f;

    bool b_isDead;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
        tf_this = GetComponent<Transform>();

        joystick = GameObject.Find("Floating Joystick").GetComponent<Joystick>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        rig.useGravity = false;
        f_moveSpeed = 5f;
    }

    void FixedUpdate()
    {
        Move();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Collects"))
        {
            Destroy(col.gameObject);
            gameManager.Decrease();
        }
        else if (col.gameObject.name.Contains("Ghost"))
        {
            Die();
        }
    }

    void Move()
    {
        if (b_isDead)
            return;

        Vector3 v3Target = new Vector3(joystick.Horizontal, 0, joystick.Vertical);

        if (joystick.Horizontal < 0)
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        else if (joystick.Horizontal > 0)
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        tf_this.position += v3Target * Time.deltaTime * f_moveSpeed;
    }

    void Die()
    {
        b_isDead = true;

        gameManager.SetDiePage(b_isDead);
    }
}
