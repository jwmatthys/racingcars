using UnityEngine;

public class ArcadeCarController : MonoBehaviour
{
    public Rigidbody sphereRigidbody;
    public float forwardForce = 8f;
    public float reverseForce = 4f;
    public float gravityForce = 1000f;
    public float maxSpeed = 50f;
    public float turnStrength = 100f;
    public float forceScaleFactor = 10000f;
    [HideInInspector] public float steeringInput;
    [HideInInspector] public float forceInput;
    private bool grounded;
    public LayerMask whatIsGround;
    public float groundRayLength = 0.5f;
    public Transform groundRayCheck;
    private float drag;
    public Transform leftFrontWheel, rightFrontWheel;
    public float maxWheelTurn;
    
    void Start()
    {
        sphereRigidbody.transform.parent = null;
        drag = sphereRigidbody.linearDamping;
    }

    void Update()
    {
        if (grounded)
        {
            float turnValue = steeringInput * forceInput * turnStrength * Time.deltaTime;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles +
                                                  new Vector3(0f, turnValue, 0f));
        }
        transform.position = sphereRigidbody.transform.position;
        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x,
            (steeringInput * maxWheelTurn),
            leftFrontWheel.localRotation.eulerAngles.z);
        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x,
            (steeringInput * maxWheelTurn),
            rightFrontWheel.localRotation.eulerAngles.z);
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        grounded = Physics.Raycast(groundRayCheck.position, Vector3.down, out hit, groundRayLength, whatIsGround);
    
        if (grounded)
        {
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

            sphereRigidbody.linearDamping = drag;
            if (forceInput > 0)
            {
                sphereRigidbody.AddForce(forceInput * forwardForce * forceScaleFactor * transform.forward);
            }
            else if (forceInput < 0)
            {
                sphereRigidbody.AddForce(forceInput * reverseForce * forceScaleFactor * transform.forward);
            }
        }
        else
        {
            sphereRigidbody.linearDamping = 0.1f;
            sphereRigidbody.AddForce(gravityForce * Vector3.down);
        }
    }
}