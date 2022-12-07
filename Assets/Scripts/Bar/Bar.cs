using System;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour {

    // Max Value and Min Value are self explanatory, They are both meant to be inclusive.

    public float MaxValue = 1;
    public float MinValue = 0;

    // Value Stores the Current value the slider is meant to hold. (It will be shown as a solid colour).
    public float Value = 0;
    // BufferValue holds a theoretical change to the Value. (It will be represented by a translucent version of the Value Colour)
    public float BufferValue = 0;

    GameObject NormalBar;
    GameObject SecondaryBar;
    GameObject Text;

    [Range(0, 1)]
    public float alpha = 0.75f;
    public Color color;



    // Start is called before the first frame update
    void Start() {
        NormalBar = transform.GetChild(0).gameObject;
        SecondaryBar = transform.GetChild(1).gameObject;
        Text = transform.GetChild(2).gameObject;

        NormalBar.GetComponent<Image>().color = color;
        SecondaryBar.GetComponent<Image>().color = new Color(color.r, color.g, color.b, alpha);

    }

    // Update is called once per frame
    void Update() {
        UpdateBar();
    }

    void UpdateBar() {
        float NormalBarPercent = (Value - BufferValue) / MaxValue;
        float SecondaryBarPercent = Value / MaxValue;

        RectTransform BarSize = GetComponent<RectTransform>();

        float sizeDeltaChangeNB = -1 * (BarSize.sizeDelta[0] - (BarSize.sizeDelta[0] * NormalBarPercent));
        float anchoredPositionChangeNB = sizeDeltaChangeNB / 2;

        NormalBar.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeDeltaChangeNB, BarSize.sizeDelta[1]);
        NormalBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(anchoredPositionChangeNB, BarSize.anchoredPosition[1]);

        float sizeDeltaChangeSB = -1 * (BarSize.sizeDelta[0] - (BarSize.sizeDelta[0] * SecondaryBarPercent));
        float anchoredPositionChangeSB = sizeDeltaChangeSB / 2;

        SecondaryBar.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeDeltaChangeSB, BarSize.sizeDelta[1]);
        SecondaryBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(anchoredPositionChangeSB, BarSize.anchoredPosition[1]);

        Text.GetComponent<Text>().text = $"{PercentValue(SecondaryBarPercent)}%" + ((BufferValue != 0) ? $" ({PercentValue(NormalBarPercent)}%)" : "");
    }

    float PercentValue(float num) {
        return Mathf.Round(num * 10000) / 100;
    }

    private void OnValidate() {
        if (MinValue >= MaxValue) MaxValue = MinValue + 1;
        if (Value < MinValue) Value = MinValue;
        if (Value > MaxValue) Value = MaxValue;

        Start();
        UpdateBar();
    }
}
