using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    [SerializeField] int _MyDamage;

    [SerializeField] List<Health> _savedCharacter;



    
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
            //_savedCharacter.Damage(_MyDamage);

            //for (int i = 0; i < _savedCharacter.Count; i++)
            //{
            //    _savedCharacter[i].Damage(_MyDamage);
            //}

            foreach(Health el in _savedCharacter)
            {
                el.Damage(_MyDamage);
            }
        }
    }

}

