using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200000C RID: 12
public class FPSControl : MonoBehaviour
{
	// Token: 0x0600001E RID: 30 RVA: 0x0000298F File Offset: 0x00000B8F
	private void Start()
	{
		Cursor.visible = false;
	}

	// Token: 0x0600001F RID: 31 RVA: 0x00002997 File Offset: 0x00000B97
	private void Awake()
	{
		this.cameraRotationSpeed = PlayerPrefs.GetFloat("sensitivity", 2f);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	// Token: 0x06000020 RID: 32 RVA: 0x000029BC File Offset: 0x00000BBC
	private void Update()
	{
		if (Paused.IsPaused)
		{
			return;
		}
		if (this.AbleToMove)
		{
			if (this.isAllowedToMove)
			{
				if (this.CamK)
				{
					this.GetTouchInput();
				}
			}
			else
			{
				this.CameraAnim.CrossFade("idle");
			}
			this.HandlePlayerMovement();
			this.ApplyFinalMovements();
			if (Input.GetAxis("Horizontal") != 0f)
			{
				this.CameraAnim.CrossFade("HeadBobAnimation");
			}
			if (Input.GetAxis("Vertical") != 0f)
			{
				this.CameraAnim.CrossFade("HeadBobAnimation");
			}
			else if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f)
			{
				this.CameraAnim.CrossFade("idle");
			}
		}
		else
		{
			this.CameraAnim.CrossFade("idle");
		}
		this.HandleVerticalMovement();
	}

	// Token: 0x06000021 RID: 33 RVA: 0x00002AA0 File Offset: 0x00000CA0
	private void GetTouchInput()
	{
		float y = Input.GetAxis("Mouse X") * this.cameraRotationSpeed;
		this.rotationX -= Input.GetAxis("Mouse Y") * this.cameraRotationSpeed;
		this.rotationX = Mathf.Clamp(this.rotationX, this.minXRotation, this.maxXRotation);
		this.playerCamera.localRotation = Quaternion.Euler(this.rotationX, 0f, 0f);
		base.transform.rotation *= Quaternion.Euler(0f, y, 0f);
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00002B40 File Offset: 0x00000D40
	private void HandlePlayerMovement()
	{
		float axis = Input.GetAxis("Horizontal");
		float axis2 = Input.GetAxis("Vertical");
		Vector3 vector = new Vector3(axis, 0f, axis2);
		if (vector.magnitude > 1f)
		{
			vector.Normalize();
		}
		vector *= this.moveSpeed;
		vector = base.transform.TransformDirection(vector);
		this.moveDirection.x = vector.x;
		this.moveDirection.z = vector.z;
		this.isMoving = (vector.magnitude > 0f);
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00002BD8 File Offset: 0x00000DD8
	private void ApplyFinalMovements()
	{
		if (!this.isMoving)
		{
			this.moveDirection.x = 0f;
			this.moveDirection.z = 0f;
		}
		this.characterController.Move(this.moveDirection * Time.deltaTime);
	}

	// Token: 0x06000024 RID: 36 RVA: 0x00002C29 File Offset: 0x00000E29
	private void HandleVerticalMovement()
	{
		if (!this.characterController.isGrounded)
		{
			this.characterController.Move(Vector3.down * this.FallSpeed * Time.deltaTime);
		}
	}

	// Token: 0x06000025 RID: 37 RVA: 0x00002C5E File Offset: 0x00000E5E
	public void AdjustSpeed(float newSpeed)
	{
		this.cameraRotationSpeed = newSpeed;
	}

	// Token: 0x06000026 RID: 38 RVA: 0x00002C67 File Offset: 0x00000E67
	public void NeedWait()
	{
		base.StartCoroutine(this.Waiter());
	}

	// Token: 0x06000027 RID: 39 RVA: 0x00002C76 File Offset: 0x00000E76
	private IEnumerator Waiter()
	{
		this.CamK = false;
		yield return new WaitForSeconds(0.15f);
		this.rotationX = 0f;
		this.playerCamera.localRotation = Quaternion.Euler(this.rotationX, 0f, 0f);
		this.CamK = true;
		yield break;
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00002C88 File Offset: 0x00000E88
	public void ResetRotation()
	{
		this.CameraAnim.enabled = false;
		this.rotationX = 0f;
		this.playerCamera.localRotation = Quaternion.Euler(this.rotationX, 0f, 0f);
		this.CameraAnim.enabled = true;
	}

	// Token: 0x04000044 RID: 68
	public Transform playerCamera;

	// Token: 0x04000045 RID: 69
	public CharacterController characterController;

	// Token: 0x04000046 RID: 70
	public float cameraRotationSpeed = 2f;

	// Token: 0x04000047 RID: 71
	public float maxXRotation = 80f;

	// Token: 0x04000048 RID: 72
	public float minXRotation = -80f;

	// Token: 0x04000049 RID: 73
	public float moveSpeed = 5f;

	// Token: 0x0400004A RID: 74
	public Animation CameraAnim;

	// Token: 0x0400004B RID: 75
	private Vector3 moveDirection;

	// Token: 0x0400004C RID: 76
	private Vector3 velocity;

	// Token: 0x0400004D RID: 77
	private Vector2 currentInput;

	// Token: 0x0400004E RID: 78
	private bool isMoving;

	// Token: 0x0400004F RID: 79
	public bool RotateXReser;

	// Token: 0x04000050 RID: 80
	public float RotateValue;

	// Token: 0x04000051 RID: 81
	public Camera playerCamera2;

	// Token: 0x04000052 RID: 82
	public Transform CamPivot;

	// Token: 0x04000053 RID: 83
	public bool isAllowedToMove = true;

	// Token: 0x04000054 RID: 84
	private float rotationX;

	// Token: 0x04000055 RID: 85
	public bool AbleToMove = true;

	// Token: 0x04000056 RID: 86
	public float SpeedFade;

	// Token: 0x04000057 RID: 87
	public float FallSpeed = 9.81f;

	// Token: 0x04000058 RID: 88
	public bool CamK = true;
}
