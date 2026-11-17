using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorCooldownButton : MonoBehaviour
{
    [Header("Компоненты UI")]
    [SerializeField] private Button targetButton;
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private Image cooldownRadialImage;

    [Header("Настройки")]
    [SerializeField] private float cooldownDuration = 3.0f;

    private bool isOnCooldown = false;

    private void Start()
    {
        if (cooldownRadialImage != null)
        {
            cooldownRadialImage.fillAmount = 0f;
        }
    }

    public void SetRedAndCooldown()
    {
        if (isOnCooldown) return;

        buttonText.color = Color.red;
        StartCoroutine(CooldownRoutine());
    }

    public void SetBlueAndCooldown()
    {
        if (isOnCooldown) return;

        buttonText.color = Color.blue;
        StartCoroutine(CooldownRoutine());
    }

    public void SetGreenAndCooldown()
    {
        if (isOnCooldown) return;

        buttonText.color = Color.green;
        StartCoroutine(CooldownRoutine());
    }

    private IEnumerator CooldownRoutine()
    {
        isOnCooldown = true;
        targetButton.interactable = false;

        float elapsed = 0f;

        if (cooldownRadialImage != null)
        {
            cooldownRadialImage.fillAmount = 1f;
        }

        while (elapsed < cooldownDuration)
        {
            elapsed += Time.deltaTime;

            if (cooldownRadialImage != null)
            {
                cooldownRadialImage.fillAmount = 1f - (elapsed / cooldownDuration);
            }

            yield return null;
        }

        if (cooldownRadialImage != null)
        {
            cooldownRadialImage.fillAmount = 0f;
        }

        targetButton.interactable = true;
        isOnCooldown = false;
    }
}
