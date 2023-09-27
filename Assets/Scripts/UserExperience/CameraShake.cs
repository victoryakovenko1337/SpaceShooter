using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float _shakeDuration;
    [SerializeField] float _shakeMagnitude;

    private Vector3 _initialPosition;

    private void Start()
    {
        _initialPosition = transform.position;
        Player player = FindObjectOfType<Player>();

        player.OnDamageTakenEvent.AddListener(Play);
    }

    private void Play()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float elapsedTime = 0;
        while (elapsedTime < _shakeDuration)
        {
            transform.position = _initialPosition + (Vector3)Random.insideUnitCircle * _shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }   
        transform.position = _initialPosition;
    }
}
