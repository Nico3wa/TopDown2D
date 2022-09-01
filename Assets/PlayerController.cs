using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    // Vector2 _playerMovement;

    [SerializeField] InputActionReference _MoveInput;
    [SerializeField] InputActionReference _AttackInput;

    [SerializeField] Transform _root;
    [SerializeField] float _speed;
    private Rigidbody2D rb;
    [SerializeField] Animator _animator;
    [SerializeField] float _MovingThreshold;
    [SerializeField] attack _attack;
    private PlayerInputActions _PlayerAttack;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        _AttackInput.action.started += AttackStart;
        _AttackInput.action.performed += UpdateAttack;
        _AttackInput.action.canceled += EndAttack;
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = _MoveInput.action.ReadValue<Vector2>();
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

    void FixedUpdate()
    {
        Vector2 moveInput = _MoveInput.action.ReadValue<Vector2>();
        rb.velocity = moveInput * _speed;
    }

    private void AttackStart(InputAction.CallbackContext obj)
    {
        _animator.SetTrigger("SwordAttack");

    }
    private void UpdateAttack(InputAction.CallbackContext obj)
    {
    }
    private void EndAttack(InputAction.CallbackContext obj)
    {
    }


    public void LaunchAttack()
    {
        _attack.LaunchAttack();
    }


}
