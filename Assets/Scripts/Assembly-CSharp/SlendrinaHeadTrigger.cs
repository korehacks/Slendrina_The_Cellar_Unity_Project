using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000019 RID: 25
public class SlendrinaHeadTrigger : MonoBehaviour
{
	// Token: 0x06000052 RID: 82 RVA: 0x00003854 File Offset: 0x00001A54
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && !this.Started)
		{
			this.Started = true;
			this.Head.SetActive(true);
			base.StartCoroutine(this.TimerDisappear());
		}
	}

	// Token: 0x06000053 RID: 83 RVA: 0x000038A0 File Offset: 0x00001AA0
	private IEnumerator TimerDisappear()
	{
		yield return new WaitForSeconds(this.Head.GetComponent<Animation>()["SlendrinaHeadAnim2"].length);
		this.Head.SetActive(false);
		yield break;
	}

	// Token: 0x04000092 RID: 146
	public GameObject Head;

	// Token: 0x04000093 RID: 147
	public bool Started;
}
