using System;
using System.Collections;
using TMPro;
using UnityEngine;

// Token: 0x02000020 RID: 32
public class EnvMapAnimator : MonoBehaviour
{
	// Token: 0x06000066 RID: 102 RVA: 0x00003C02 File Offset: 0x00001E02
	private void Awake()
	{
		this.m_textMeshPro = base.GetComponent<TMP_Text>();
		this.m_material = this.m_textMeshPro.fontSharedMaterial;
	}

	// Token: 0x06000067 RID: 103 RVA: 0x00003C21 File Offset: 0x00001E21
	private IEnumerator Start()
	{
		Matrix4x4 matrix = default(Matrix4x4);
		for (;;)
		{
			matrix.SetTRS(Vector3.zero, Quaternion.Euler(Time.time * this.RotationSpeeds.x, Time.time * this.RotationSpeeds.y, Time.time * this.RotationSpeeds.z), Vector3.one);
			this.m_material.SetMatrix("_EnvMatrix", matrix);
			yield return null;
		}
		yield break;
	}

	// Token: 0x040000A6 RID: 166
	public Vector3 RotationSpeeds;

	// Token: 0x040000A7 RID: 167
	private TMP_Text m_textMeshPro;

	// Token: 0x040000A8 RID: 168
	private Material m_material;
}
