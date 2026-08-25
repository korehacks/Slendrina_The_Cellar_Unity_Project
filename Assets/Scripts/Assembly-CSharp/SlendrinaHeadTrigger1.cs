using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200001A RID: 26
public class SlendrinaHeadTrigger1 : MonoBehaviour
{
	// Token: 0x06000055 RID: 85 RVA: 0x000038B0 File Offset: 0x00001AB0
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && !this.Started)
		{
			AudioSource.PlayClipAtPoint(this.Sound, base.transform.position);
			this.Started = true;
			this.Head.GetComponent<Animation>().Play("SlendrinaFlyWall");
			base.StartCoroutine(this.TimerDisappear());
		}
	}

	// Token: 0x06000056 RID: 86 RVA: 0x0000391C File Offset: 0x00001B1C
	private IEnumerator TimerDisappear()
	{
		yield return new WaitForSeconds(this.Head.GetComponent<Animation>()["SlendrinaFlyWall"].length);
		this.Head.SetActive(false);
		yield break;
	}

	// Token: 0x04000094 RID: 148
	public GameObject Head;

	// Token: 0x04000095 RID: 149
	public bool Started;

	// Token: 0x04000096 RID: 150
	public AudioClip Sound;
}
