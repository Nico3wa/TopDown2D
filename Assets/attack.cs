using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    [SerializeField] int _MyDamage;

    [SerializeField] List<Health> _savedCharacter;
    public Health _damagingchar;


    
    private void OnTriggerEnter2D(Collider2D col)
    {
        var h = col.attachedRigidbody.GetComponent<Health>();
        if (h != null)
        {
            if (_savedCharacter.Contains(h))
            {

            }
            else
            {
                _savedCharacter.Add(h);
            }
          
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        var h = col.attachedRigidbody.GetComponent<Health>();
        if (h != null)
        {
            if (_savedCharacter.Contains(h))
            {
                _savedCharacter.Remove(h);
            }
        }
    }

    public void LaunchAttack()
    {
        if (_savedCharacter != null)
        {
            _savedCharacter.Damage(_MyDamage);
        }
    }

}

