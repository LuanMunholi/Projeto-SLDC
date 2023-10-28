using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luan_PressurePlate : MonoBehaviour
{

    public float lowerAmount = 1f;
    public float transitionDuration = 1f;

    private bool isLowering = false;
    private Vector3 targetPosition;

    [SerializeField] public GameObject objectToDeactivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isLowering)
        {
            isLowering = true;
            targetPosition = transform.position - new Vector3(0f, lowerAmount, 0f);
            Invoke("deactivateObject", 1f);
            StartCoroutine(SmoothLower());
        }
    }

    private void deactivateObject()
    {
        objectToDeactivate.SetActive(false);
    }

    private IEnumerator SmoothLower()
    {
        Vector3 initialPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isLowering = false;
    }


}
