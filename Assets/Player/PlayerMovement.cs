using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float border;
    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Camera cam;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerControls();
        cam = Camera.main;
    }

    private void Start()
    {

    }

    public class Player
    {

    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
        PlayerScreenCheck();
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void PlayerScreenCheck()
    {
        Vector2 screenPos = cam.WorldToScreenPoint(transform.position);

        if ((screenPos.x < border && movement.x < 0) || (screenPos.x > cam.pixelWidth - border && movement.x > 0))
        {
            movement = new Vector2(0, movement.y);
        }
        if ((screenPos.y < border && movement.y < 0) || (screenPos.y > cam.pixelHeight - border && movement.y > 0))
        {
            movement = new Vector2(movement.x, 0);
        }
    }
}
