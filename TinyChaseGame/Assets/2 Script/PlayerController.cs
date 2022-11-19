using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody rig;
    Joystick joystick;
    Transform tf_this;
    GameManager gameManager;

    float f_moveSpeed;
    float f_deltaTime;

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
        f_deltaTime = Time.deltaTime;
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
        else if (col.gameObject.CompareTag("Enemies"))
        {
            Die();
        }
    }

    void Move()
    {
        Vector3 v3Target = new Vector3(joystick.Horizontal, 0, joystick.Vertical);

        tf_this.position += v3Target * f_deltaTime * f_moveSpeed;
    }

    void Die()
    {
        gameManager.SetDiePage(true);
    }
}
