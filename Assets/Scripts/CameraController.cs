using UnityEngine;

public class CameraController : MonoBehaviour{

    //Cursor
    public CursorMode cursorMode = CursorMode.Auto;
    public Texture2D cursorNormal;
    public Texture2D cursorDown;

    private bool cameraControlsActive = true;

    public float panSpeed = 10f;
    public float panBorderThickness = 20f;
    public float scrollSpeed = 0.5f;
    public float minY = 3f;
    public float maxY = 10f;
    public float minZ = -10f;
    public float maxZ = 10f;
    public float minX = -10f;
    public float maxX = 10f;

    private void Start(){
        Cursor.SetCursor(cursorNormal, Vector2.zero, cursorMode);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown("x"))
        {
            cameraControlsActive = !cameraControlsActive;
        }

        if (!cameraControlsActive)
            return;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("mouse 2"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * panSpeed * (Input.mousePosition.x - Screen.width * 0.5f) / (Screen.width * 0.5f), Space.World);
            transform.Translate(Vector3.forward * Time.deltaTime * panSpeed * (Input.mousePosition.y - Screen.height * 0.5f) / (Screen.height * 0.5f), Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;

    }
}
