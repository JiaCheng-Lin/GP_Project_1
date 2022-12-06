using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    [Header("Scripts:")]
    public GrappleRope grappleRope;
    [Header("Layer Settings:")]
    [SerializeField] private bool grappleToAll = false;
    [SerializeField] private int grappableLayerNumber = 0;

    [Header("Main Camera")]
    public Camera m_camera;

    [Header("Transform Refrences:")]
    public Transform gunHolder;
    public Transform gunPivot;
    public Transform firePoint;

    [Header("Rotation:")]
    [SerializeField] private bool rotateOverTime = true;
    [Range(0, 80)] [SerializeField] private float rotationSpeed = 4;

    [Header("Distance:")]
    [SerializeField] private bool hasMaxDistance = true;
    [SerializeField] private float maxDistance = 4;

    [Header("Launching")]
    [SerializeField] private bool launchToPoint = true;
    [SerializeField] private LaunchType Launch_Type = LaunchType.Transform_Launch;
    [Range(0, 5)] [SerializeField] private float launchSpeed = 3;

    [Header("No Launch To Point")]
    [SerializeField] private bool autoCongifureDistance = false;
    [SerializeField] private float targetDistance = 3;
    [SerializeField] private float targetFrequency = 3;

    private float launchTimer = 0;


    private enum LaunchType
    {
        Transform_Launch,
        Physics_Launch,
    }

    [Header("Component Refrences:")]
    public SpringJoint2D m_springJoint2D;

    [HideInInspector] public Vector2 grapplePoint;
    [HideInInspector] public Vector2 DistanceVector;
    Vector2 Mouse_FirePoint_DistanceVector;

    public Rigidbody2D ballRigidbody;


    public Rigidbody2D rb_bird;
    public bool touch_bird = false;
    public FlyLittleBird range;


    private void Start()
    {
        grappleRope.enabled = false;
        m_springJoint2D.enabled = false;
        ballRigidbody.gravityScale = 4;
        launchTimer = 0;
    }

    private void Update()
    {
        //Debug.Log(rb_bird.position);
        Mouse_FirePoint_DistanceVector = /*m_camera.ScreenToWorldPoint(Input.mousePosition)*/new Vector3(rb_bird.position.x, rb_bird.position.y, 0) - gunPivot.position;
        //Debug.Log(Mouse_FirePoint_DistanceVector); 
        /*if (Input.GetKeyDown(KeyCode.F))
        {
            SetGrapplePoint();
        }
        else */

        if (Input.GetKeyDown(KeyCode.F) && !touch_bird && range.inRange)
        {
            touch_bird = true;
        }
        else if((Input.GetKeyDown(KeyCode.F) && touch_bird))
        {
            touch_bird = false ;
        }
        
        if (touch_bird)
        {
            SetGrapplePoint();
            //touch_bird = true;
            if (grappleRope.enabled)
            {
                grapplePoint = rb_bird.position;
                ballRigidbody.gravityScale = 1f;
                ballRigidbody.mass = 0f;
                /*if (touch_bird)
                {
                    grapplePoint = rb_bird.position;
                    ballRigidbody.gravityScale = 1f;
                    ballRigidbody.mass = 0f;
                }*/
                RotateGun(grapplePoint, false);
                
            }
            else
            {
                RotateGun(m_camera.ScreenToWorldPoint(Input.mousePosition), false);
            }
            grappleRope.isGrappling = false; // if flase it can do grappling.
            
            //Debug.Log("isGrappling" + grappleRope.isGrappling);
            //Debug.Log("launchToPoint" + launchToPoint);
            if (launchToPoint && grappleRope.isGrappling)
            {
                if (Launch_Type == LaunchType.Transform_Launch)
                {
                    gunHolder.position = Vector3.Lerp(gunHolder.position, grapplePoint, Time.deltaTime * launchSpeed);
                }
            }

        }
        else if (!touch_bird) // mouse left released
        {
            grappleRope.enabled = false;
            m_springJoint2D.enabled = false;
            ballRigidbody.gravityScale = 4;
            ballRigidbody.mass = 1f;
            //touch_bird = false;
            launchTimer = 0;
        }
        /*else
        {
            RotateGun(m_camera.ScreenToWorldPoint(Input.mousePosition), true);
        }*/
    }

    void RotateGun(Vector3 lookPoint, bool allowRotationOverTime)
    {
        Vector3 distanceVector = lookPoint - gunPivot.position;

        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        if (rotateOverTime && allowRotationOverTime)
        {
            Quaternion startRotation = gunPivot.rotation;
            gunPivot.rotation = Quaternion.Lerp(startRotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotationSpeed);
        }
        else
            gunPivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    void SetGrapplePoint()
    {
        if (Physics2D.Raycast(firePoint.position, Mouse_FirePoint_DistanceVector.normalized))
        {
            RaycastHit2D _hit = Physics2D.Raycast(firePoint.position, Mouse_FirePoint_DistanceVector.normalized);
            //Debug.Log(_hit.transform.gameObject.layer);
            //Debug.Log(grappableLayerNumber);
            if (/*(_hit.transform.gameObject.tag == "yellowBird" || grappleToAll) &&*/ ((Vector2.Distance(_hit.point, firePoint.position) <= maxDistance) || !hasMaxDistance))
            {
                grapplePoint = _hit.point;
                DistanceVector = grapplePoint - (Vector2)gunPivot.position;
                grappleRope.enabled = true;
                //touch_bird = true;
                //Debug.Log("grapplePoint"+ grapplePoint);
                //Debug.Log("rb_bird" + rb_bird.position);
            }
            /*else if ((_hit.transform.gameObject.layer == grappableLayerNumber || grappleToAll) && ((Vector2.Distance(_hit.point, firePoint.position) <= maxDistance) || !hasMaxDistance))
            {
                grapplePoint = _hit.point;
                DistanceVector = grapplePoint - (Vector2)gunPivot.position;
                grappleRope.enabled = true;
            }*/

        }

    }

    public void Grapple()
    {

        if (!launchToPoint && !autoCongifureDistance)
        {
            m_springJoint2D.distance = targetDistance;
            m_springJoint2D.frequency = targetFrequency;
        }

        if (!launchToPoint)
        {
            if (autoCongifureDistance)
            {
                m_springJoint2D.autoConfigureDistance = true;
                m_springJoint2D.frequency = 0;
            }
            m_springJoint2D.connectedAnchor = grapplePoint;
            m_springJoint2D.enabled = true;
        }

        else
        {
            if (Launch_Type == LaunchType.Transform_Launch)
            {
                ballRigidbody.gravityScale = 0;
                ballRigidbody.velocity = Vector2.zero;
            }

            // launchCnt: prevent frequency too slow
            if (Launch_Type == LaunchType.Physics_Launch && launchTimer >= 0 && launchTimer <= 0.5)
            {
                //Debug.Log("launch");
                m_springJoint2D.connectedAnchor = grapplePoint;
                m_springJoint2D.distance = 2.5f;
                m_springJoint2D.frequency = launchSpeed;
                m_springJoint2D.enabled = true;
                launchTimer += Time.deltaTime;
            }
            else if (Launch_Type == LaunchType.Physics_Launch && launchTimer > 0.5)
            {
                m_springJoint2D.connectedAnchor = grapplePoint;
                m_springJoint2D.distance = 2.5f;
                m_springJoint2D.frequency = 4.0f;
                m_springJoint2D.enabled = true;
                launchTimer += Time.deltaTime;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (hasMaxDistance)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(firePoint.position, maxDistance);
        }
    }

}
