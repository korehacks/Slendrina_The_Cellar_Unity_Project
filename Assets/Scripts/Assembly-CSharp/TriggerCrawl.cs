using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200001B RID: 27
public class TriggerCrawl : MonoBehaviour
{
	// Token: 0x06000058 RID: 88 RVA: 0x0000392C File Offset: 0x00001B2C
	private void OnTriggerEnter(Collider other)
	{
		if (!this.Started && other.gameObject.tag == "Player")
		{
			this.Started = true;
			this.Anim.gameObject.SetActive(true);
			base.StartCoroutine(this.TimerAnim());
		}
	}

	// Token: 0x06000059 RID: 89 RVA: 0x0000397D File Offset: 0x00001B7D
	private IEnumerator TimerAnim()
	{
		yield return new WaitForSeconds(this.Anim[this.Clip.name].length);
		UnityEngine.Object.Destroy(this.Anim.gameObject);
		yield break;
	}

	// Token: 0x04000097 RID: 151
	public bool Started;

	// Token: 0x04000098 RID: 152
	public Animation Anim;

	// Token: 0x04000099 RID: 153
	public AnimationClip Clip;
}
