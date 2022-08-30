    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PlayerController : MonoBehaviour
    {
    // Start is called before the first frame update
    private PlayerInputActions _PlayerInput;
        Vector2 _playerMovement;
       [SerializeField] Transform _root;
       [SerializeField] float _speed;
    private Rigidbody2D rb;

    private void Awake()
    {
        _PlayerInput = new PlayerInputActions();
       rb = GetComponent<Rigidbody2D>();
    }
    void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
 //       Vector2 direction = new Vector2(_playerMovement.x,0);
 

      //  if (direction.x > 0)     //right
       // {
       //     _root.rotation = Quaternion.Euler(0, 0, 0);
        // }
     //   else if (direction.x < 0)   //left
      //  {
      //      _root.rotation = Quaternion.Euler(0, 180, 0);
      //  }
    }
    private void OnEnable()
    {
        _PlayerInput.Enable();
    }
    private void OnDisable()
    {
        _PlayerInput.Disable();
    }

     void FixedUpdate()
    {
        Vector2 moveInput = _PlayerInput.Movement.Move.ReadValue<Vector2>();
        rb.velocity = moveInput * _speed;
    }
}
