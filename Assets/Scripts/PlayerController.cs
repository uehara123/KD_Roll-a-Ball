using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody rb;
    public Hole hole;
    public GameController gameController;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 vector = Vector3.zero;


        if (Application.isMobilePlatform)
        {
            vector.x = Input.acceleration.x;
            vector.z = Input.acceleration.y;
        }
        else
        {
            vector.x = Input.GetAxis("Horizontal");
            vector.z = Input.GetAxis("Vertical");
        }

        if (hole.DestroyedPlayer())
        {
            rb.velocity = new Vector3(0, -5.0f, 0);
        }

        if (gameController.Pausing())
        {
            rb.velocity = Vector3.zero;
        }

        if (vector.sqrMagnitude > 1)
            vector.Normalize();

        // ForceMode.Force = Time.deltaTime / Mass
        rb.AddForce(vector * speed, ForceMode.Force);
    }
}
