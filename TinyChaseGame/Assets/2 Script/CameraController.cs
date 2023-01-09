using UnityEngine;

public class CameraController : MonoBehaviour
{
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
        v2_HorizontalLimit = new Vector2(-15f, 15f);
        v2_VerticalLimit = new Vector2(-13f, 13f);
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

        v_camera = v_player;

        tf_this.localPosition = v_camera;
    }
}
