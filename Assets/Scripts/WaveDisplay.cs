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
		var alpha = wave.amplitute / 100f * 0.6f;
		image.color = new Color(1, 0, 0, alpha + 0.4f);
		//image.fillAmount = wave.xValue % 1f;
		var y = Mathf.Sin(2 * Mathf.PI * wave.xValue) * 30f;
		image.rectTransform.localPosition = new Vector3(0, y, 0);
		text.text = wave.lastValue.ToString("F2");
	}
}
