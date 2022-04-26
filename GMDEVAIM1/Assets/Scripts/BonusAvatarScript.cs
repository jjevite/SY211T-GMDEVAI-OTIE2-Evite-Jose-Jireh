using UnityEngine;

public class BonusAvatarScript : MonoBehaviour
{
    float rotX;
    float mouseSens = 180.0f;
    public GameObject player;
    public float ms;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSens;
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSens;

        rotX -= mouseY;
        rotX = Mathf.Clamp(rotX, -90.0f, 90.0f);
        transform.localEulerAngles = new Vector3(rotX, 0f, 0f);

        player.transform.Rotate(Vector3.up * mouseX);

        if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(Vector3.forward * ms * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(-Vector3.forward * ms * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(Vector3.left * ms * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(Vector3.right * ms * Time.deltaTime);
        }

    }

}
