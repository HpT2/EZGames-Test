using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField] private Toggle maleToggle;
    [SerializeField] private Toggle femaleToggle;
    [SerializeField] private Button closeBtn;
    [SerializeField] private Slider soundSlider;
    [SerializeField] private Image soundSliderFill;
    [SerializeField] private GameObject mute;
    [SerializeField] private GameObject notMute;
    // Start is called before the first frame update
    void Start()
    {
        soundSlider.value = AudioListener.volume;
        if (GameManager.instance.data.gender) maleToggle.isOn = true;
        else femaleToggle.isOn = true;

        closeBtn.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        maleToggle.onValueChanged.AddListener(delegate
        {
            ChangeGender();
        });

        soundSlider.onValueChanged.AddListener((value) =>
        {
            AudioListener.volume = value;
            if(value == 0)
            {
                mute.SetActive(true);
                notMute.SetActive(false);
                mute.GetComponent<Button>().interactable = false;
            }
            else
            {
                mute.SetActive(false);
                notMute.SetActive(true);
                mute.GetComponent<Button>().interactable = true;
            }
        });

        mute.GetComponent<Button>().onClick.AddListener(() =>
        {
            mute.SetActive(false);
            notMute.SetActive(true);
            soundSlider.interactable = true;
            soundSliderFill.color = Color.red;
            AudioListener.volume = soundSlider.value;
        });

        notMute.GetComponent<Button>().onClick.AddListener(() =>
        {
            notMute.SetActive(false);
            mute.SetActive(true);
            soundSlider.interactable = false;
            soundSliderFill.color = Color.gray;
            AudioListener.volume = 0;
        });
    }

    void ChangeGender()
    {
        GameManager.instance.ChangeGender(maleToggle.isOn);
    }

}
