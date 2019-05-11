using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField]
    private SwordData swordData;

    private void OnMouseDown()
    {
        Debug.Log(swordData.SwordName);
        Debug.Log(swordData.Description);
        Debug.Log(swordData.Icon.name);
        Debug.Log(swordData.GoldCost);
        Debug.Log(swordData.AttackDamage);
    }
}
