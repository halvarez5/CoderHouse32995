using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    public int totalHealth = 3;
    public int health = 3;
    public Rigidbody rb;
    [SerializeField] private Camera m_camera;
    [SerializeField] private int forceGravity = 5;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Animator mAnimator;
    public GameObject[] Corazones;
    [SerializeField] private AudioSource audioSrc;
    [SerializeField] private AudioClip sfx_Fire;
    [SerializeField] private Volume volume;
    [SerializeField] private Image portalImage;
    [SerializeField] private GameObject Bear;
    [SerializeField] private GameObject WardRobePortal;
    [SerializeField] private CameraController CM;

    public UnityEvent OnPlayerAppear;
    public UnityEvent OnPlayerDamaged;
    public UnityEvent OnPlayerDie;
    public UnityEvent OnPortalEnter;

    private bool canJump = true;
    private float defaultSpeed;

    // Start is called before the first frame update
    void Start()
    {
        OnPlayerAppear?.Invoke();
        var l_profile = volume.profile;
        defaultSpeed = speed;
        mAnimator = GetComponent<Animator>();
        GameManager.UpdateGameState(GameState.PlayerTurn);

        OnPlayerDamaged.AddListener(DamageImpulse);
        OnPlayerDie.AddListener(EnableGrayScaleScreen);
        audioSrc.clip = sfx_Fire;

        DisableGrayScaleScreen();


        switch (GameManager.level)
        {
            case 1:
                transform.position = new Vector3(80f, 3.51f, 3.7f);
                Bear.SetActive(true);
                WardRobePortal.SetActive(false);
                break;
            case 2:
                transform.position = new Vector3(60f, 3.6f, 203f);
                Bear.SetActive(true);
                WardRobePortal.SetActive(false);
                break;
            case 3:
                transform.position = new Vector3(60f, 3.6f, 203f);
                Bear.SetActive(true);
                WardRobePortal.SetActive(false);
                break;
            default:
                transform.position = new Vector3(81.8f, 0.01f, -0.3f);
                Bear.SetActive(false);
                WardRobePortal.SetActive(true);
                break;
        }
    }


    void Update()
    {
        if ((health <= 0 || transform.position.y < -10) && GameManager.state != GameState.Lose && GameManager.state != GameState.GameOver)
        {
            Debug.Log("Llamado a evento OnPlayerDie");
            OnPlayerDie?.Invoke();
            OnPlayerDie.RemoveListener(EnableGrayScaleScreen);

            mAnimator.SetTrigger("trVittoDie");
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

                if(!audioSrc.isPlaying) audioSrc.Play();
            }
            else
            {
                mAnimator.SetBool("trVittoShoot", false);

                if (audioSrc.isPlaying) audioSrc.Stop();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (GameManager.state == GameState.Lose)
            {
                GameManager.RestartGame();
                PortalEnter();
            }

            if (GameManager.state == GameState.GameOver || GameManager.state == GameState.Victory)
            {
                GameManager.lives = 3;
                GameManager.level = 0;
                GameManager.RestartGame();
                PortalEnter();
            }
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * forceGravity, ForceMode.Impulse);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WardRobePortal"))
        {
            //transform.position = new Vector3(-6f, 0.1f, 0f);
            GameManager.level = 1;
            PortalEnter();
            transform.position += new Vector3(0f, 6f, 0f);
            OnPortalEnter?.Invoke();
            collision.gameObject.SetActive(false);
            Bear.SetActive(true);
        }
        if (collision.gameObject.CompareTag("PortalLevel2"))
        {
            GameManager.level = 2;
            PortalEnter();
            transform.position = new Vector3(60f, 3.6f, 203f);
            Invoke("enfoqueBoss", 1f);
        }
        if (collision.gameObject.CompareTag("FinalPortal"))
        {
            GameManager.UpdateGameState(GameState.Victory);
            PortalEnter();
            transform.position = new Vector3(81.8f, 0.01f, -0.3f);
            CM.ChangeCamera(CM.roomCamera, CM.vittoCamera, CM.bossCamera);
        }
    }

    private void enfoqueBoss()
    {
        CM.ChangeCamera(CM.bossCamera, CM.roomCamera, CM.vittoCamera);
        Invoke("enfoqueVitto", 3f);
    }
    private void enfoqueVitto()
    {
        CM.ChangeCamera(CM.vittoCamera, CM.roomCamera, CM.bossCamera);
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

    public void RemoveHealth(int quantity)
    {
        if (GameManager.state == GameState.PlayerTurn)
        {
            bool isZero = health - quantity < 0;
            health = isZero ? 0 : health - quantity;

            for (int i = totalHealth - 1; i > health - 1; i--)
            {
                Corazones[i].SetActive(false);
            }

            Debug.Log("Llamado a evento OnPlayerDamaged");
            OnPlayerDamaged?.Invoke();
        }
    }

    public void AddHealth(int quantity)
    {
        bool fill = health + quantity > totalHealth;
        health = fill ? totalHealth : health + quantity;

        for (int i = 0; i > health; i++)
        {
            Corazones[i].SetActive(false);
        }
    }

    private void DamageImpulse()
    {
        rb.AddForce(Vector3.back * 5, ForceMode.Impulse);
    }

    private void EnableGrayScaleScreen()
    {
        if (volume.profile.TryGet(out ColorAdjustments p_colorAdjustements))
        {
            p_colorAdjustements.saturation.value = -100;
        }
    }

    private void DisableGrayScaleScreen()
    {
        if (volume.profile.TryGet(out ColorAdjustments p_colorAdjustements))
        {
            p_colorAdjustements.saturation.value = 20;
        }
    }

    private void PortalEnter()
    {
        portalImage.gameObject.SetActive(true);
        Invoke("PortalOut", 0.7f);
    }

    private void PortalOut()
    {
        portalImage.gameObject.SetActive(false);
    }

}
