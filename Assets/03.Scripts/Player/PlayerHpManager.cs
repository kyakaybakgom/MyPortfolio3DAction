using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpManager : MonoBehaviour, ITakeDamage
{
    public HpProgressBarManager hpProgressBarManager;

    [SerializeField]
    private float defaultHP;
    private float currentHp = 0.0f;
    public float CurrentHP { get { return currentHp; } set { currentHp = value; } }

    private float currentProgressValue = 0;


    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = defaultHP;
        currentProgressValue = 1;

        hpProgressBarManager.HpProgressFunc(currentProgressValue);
    }
    
    //damage
    public void TakeDamage()
    {
        
    }

    public void TakeDamage(float _damage)
    {
        CurrentHP -= _damage;

        currentProgressValue = (float)CurrentHP / defaultHP;

        hpProgressBarManager.HpProgressFunc(currentProgressValue);
    }

    public void TakeDamage(float _damage, string _type)
    {
        //스킬 타입에 따른 데미지 감소 및 디버프 효과
        CurrentHP -= _damage;

        //디버프에 따른 상태이상 효과
        switch (_type)
        {
            default:
                break;
        }
    }
}
