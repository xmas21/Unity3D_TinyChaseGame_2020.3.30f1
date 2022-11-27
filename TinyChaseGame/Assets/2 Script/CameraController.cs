using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] [Header("追蹤速度")] float f_TrackSpeed = 10f;
    float f_deltaTime;

    [SerializeField] [Header("左右方限制")] Vector2 v2_HorizontalLimit;
    [SerializeField] [Header("上下方限制")] Vector2 v2_VerticalLimit;

    Transform tf_this;
    Transform tf_player;

    void Awake()
    {
        tf_this = GetComponent<Transform>();
        tf_player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Start()
    {
        v2_HorizontalLimit = new Vector2(-13.5f, 13.5f);
        v2_VerticalLimit = new Vector2(-10.5f, 10.5f);

        f_TrackSpeed = 10f;
        f_deltaTime = Time.deltaTime;
    }

    void LateUpdate()
    {
        Track();
    }

    void Track()
    {
        Vector3 v_camera = tf_this.position;
        Vector3 v_player = tf_player.position;

        v_player.x = Mathf.Clamp(v_player.x, v2_HorizontalLimit.x, v2_HorizontalLimit.y);
        v_player.y = 20;
        v_player.z = Mathf.Clamp(v_player.z, v2_VerticalLimit.x, v2_VerticalLimit.y);

        // v_camera = Vector3.Lerp(v_camera, v_player, f_TrackSpeed * f_deltaTime);
        v_camera = v_player;

        tf_this.localPosition = v_camera;
    }
}
