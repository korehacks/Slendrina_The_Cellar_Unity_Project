using System;
using UnityEngine;

// Token: 0x02000017 RID: 23
public class ScareWardrobe : MonoBehaviour
{
	// Token: 0x0600004D RID: 77 RVA: 0x00002696 File Offset: 0x00000896
	private void Start()
	{
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00003806 File Offset: 0x00001A06
	private void Update()
	{
		if (this.W.isPlaying && !this.Started)
		{
			this.Started = true;
			this.Head.SetActive(true);
		}
	}

	// Token: 0x0400008E RID: 142
	public bool Started;

	// Token: 0x0400008F RID: 143
	public GameObject Head;

	// Token: 0x04000090 RID: 144
	public Animation W;
}
