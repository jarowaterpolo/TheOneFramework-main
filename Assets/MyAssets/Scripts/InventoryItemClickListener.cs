using UnityEngine;
using UnityEngine.UI;

public class InventoryItemClickListener : MonoBehaviour
{
    private Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (transform.childCount > 0 && transform.GetChild(0) != null)
        {
            FindAnyObjectByType<InvItemChecker>().OnItemClick(transform.GetChild(0).name);
        }
    }
}
