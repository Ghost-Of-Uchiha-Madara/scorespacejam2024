using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackColliderCondition : MonoBehaviour
{
    public GameObject lightAttack;
    public GameObject heavyAttack;

    public void EnableHeavyAttackCollider()
    {
        print("Hit enable heavy");

        heavyAttack.SetActive(true);
    }
    public void DisableHeavyAttackCollider()
    {
        print("Hit Disable heavy");
        heavyAttack.SetActive(false);
    }

    public void EnableLightAttackCollider()
    {
        lightAttack.SetActive(true);
    }
    public void DisableLightAttackCollider()
    {
        lightAttack.SetActive(false);
    }
}
