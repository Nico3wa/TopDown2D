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
      [SerializeField] Animator _animator;
       [SerializeField] float _MovingThreshold;
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
        Vector2 moveInput = _PlayerInput.Movement.Move.ReadValue<Vector2>();
        if (moveInput.x > 0)
        {
            _root.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveInput.x < 0)   //left
        {
            _root.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (moveInput.magnitude > _MovingThreshold)  // si on est ent train de bouger alors 
        {
            _animator.SetBool("Iswalking", true);
        }
        else
        {                 //sinon c'est qu'on bouge pas donc false
            _animator.SetBool("Iswalking", false);

        }

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
