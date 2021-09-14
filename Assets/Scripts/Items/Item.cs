using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public void DisableYourself()
    {
        gameObject.SetActive(false);
    }
}
