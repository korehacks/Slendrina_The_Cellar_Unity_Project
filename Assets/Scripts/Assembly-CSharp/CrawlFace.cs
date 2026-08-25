using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000006 RID: 6
public class CrawlFace : MonoBehaviour
{
	// Token: 0x0600000D RID: 13 RVA: 0x000026D8 File Offset: 0x000008D8
	public void StartHunt()
	{
		this.HF.Attacked = true;
		AudioSource.PlayClipAtPoint(this.Scare, base.transform.position);
		this.FPS.CameraAnim.CrossFade("idle");
		this.FPS.enabled = false;
		base.StartCoroutine(this.Attack());
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00002735 File Offset: 0x00000935
	private IEnumerator Attack()
	{
		yield return new WaitForSeconds(3.9f);
		this.B.CrossFadeAlpha(1f, 0.1f, false);
		yield return new WaitForSeconds(0.5f);
		this.B.CrossFadeAlpha(0f, 0.1f, false);
		this.HF.Attacked = false;
		this.FPS.enabled = true;
		base.gameObject.SetActive(false);
		yield break;
	}

	// Token: 0x04000029 RID: 41
	public Image B;

	// Token: 0x0400002A RID: 42
	public AudioClip Scare;

	// Token: 0x0400002B RID: 43
	public HitFly HF;

	// Token: 0x0400002C RID: 44
	public FPSControl FPS;
}
