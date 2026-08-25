using System;
using UnityEngine;

// Token: 0x02000016 RID: 22
public class RNG_Items : MonoBehaviour
{
	// Token: 0x0600004B RID: 75 RVA: 0x000037DC File Offset: 0x000019DC
	private void Start()
	{
		int num = UnityEngine.Random.Range(0, this.List.Length);
		this.List[num].SetActive(true);
	}

	// Token: 0x0400008D RID: 141
	public GameObject[] List;
}
