using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Camera mainCamera;
    
    private Vector2 _movableTopRight;
    private Vector2 _movableBottomLeft;
    
    [Header("능력치")]
    public float speed = 5f;
    public float maxSpeed = 10f;
    public float minSpeed = 3f;
    public float speedChangeAmount = 5f;
    void Start()
    {
        if (mainCamera == null) mainCamera = Camera.main;

        if (mainCamera != null)
        {
            _movableTopRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0.5f, mainCamera.nearClipPlane));
            _movableBottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        }
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        Debug.Log($"h: {h}, v: {v}");

        Vector2 direction = new Vector2(h, v).normalized;
        float speedDelta = speed * Time.deltaTime;
        Debug.Log($"direction: ({direction.x}, {direction.y})");

        Vector2 position = transform.position;

        Vector2 newPosition = new Vector2(
            Mathf.Clamp(position.x + direction.x * speedDelta, _movableBottomLeft.x, _movableTopRight.x),
            Mathf.Clamp(position.y + direction.y * speedDelta, _movableBottomLeft.y, _movableTopRight.y)
        );

        if (newPosition.x <= _movableBottomLeft.x)
        {
            newPosition.x = _movableTopRight.x - 0.1f;
        } else if (newPosition.x >= _movableTopRight.x)
        {
            newPosition.x = _movableBottomLeft.x + 0.1f;
        }
        
        Debug.Log($"newPosition: ({newPosition.x}, {newPosition.y})");

        if (Input.GetKey(KeyCode.Q)) speed = Mathf.Min(speed + speedChangeAmount * Time.deltaTime, maxSpeed);
        else if (Input.GetKey(KeyCode.E)) speed = Mathf.Max(speed - speedChangeAmount * Time.deltaTime, minSpeed);
        
        transform.position = newPosition;
    }
}
