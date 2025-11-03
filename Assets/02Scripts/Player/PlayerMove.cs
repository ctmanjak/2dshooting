using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Camera mainCamera;
    private Vector2 _movableTopLeft;
    private Vector2 _movableBottomRight;
    
    public float speed = 5f;
    public float maxSpeed = 10f;
    public float minSpeed = 3f;
    public float speedChangeAmount = 5f;
    void Start()
    {
        if (mainCamera == null) mainCamera = Camera.main;

        if (mainCamera != null)
        {
            _movableTopLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0.5f, mainCamera.nearClipPlane));
            _movableBottomRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, mainCamera.nearClipPlane));
        }
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Debug.Log($"h: {h}, v: {v}");

        Vector2 direction = new Vector2(h, v) * (speed * Time.deltaTime);
        Debug.Log($"direction: ({direction.x}, {direction.y})");

        Vector2 position = transform.position;

        Vector2 newPosition = new Vector2(
            Mathf.Clamp(position.x + direction.x, _movableTopLeft.x, _movableBottomRight.x),
            Mathf.Clamp(position.y + direction.y, _movableBottomRight.y, _movableTopLeft.y)
        );
        
        Debug.Log($"newPosition: ({newPosition.x}, {newPosition.y})");

        if (Input.GetKey(KeyCode.Q)) speed = Mathf.Min(speed + speedChangeAmount * Time.deltaTime, maxSpeed);
        else if (Input.GetKey(KeyCode.E)) speed = Mathf.Max(speed - speedChangeAmount * Time.deltaTime, minSpeed);
        
        transform.position = newPosition;
    }
}
