using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	[Header("References")]
	[SerializeField] Image itemImage;
	[SerializeField] Sprite emptySprite;

    private void Awake()
    {
		itemImage = transform.GetChild(0).GetComponent<Image>();
    }
    private void Start()
    {
		itemImage.sprite = emptySprite;
    }


    public void OnPointerEnter(PointerEventData eventData)
	{
		Manager_Inventory.instance.selectCell(this);
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		Manager_Inventory.instance.selectCell(null);
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		
	}


	public void _SetItem(Manager_Inventory.Items item)
    {

    }
}
