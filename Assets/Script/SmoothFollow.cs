using UnityEngine;


public class SmoothFollow : MonoBehaviour
{
    //static SmoothFollow _instance;
    //public static SmoothFollow instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //        {
    //            _instance = GameObject.FindObjectOfType<SmoothFollow>();
    //        }
    //        return _instance;
    //    }
    //}
    public static SmoothFollow instance;

    // The target we are following
    [SerializeField]
    public Transform target;
    // The distance in the x-z plane to the target
    [SerializeField]
    private float distance = 10.0f;
    // the height we want the camera to be above the target
    [SerializeField]
    private float height = 5.0f;

    [SerializeField]
    private float rotationDamping;
    [SerializeField]
    private float heightDamping;
    public bool ignoreTimescale;
    private float m_LastRealTime;
    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start()
    {
        m_LastRealTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float deltaTime = Time.deltaTime;
        if (ignoreTimescale)
        {
            deltaTime = (Time.realtimeSinceStartup - m_LastRealTime);
            m_LastRealTime = Time.realtimeSinceStartup;
        }
        // Early out if we don't have a target
        if (!target)
            return;

        // Calculate the current rotation angles
        var wantedRotationAngle = target.eulerAngles.y;
        var wantedHeight = target.position.y + height;

        var currentRotationAngle = transform.eulerAngles.y;
        var currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * deltaTime);

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * deltaTime);

        // Convert the angle into a rotation
        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        // Set the height of the camera
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        // Always look at the target
        transform.LookAt(target);

    }
}