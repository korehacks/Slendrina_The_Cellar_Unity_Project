using System;
using UnityEngine;

// Token: 0x0200000B RID: 11
public class Footsteps : MonoBehaviour
{
	// Token: 0x0600001C RID: 28 RVA: 0x00002960 File Offset: 0x00000B60
	public void PlayAStep()
	{
		int num = UnityEngine.Random.Range(0, this.Steps.Length);
		this.FeetSource.PlayOneShot(this.Steps[num]);
	}

	// Token: 0x04000042 RID: 66
	public AudioSource FeetSource;

	// Token: 0x04000043 RID: 67
	public AudioClip[] Steps;
}
