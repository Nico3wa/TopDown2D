using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlimeHealth : MonoBehaviour
{     
    [SerializeField] int _hp;
    [SerializeField] UnityEvent _onDamage;
    [SerializeField] Animator _animator;


    // Start is called before the first frame update

    int currenthp;

    private void Start()
    {
        currenthp = _hp;
    }

    public void Damage(int amount)
    {
        currenthp = currenthp - amount;
        Debug.Log(currenthp);
        _animator.SetTrigger("Hit");


        if (currenthp <= 0)
        {
            Debug.Log(currenthp);
            _animator.SetTrigger("Death");
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        
    }

}
