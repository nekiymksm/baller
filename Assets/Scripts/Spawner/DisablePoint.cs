using UnityEngine;

public class DisablePoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Item item))
            item.DisableYourself();
    }
}
