using System;
using TMPro;
using UnityEngine;

// Token: 0x02000012 RID: 18
public class InteractRay : MonoBehaviour
{
	// Token: 0x06000037 RID: 55 RVA: 0x00002696 File Offset: 0x00000896
	private void Start()
	{
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00002F24 File Offset: 0x00001124
	private void Update()
	{
		// Do nothing when not in play mode (prevents edit-mode destruction and related errors)
		if (!Application.isPlaying)
		{
			return;
		}
		// Respect global pause flag if available (Paused is a static type)
		if (Paused.IsPaused)
		{
			return;
		}
		if (this.TextOn)
		{
			this.TimerT += Time.deltaTime;
			if (this.TimerT >= this.MaxTimerT)
			{
				this.TimerT = 0f;
				this.TextOn = false;
				if (this.NeedShit != null && this.NeedShit.gameObject != null)
				{
					this.NeedShit.gameObject.SetActive(false);
				}
			}
		}
		if (this.KeyAmount != null)
		{
			this.KeyAmount.text = this.Keys.ToString();
		}
		if (this.PageAmount != null)
		{
			this.PageAmount.text = this.Pages.ToString();
		}
		this.PlayerMask = ~LayerMask.GetMask(new string[]
		{
			"Player"
		});
		Vector3 direction = base.transform.TransformDirection(Vector3.forward);
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position, direction, out raycastHit, this.RaycastDistance, this.PlayerMask))
		{
			if (raycastHit.collider.gameObject.name == "GhostHouseDoor")
			{
				if (raycastHit.collider.gameObject.GetComponent<AudioSource>() == null || !raycastHit.collider.gameObject.GetComponent<AudioSource>().isPlaying)
				{
					if (this.RingE != null) this.RingE.SetActive(true);
				}
				if (Input.GetKeyDown(this.KeyCodeE))
				{
					if (this.Pages < 8f)
					{
						if (this.NeedShit != null)
						{
							this.NeedShit.text = "First, I need to find all books to exit.";
						}
						this.ActivateText();
						raycastHit.collider.GetComponent<AudioSource>().Play();
						return;
					}
					this.CE.Escape();
					this.SoundEff.PlayOneShot(this.EscapeSound);
					this.Player.GetComponent<FPSControl>().enabled = false;
					base.GetComponent<Animation>().CrossFade("idle");
					base.GetComponent<InteractRay>().enabled = false;
					return;
				}
			}
			else if (raycastHit.collider.gameObject.name == "Cellar3SteelDoor2")
			{
				if (this.RingE != null) this.RingE.SetActive(true);
				if (Input.GetKeyDown(this.KeyCodeE))
				{
					raycastHit.collider.gameObject.name = "doorInteracted";
					raycastHit.collider.GetComponent<Animation>().Play("openDoor");
					raycastHit.collider.GetComponent<AudioSource>().Play();
					return;
				}
			}
			else if (raycastHit.collider.gameObject.name == "Cellar3SteelDoorLocked" && (this.SoundEff == null || !this.SoundEff.isPlaying))
			{
				if (this.RingE != null) this.RingE.SetActive(true);
				if (Input.GetKeyDown(this.KeyCodeE))
				{
					if (this.Keys > 0f)
					{
						this.Keys -= 1f;
						raycastHit.collider.GetComponent<AudioSource>().Play();
						raycastHit.collider.GetComponent<Animation>().Play("openDoor");
							if (this.NeedShit != null)
							{
								this.NeedShit.text = "One key has been used.";
							}
						this.ActivateText();
						raycastHit.collider.gameObject.name = "doorClosed";
						return;
					}
						this.SoundEff.PlayOneShot(this.LockedSound);
						if (this.NeedShit != null)
						{
							this.NeedShit.text = "The door is locked.";
						}
					this.ActivateText();
					return;
				}
			}
			else if (raycastHit.collider.gameObject.name == "DoorCellar2")
			{
				if (this.RingE != null) this.RingE.SetActive(true);
				if (Input.GetKeyDown(this.KeyCodeE))
				{
					raycastHit.collider.gameObject.name = "doorInteracted";
					raycastHit.collider.GetComponent<Animation>().Play("openDoor");
					this.SoundEff.PlayOneShot(this.OpenSound);
					return;
				}
			}
			else if (raycastHit.collider.gameObject.name == "GarderobDorrH")
			{
				if (this.RingE != null) this.RingE.SetActive(true);
				if (Input.GetKeyDown(this.KeyCodeE))
				{
					raycastHit.collider.gameObject.name = "doorInteracted";
					raycastHit.collider.GetComponent<Animation>().Play("openH");
					this.SoundEff.PlayOneShot(this.OpenClose);
					return;
				}
			}
			else if (raycastHit.collider.gameObject.name == "GarderobDorrV")
			{
				if (this.RingE != null) this.RingE.SetActive(true);
				if (Input.GetKeyDown(this.KeyCodeE))
				{
					raycastHit.collider.gameObject.name = "doorInteracted";
					raycastHit.collider.GetComponent<Animation>().Play("openV");
					this.SoundEff.PlayOneShot(this.OpenClose);
					return;
				}
			}
			else if (raycastHit.collider.gameObject.name == "DoorCellarLocked" && (this.SoundEff == null || !this.SoundEff.isPlaying))
			{
				if (this.RingE != null) this.RingE.SetActive(true);
				if (Input.GetKeyDown(this.KeyCodeE))
				{
					if (this.Keys > 0f)
					{
						this.Keys -= 1f;
						this.SoundEff.PlayOneShot(this.UnlockSound);
						raycastHit.collider.GetComponent<Animation>().Play("openDoor");
						if (this.NeedShit != null)
						{
							this.NeedShit.text = "One key has been used.";
						}
						this.ActivateText();
						raycastHit.collider.gameObject.name = "doorClosed";
						return;
					}
					this.SoundEff.PlayOneShot(this.LockedSound);
					if (this.NeedShit != null)
					{
						this.NeedShit.text = "The door is locked.";
					}
					this.ActivateText();
					return;
				}
			}
			else if (raycastHit.collider.gameObject.name == "Key")
			{
				if (this.RingE != null) this.RingE.SetActive(true);
				if (Input.GetKeyDown(this.KeyCodeE))
				{
					this.SoundEff.PlayOneShot(this.CollectKey);
						this.Keys += 1f;
					UnityEngine.Object.Destroy(raycastHit.collider.gameObject);
					return;
				}
			}
			else
			{
				if (!(raycastHit.collider.gameObject.name == "Book"))
				{
					if (this.RingE != null) this.RingE.SetActive(false);
					return;
				}
				if (this.RingE != null) this.RingE.SetActive(true);
					if (Input.GetKeyDown(this.KeyCodeE))
				{
					this.SoundEff.PlayOneShot(this.CollectPaper);
					if (this.Pages == 7f)
					{
							if (this.NeedShit != null)
							{
								this.NeedShit.text = "Well done! Now run to the exit!";
							}
						this.ActivateText();
					}
					this.Pages += 1f;
					UnityEngine.Object.Destroy(raycastHit.collider.gameObject);
					return;
				}
			}
		}
		else
		{
			if (this.RingE != null)
			{
				this.RingE.SetActive(false);
			}
		}
	}

	// Token: 0x06000039 RID: 57 RVA: 0x000035A4 File Offset: 0x000017A4
	public void ActivateText()
	{
		this.TextOn = true;
		this.TimerT = 0f;
		if (this.NeedShit != null && this.NeedShit.gameObject != null)
		{
			this.NeedShit.gameObject.SetActive(true);
		}
	}

	// Token: 0x04000066 RID: 102
	public GameObject RingE;

	// Token: 0x04000067 RID: 103
	public float RaycastDistance = 4f;

	// Token: 0x04000068 RID: 104
	public LayerMask PlayerMask;

	// Token: 0x04000069 RID: 105
	public AudioSource SoundEff;

	// Token: 0x0400006A RID: 106
	public AudioClip LockedSound;

	// Token: 0x0400006B RID: 107
	public AudioClip OpenSound;

	// Token: 0x0400006C RID: 108
	public AudioClip OpenClose;

	// Token: 0x0400006D RID: 109
	public AudioClip EscapeSound;

	// Token: 0x0400006E RID: 110
	public AudioClip UnlockSound;

	// Token: 0x0400006F RID: 111
	public AudioClip CollectPaper;

	// Token: 0x04000070 RID: 112
	public AudioClip CollectKey;

	// Token: 0x04000071 RID: 113
	public TMP_Text PageAmount;

	// Token: 0x04000072 RID: 114
	public TMP_Text KeyAmount;

	// Token: 0x04000073 RID: 115
	public TMP_Text NeedShit;

	// Token: 0x04000074 RID: 116
	public KeyCode KeyCodeE;

	// Token: 0x04000075 RID: 117
	public float Pages;

	// Token: 0x04000076 RID: 118
	public float Keys;

	// Token: 0x04000077 RID: 119
	public PlayerStatus PlayerStatus;

	// Token: 0x04000078 RID: 120
	public CutsceneEscape CE;

	// Token: 0x04000079 RID: 121
	public GameObject Player;

	// Token: 0x0400007A RID: 122
	public float TimerT;

	// Token: 0x0400007B RID: 123
	public float MaxTimerT = 4f;

	// Token: 0x0400007C RID: 124
	public bool TextOn;
}
