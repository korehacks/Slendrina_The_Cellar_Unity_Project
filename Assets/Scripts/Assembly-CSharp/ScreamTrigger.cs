using System;
using UnityEngine;

// Token: 0x02000018 RID: 24
public class ScreamTrigger : MonoBehaviour
{
	// Token: 0x06000050 RID: 80 RVA: 0x00003830 File Offset: 0x00001A30
	private void OnTriggerEnter(Collider other)
	{
		AudioSource.PlayClipAtPoint(this.Scream, base.transform.position);
		UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x04000091 RID: 145
	public AudioClip Scream;
}
