using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlimeHealth : MonoBehaviour
{     
    [SerializeField] int _hp;
    [SerializeField] UnityEvent _onDamage;


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
        _onDamage.Invoke();

        if (currenthp <= 0)
        {
            Debug.Log(currenthp);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        
    }

}
