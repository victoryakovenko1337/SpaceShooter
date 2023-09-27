using UnityEngine;

public class SpriteRotation : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 90f;

    private void Update()
    {
        gameObject.transform.Rotate(Vector3.forward, _rotateSpeed * Time.deltaTime);
    }
}
