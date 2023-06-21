using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour
{
    public float cooldownDuration = 3f;
    public Slider cooldownSlider;
    private bool isButtonCooldown = false;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        cooldownSlider.maxValue = cooldownDuration;
        button.onClick.AddListener(OnButtonPressed);
        cooldownSlider.gameObject.SetActive(false);
    }

    private void OnButtonPressed()
    {
        if (!isButtonCooldown)
        {
            button.interactable = false;
            cooldownSlider.value = cooldownDuration;
            cooldownSlider.gameObject.SetActive(true);
            StartCoroutine(ButtonCooldownCoroutine());
        }
    }

    private IEnumerator ButtonCooldownCoroutine()
    {
        isButtonCooldown = true;
        float timer = cooldownDuration;

        while (timer > 0f)
        {
            cooldownSlider.value = timer;
            yield return new WaitForSeconds(0.1f);
            timer -= 0.1f;
        }

        cooldownSlider.value = 0f;
        isButtonCooldown = false;
        button.interactable = true;
        cooldownSlider.gameObject.SetActive(false);
    }
}
