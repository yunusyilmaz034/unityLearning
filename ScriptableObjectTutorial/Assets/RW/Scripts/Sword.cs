using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField]
    private GameEvent OnSwordSelected;

    private void OnMouseDown()
    {
        OnSwordSelected.Raise();
    }
}
