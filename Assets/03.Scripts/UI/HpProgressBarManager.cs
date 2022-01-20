using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpProgressBarManager : MonoBehaviour, IHpBar
{
    public Image _hpBar;

    // Start is called before the first frame update
    void Start()
    {
        _hpBar.fillAmount = 1;
    }
    
    public void HpProgressFunc(float _amount)
    {
        _hpBar.fillAmount = _amount;
    }
}
