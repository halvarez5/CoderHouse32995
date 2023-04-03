using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region
    /*[SerializeField] private CinemachineVirtualCamera cam1;
    [SerializeField] private CinemachineVirtualCamera cam2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
            ChangeCamera(cam2, cam1);
        else
            ChangeCamera(cam1, cam2);

    }

    private void ChangeCamera(CinemachineVirtualCamera c1, CinemachineVirtualCamera c2)
    {
        c1.gameObject.SetActive(true);
        c2.gameObject.SetActive(false);
    }*/
    #endregion

    [SerializeField] private float sesitivity = 2;
    public CinemachineVirtualCamera vittoCamera;
    public CinemachineVirtualCamera bossCamera;
    public CinemachineVirtualCamera roomCamera;

    private Quaternion camRotation;

    private void Start()
    {
        camRotation = transform.localRotation;
    }

    private void FixedUpdate()
    {
        camRotation.x += Input.GetAxis("Mouse Y") * -1 * sesitivity;
        camRotation.x = Mathf.Clamp(camRotation.x, -20, 10);

        transform.localRotation = Quaternion.Euler(camRotation.x, 0, 0);
    }

    public void ChangeCamera(CinemachineVirtualCamera c1, CinemachineVirtualCamera c2, CinemachineVirtualCamera c3)
    {
        c1.gameObject.SetActive(true);
        c2.gameObject.SetActive(false);
        c3.gameObject.SetActive(false);
    }
}
