using System;
using UnityEngine;

// Token: 0x02000005 RID: 5
public class CheckPlayerPresence1 : MonoBehaviour
{
	// Token: 0x0600000A RID: 10 RVA: 0x00002696 File Offset: 0x00000896
	private void Start()
	{
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00002698 File Offset: 0x00000898
	private void Update()
	{
		if (Vector3.Distance(base.transform.position, this.PL.position) <= this.DistanceRange)
		{
			this.Slendrina.IntherePL = true;
			return;
		}
		this.Slendrina.IntherePL = false;
	}

	// Token: 0x04000026 RID: 38
	public AI_Slendrina Slendrina;

	// Token: 0x04000027 RID: 39
	public float DistanceRange;

	// Token: 0x04000028 RID: 40
	public Transform PL;
}
