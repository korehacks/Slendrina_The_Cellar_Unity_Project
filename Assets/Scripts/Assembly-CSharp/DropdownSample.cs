using System;
using TMPro;
using UnityEngine;

// Token: 0x0200001F RID: 31
public class DropdownSample : MonoBehaviour
{
	// Token: 0x06000064 RID: 100 RVA: 0x00003BA0 File Offset: 0x00001DA0
	public void OnButtonClick()
	{
		this.text.text = ((this.dropdownWithPlaceholder.value > -1) ? ("Selected values:\n" + this.dropdownWithoutPlaceholder.value.ToString() + " - " + this.dropdownWithPlaceholder.value.ToString()) : "Error: Please make a selection");
	}

	// Token: 0x040000A3 RID: 163
	[SerializeField]
	private TextMeshProUGUI text;

	// Token: 0x040000A4 RID: 164
	[SerializeField]
	private TMP_Dropdown dropdownWithoutPlaceholder;

	// Token: 0x040000A5 RID: 165
	[SerializeField]
	private TMP_Dropdown dropdownWithPlaceholder;
}
