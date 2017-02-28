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


        if (Input.GetKeyDown("z"))
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

        Vector3 newPos = transform.position;

        newPos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);
        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.z = Mathf.Clamp(newPos.z, minZ, maxZ);

        if(scroll != 0){
            smoothScroll(newPos);
        }

    }

    private void smoothScroll(Vector3 newPos){
        Vector3 currentPos = transform.position;
        transform.position = Vector3.Lerp(currentPos, newPos, Time.deltaTime * 2);
    }
}
