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
        else if (col.gameObject.name.Contains("Ghost")) // CompareTag("Enemies")
        {
            Debug.Log(col.gameObject.name);
            Die();
        }
    }

    void Move()
    {
        if (b_isDead)
            return;

        Vector3 v3Target = new Vector3(joystick.Horizontal, 0, joystick.Vertical);

        tf_this.position += v3Target * f_deltaTime * f_moveSpeed;
    }

    void Die()
    {
        b_isDead = true;

        gameManager.SetDiePage(b_isDead);
    }
}
