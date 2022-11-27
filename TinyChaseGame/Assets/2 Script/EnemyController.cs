using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] [Header("Ä²µo°lÂÜ¶ZÂ÷")] float f_trackRange;

    Light[] lights = new Light[2];

    Rigidbody rig;
    NavMeshAgent nav;
    Transform tf_player;
    Transform tf_this;
    Vector3 v3_player;

    bool bo_isTracking;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();

        tf_this = GetComponent<Transform>();
        tf_player = GameObject.Find("Player").GetComponent<Transform>();

        lights[0] = transform.GetChild(0).GetComponent<Light>();
        lights[1] = transform.GetChild(1).GetComponent<Light>();
    }

    void Start()
    {
        rig.useGravity = false;
        rig.isKinematic = true;

        nav.speed = 4.5f;
        nav.radius = 3f;
        nav.height = 2f;
    }

    void FixedUpdate()
    {
        SetTrackState();
        Track();
    }

    void SetTrackState()
    {
        if (Vector3.Distance(tf_this.position, tf_player.position) <= f_trackRange)
        {
            bo_isTracking = true;
            lights[0].enabled = bo_isTracking;
            lights[1].enabled = bo_isTracking;
        }
    }

    void Track()
    {
        if (!bo_isTracking)
            return;

        v3_player = tf_player.position;
        v3_player.y = tf_this.position.y;

        nav.SetDestination(v3_player);
    }
}
