using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordMerchant : MonoBehaviour
{
    [SerializeField]
    private Text swordName;
    [SerializeField]
    private Text description;
    [SerializeField]
    private Image icon;
    [SerializeField]
    private Text goldCost;
    [SerializeField]
    private Text attackDamage;

    public void updateDisplayUI(SwordData data)
    {
        swordName.text = data.SwordName;
        description.text = data.Description;
        icon.sprite = data.Icon;
        goldCost.text = data.GoldCost.ToString();
        attackDamage.text = data.AttackDamage.ToString();
    }
}
