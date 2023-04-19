using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Space(10)]
    [SerializeField] Image onSoundImg;
    [SerializeField] Image offSoundImg;

    [Space(10)]
    [SerializeField] Image onVibraImg;
    [SerializeField] Image offVibraImg;

    [Space(10)]
    [SerializeField] Color active;
    [SerializeField] Color disable;
    [SerializeField] Color baseColor;

    public static bool VibraEnbled { get; set; }

    private void Start()
    {
        SetSoundsStatus(true);
        SetVibrationStatus(true);
    }

    public void SetSoundsStatus(bool IsEnable)
    {
        AudioListener.pause = !IsEnable;

        if(IsEnable)
        {
            onSoundImg.color = active;
            offSoundImg.color = baseColor;
        }
        else
        {
            offSoundImg.color = disable;
            onSoundImg.color = baseColor;
        }
    }

    public void SetVibrationStatus(bool IsEnable)
    {
        VibraEnbled = IsEnable;

        if (IsEnable)
        {
            onVibraImg.color = active;
            offVibraImg.color = baseColor;
        }
        else
        {
            offVibraImg.color = disable;
            onVibraImg.color = baseColor;
        }
    }
}
