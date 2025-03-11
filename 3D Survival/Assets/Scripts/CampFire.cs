using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{

    public int damage;
    public float damageRate;

    List<IDamagable> things = new List<IDamagable>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DealDamage", 0,damageRate);
    }

    void DealDamage()
    {
        for(int i = 0; i < things.Count; i++)
        {
            things[i].TakePhysicalDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IDamagable damageable))
        {
            things.Add(damageable); //조회해서 실제로 데미지를 주는것은 DealDamage에서 구현.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IDamagable damagable)){
            things.Remove(damagable);
        }
    }
}
