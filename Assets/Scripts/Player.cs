using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3;
    public Rigidbody rb;
    [SerializeField] private Camera m_camera;
    [SerializeField] private int forceGravity = 5;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Animator mAnimator;

    private bool canJump = true;
    private float defaultSpeed;

    // Start is called before the first frame update
    void Start()
    {
        defaultSpeed = speed;
        mAnimator = GetComponent<Animator>();
        GameManager.UpdateGameState(GameState.PlayerTurn);
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0 || transform.position.y < -10)
        {
            mAnimator.SetTrigger("trVittoDie");
            GameManager.UpdateGameState(GameState.Lose);
        }

        if (GameManager.state == GameState.PlayerTurn)
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            if (horizontalMovement == 1 || verticalMovement == 1 ||
                horizontalMovement == -1 || verticalMovement == -1)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    speed = defaultSpeed * 2;
                    mAnimator.SetFloat("trVittoRun", 1);
                    mAnimator.SetFloat("trVittoWalk", 0);
                }
                else
                {
                    speed = defaultSpeed;
                    mAnimator.SetFloat("trVittoWalk", 1);
                    mAnimator.SetFloat("trVittoRun", 0);
                }

                transform.position += (transform.forward * verticalMovement + transform.right * horizontalMovement) * speed * Time.deltaTime;
            }
            else
            {
                mAnimator.SetFloat("trVittoWalk", 0);
                mAnimator.SetFloat("trVittoRun", 0);
            }


            Rotate(GetRotationInput());

            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                mAnimator.SetTrigger("TrVittoJump");
                Jump();
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                mAnimator.SetBool("trVittoShoot", true);
            }
            else
            {

                mAnimator.SetBool("trVittoShoot", false);
            }
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * forceGravity, ForceMode.Impulse);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
        }
    }*/

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }

    private void Rotate(Vector2 p_scrollDelta)
    {
        transform.Rotate(Vector3.up, p_scrollDelta.x * rotationSpeed * Time.deltaTime, Space.Self);
    }

    private Vector2 GetRotationInput()
    {
        var l_mouseX = Input.GetAxis("Mouse X");
        var l_mouseY = Input.GetAxis("Mouse Y");
        return new Vector2(l_mouseX, l_mouseY);
    }


}
