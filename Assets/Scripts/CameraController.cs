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

    private void FixedUpdate()
    {
        float v = Input.GetAxis("Mouse Y") * -1;

        if (v != 0)
        {
            transform.RotateAround(transform.position, transform.right, v * 90 * sesitivity * Time.deltaTime);
        }


    }
}
