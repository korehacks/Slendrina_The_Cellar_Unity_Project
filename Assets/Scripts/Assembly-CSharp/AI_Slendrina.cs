using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

// Token: 0x02000002 RID: 2
public class AI_Slendrina : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	private void Start()
	{
		this.StartPosV = base.transform.position;
		this.PathingToPlayer = true;
		base.transform.position = this.StartPos2.position;
		this.Agent.enabled = true;
		int @int = PlayerPrefs.GetInt("Difficulty");
		if ((float)@int == 0f)
		{
			this.HealthDamage = 0.2f;
			return;
		}
		if ((float)@int == 1f)
		{
			this.HealthDamage = 0.5f;
			return;
		}
		if ((float)@int == 2f)
		{
			this.HealthDamage = 0.75f;
		}
	}

	// Token: 0x06000002 RID: 2 RVA: 0x000020E0 File Offset: 0x000002E0
	private void Update()
	{
		RaycastHit raycastHit = default(RaycastHit);
		this.LookRayCast.LookAt(this.PlayerPos.transform.position);
		this.LookRayCast2.LookAt(this.PlayerPos.transform.position);
		if (Physics.Raycast(this.LookRayCast.position, this.LookRayCast.TransformDirection(Vector3.forward), out raycastHit, this.RayCastMax) || Physics.Raycast(this.LookRayCast2.position, this.LookRayCast2.TransformDirection(Vector3.forward), out raycastHit, this.RayCastMax))
		{
			if (raycastHit.collider.gameObject.tag == "Player")
			{
				this.SlendrinaTouchesPlayer = true;
			}
			else
			{
				this.SlendrinaTouchesPlayer = false;
			}
		}
		else
		{
			this.SlendrinaTouchesPlayer = false;
		}
		if (this.CameraRenderSlendrina(this.SlendrinaMesh, this.CameraPlayer))
		{
			this.IsRenderingSlendrina = true;
		}
		else
		{
			this.IsRenderingSlendrina = false;
		}
		bool playerCaughtAttention = this.PlayerCaughtAttention;
		this.BloodScreen.color = new Color(1f, 0f, 0f, this.BorderBloodValue);
		Vector3 forward = this.PlayerPos.transform.position - base.transform.position;
		forward.y = 0f;
		Quaternion b = Quaternion.LookRotation(forward);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, 15f * Time.deltaTime);
		float num = 0f;
		if (this.SlendrinaTouchesPlayer && this.IsRenderingSlendrina && !PlayerStatus.Died && this.PathingToPlayer && !this.HF.Attacked)
		{
			this.SlendrinaHunts.volume += this.SpeedLookingFade * Time.deltaTime;
			this.PS.Health -= this.HealthDamage * Time.deltaTime;
			if (this.BorderBloodValue < 1f)
			{
				this.BorderBloodValue += this.SpeedBorderFade * Time.deltaTime;
			}
			num += 10f * Time.deltaTime;
			Vector3 forward2 = Vector3.RotateTowards(this.CamPivot.transform.forward, this.LookAtPoint.position - this.CamPivot.transform.position, num, 0f);
			this.PlayerPos.transform.rotation = Quaternion.Euler(0f, this.CamPivot.transform.rotation.eulerAngles.y, 0f);
			this.CamPivot.transform.rotation = Quaternion.LookRotation(forward2);
			this.Agent.speed = 0f;
			if (!this.PlayerCaughtAttention)
			{
				this.PlayerCaughtAttention = true;
				if (this.PlayerPos.gameObject.activeSelf)
				{
					this.PlayerPos.GetComponent<FPSControl>().NeedWait();
				}
				if (Vector3.Distance(base.transform.position, this.PlayerPos.position) <= this.CloseDistance)
				{
					this.SawSource.PlayOneShot(this.StareNear);
				}
				else if (Vector3.Distance(base.transform.position, this.PlayerPos.position) <= this.MaxTouchDistance)
				{
					this.SawSource.PlayOneShot(this.StareFar);
				}
			}
		}
		else
		{
			this.SlendrinaHunts.volume -= this.SpeedLookingFadeGo * Time.deltaTime;
			if (this.BorderBloodValue > 0f)
			{
				this.BorderBloodValue -= this.SpeedBorderFadeGo * Time.deltaTime;
			}
			if (this.PlayerCaughtAttention)
			{
				base.StartCoroutine(this.RestartPos());
				this.PlayerCaughtAttention = false;
			}
			this.PS.Health = 1f;
			this.Agent.speed = this.SpeedWalk;
		}
		if (this.IsRenderingSlendrina && !this.SlendrinaTouchesPlayer && Vector3.Distance(base.transform.position, this.PlayerPos.transform.position) <= this.MaxTouchDistance)
		{
			this.Agent.speed = 0f;
		}
		if (this.PathingToPlayer)
		{
			this.Agent.SetDestination(this.PlayerPos.position);
		}
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002543 File Offset: 0x00000743
	private bool CameraRenderSlendrina(Renderer MeshE, Camera Player)
	{
		return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(Player), MeshE.bounds);
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00002556 File Offset: 0x00000756
	private IEnumerator RestartPos()
	{
		this.SlendrinaTouchesPlayer = false;
		this.Agent.enabled = false;
		base.transform.position = this.StartPosV;
		this.PathingToPlayer = false;
		yield return new WaitForSeconds(15f);
		if (!PlayerStatus.Died)
		{
			this.PathingToPlayer = true;
			if (this.IntherePL)
			{
				base.transform.position = this.StartPos2.position;
			}
			else
			{
				base.transform.position = this.StartPos.position;
			}
			this.Agent.enabled = true;
		}
		yield break;
	}

	// Token: 0x04000001 RID: 1
	public Vector3 StartPosV;

	// Token: 0x04000002 RID: 2
	public Transform StartPos;

	// Token: 0x04000003 RID: 3
	public Transform StartPos2;

	// Token: 0x04000004 RID: 4
	public bool IntherePL;

	// Token: 0x04000005 RID: 5
	public Transform PlayerPos;

	// Token: 0x04000006 RID: 6
	public NavMeshAgent Agent;

	// Token: 0x04000007 RID: 7
	public PlayerStatus PS;

	// Token: 0x04000008 RID: 8
	public bool PathingToPlayer;

	// Token: 0x04000009 RID: 9
	public float HealthDamage = 0.2f;

	// Token: 0x0400000A RID: 10
	public bool PlayerCaughtAttention;

	// Token: 0x0400000B RID: 11
	public Image BloodScreen;

	// Token: 0x0400000C RID: 12
	public bool IsRenderingSlendrina;

	// Token: 0x0400000D RID: 13
	public bool SlendrinaTouchesPlayer;

	// Token: 0x0400000E RID: 14
	public float MaxTouchDistance = 30f;

	// Token: 0x0400000F RID: 15
	public float RayCastMax = 35f;

	// Token: 0x04000010 RID: 16
	public float CloseDistance = 7f;

	// Token: 0x04000011 RID: 17
	public AudioSource SawSource;

	// Token: 0x04000012 RID: 18
	public AudioClip StareFar;

	// Token: 0x04000013 RID: 19
	public AudioClip StareNear;

	// Token: 0x04000014 RID: 20
	public AudioSource SlendrinaHunts;

	// Token: 0x04000015 RID: 21
	public GameObject CamPivot;

	// Token: 0x04000016 RID: 22
	public SkinnedMeshRenderer SlendrinaMesh;

	// Token: 0x04000017 RID: 23
	public Camera CameraPlayer;

	// Token: 0x04000018 RID: 24
	public Transform LookAtPoint;

	// Token: 0x04000019 RID: 25
	public Transform LookRayCast;

	// Token: 0x0400001A RID: 26
	public Transform LookRayCast2;

	// Token: 0x0400001B RID: 27
	public float SpeedWalk = 3f;

	// Token: 0x0400001C RID: 28
	public float BorderBloodValue;

	// Token: 0x0400001D RID: 29
	public float SpeedBorderFade = 1.5f;

	// Token: 0x0400001E RID: 30
	public float SpeedLookingFade = 1.5f;

	// Token: 0x0400001F RID: 31
	public float SpeedBorderFadeGo = 0.5f;

	// Token: 0x04000020 RID: 32
	public float SpeedLookingFadeGo = 1f;

	// Token: 0x04000021 RID: 33
	public HitFly HF;
}
