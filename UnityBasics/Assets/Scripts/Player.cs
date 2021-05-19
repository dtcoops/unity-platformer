using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private int playerSpeedMultiplier;
    [SerializeField] private int playerJumpVelocityMultiplier;
    
    private Rigidbody rigidbodyComponent;

    private bool isJumping = false;
    private float horizontalInput;
    private bool doubleJumpEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check is space  key is pressed down
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            Debug.Log("Space key was pressed down");
            isJumping = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    // Fixed Update is called once every physics update
    private void FixedUpdate()
    {
        // left - right
        rigidbodyComponent.velocity = new Vector3(horizontalInput * playerSpeedMultiplier, rigidbodyComponent.velocity.y, 0);

        // sphere is not touching any colliders
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            if (doubleJumpEnabled && isJumping)
            {
                rigidbodyComponent.AddForce(Vector3.up * playerJumpVelocityMultiplier * Time.deltaTime, ForceMode.VelocityChange);
                doubleJumpEnabled = false;
                isJumping = false;
            }
            return;
        }
        
        if (isJumping)
        {
            rigidbodyComponent.AddForce(Vector3.up * playerJumpVelocityMultiplier * Time.deltaTime, ForceMode.VelocityChange);
            isJumping = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // layer 9 is coin
        if(other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            doubleJumpEnabled = true;
        }

        // layer 4 is water
        if(other.gameObject.layer == 4)
        {
            // this.transform.position = new Vector3(0, 1, 0);
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
