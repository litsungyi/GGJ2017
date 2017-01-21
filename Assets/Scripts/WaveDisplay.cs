using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveDisplay : MonoBehaviour
{
	[SerializeField] private Image image;
	[SerializeField] private Text text;

	public void UpdateWave(WaveCalculator wave)
	{
		var alpha = wave.amplitute / 100f * 0.8f;
		image.color = new Color(1, 0, 0, alpha + 0.2f);
		image.fillAmount = wave.xValue % 1f;
		text.text = wave.lastValue.ToString("F2");
	}
}
