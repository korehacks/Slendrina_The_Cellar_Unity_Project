using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x02000008 RID: 8
public class CutsceneEscape : MonoBehaviour
{
	// Token: 0x06000012 RID: 18 RVA: 0x00002790 File Offset: 0x00000990
	private void Start()
	{
		this.BlackS.CrossFadeAlpha(0f, 0.5f, false);
	}

	// Token: 0x06000013 RID: 19 RVA: 0x000027A8 File Offset: 0x000009A8
	private void Update()
	{
		this.Escaped.color = new Color(1f, 1f, 1f, this.EscapedTValue);
		if (this.CanFadeEscaped)
		{
			if (this.EscapedTValue < 1f)
			{
				this.EscapedTValue += Time.deltaTime;
				return;
			}
		}
		else if (this.EscapedTValue > 0f)
		{
			this.EscapedTValue -= 0.5f * Time.deltaTime;
		}
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00002828 File Offset: 0x00000A28
	public void Escape()
	{
		this.Dot.SetActive(false);
		this.Ring.SetActive(false);
		this.KeyA.SetActive(false);
		this.PageA.SetActive(false);
		this.Slendrina.SetActive(false);
		this.SoundEffs.SetActive(false);
		this.TextGenStop.SetActive(false);
		base.GetComponent<Paused>().enabled = false;
		base.StartCoroutine(this.EscapeScenario());
	}

	// Token: 0x06000015 RID: 21 RVA: 0x000028A2 File Offset: 0x00000AA2
	private IEnumerator EscapeScenario()
	{
		yield return new WaitForSeconds(1.5f);
		this.Blood.SetActive(false);
		this.PL.SetActive(false);
		this.NewCam.SetActive(true);
		yield return new WaitForSeconds(5.5f);
		this.BlackS.CrossFadeAlpha(1f, 0.5f, false);
		yield return new WaitForSeconds(1f);
		this.CanFadeEscaped = true;
		yield return new WaitForSeconds(6f);
		this.CanFadeEscaped = false;
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene("Menu");
		yield break;
	}

	// Token: 0x0400002E RID: 46
	public GameObject Dot;

	// Token: 0x0400002F RID: 47
	public GameObject KeyA;

	// Token: 0x04000030 RID: 48
	public GameObject PageA;

	// Token: 0x04000031 RID: 49
	public GameObject PL;

	// Token: 0x04000032 RID: 50
	public GameObject Slendrina;

	// Token: 0x04000033 RID: 51
	public GameObject NewCam;

	// Token: 0x04000034 RID: 52
	public GameObject Ring;

	// Token: 0x04000035 RID: 53
	public GameObject TextGenStop;

	// Token: 0x04000036 RID: 54
	public Image BlackS;

	// Token: 0x04000037 RID: 55
	public GameObject SoundEffs;

	// Token: 0x04000038 RID: 56
	public Image Escaped;

	// Token: 0x04000039 RID: 57
	public bool CanFadeEscaped;

	// Token: 0x0400003A RID: 58
	public float EscapedTValue;

	// Token: 0x0400003B RID: 59
	public GameObject Blood;
}
