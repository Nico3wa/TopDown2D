using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    [SerializeField] int _MyDamage;

    SlimeHealth _savedCharacter;

    private void OnTriggerEnter2D(Collider2D col)
    {
        var h = col.attachedRigidbody.GetComponent<SlimeHealth>();
        if (h != null)
        {
            _savedCharacter = h;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        var h = col.attachedRigidbody.GetComponent<SlimeHealth>();
        if (h == _savedCharacter)
        {
            _savedCharacter = null;
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

