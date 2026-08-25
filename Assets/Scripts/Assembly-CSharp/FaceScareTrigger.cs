using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200000A RID: 10
public class FaceScareTrigger : MonoBehaviour
{
	// Token: 0x06000019 RID: 25 RVA: 0x000028E8 File Offset: 0x00000AE8
	private void OnTriggerEnter(Collider other)
	{
		if (!this.Started && other.gameObject.tag == "Player")
		{
			this.Started = true;
			this.Anim.Play("turnaround");
			AudioSource.PlayClipAtPoint(this.Sound, base.transform.position);
			base.StartCoroutine(this.TimerAnim());
		}
	}

	// Token: 0x0600001A RID: 26 RVA: 0x0000294F File Offset: 0x00000B4F
	private IEnumerator TimerAnim()
	{
		yield return new WaitForSeconds(this.Anim["turnaround"].length);
		this.Face.SetActive(true);
		yield return new WaitForSeconds(0.2f);
		this.Face.SetActive(false);
		this.Slendrina.SetActive(false);
		UnityEngine.Object.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x0400003D RID: 61
	public bool Started;

	// Token: 0x0400003E RID: 62
	public GameObject Slendrina;

	// Token: 0x0400003F RID: 63
	public Animation Anim;

	// Token: 0x04000040 RID: 64
	public AudioClip Sound;

	// Token: 0x04000041 RID: 65
	public GameObject Face;
}
