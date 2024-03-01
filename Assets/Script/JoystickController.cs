using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform knob;
    [SerializeField] private RectTransform background;
    private Vector2 inputVector;

    private void Awake()
    {
        if (knob == null)
            knob = transform.GetChild(0).GetComponent<RectTransform>();
        if (background == null)
            background = GetComponent<RectTransform>();
    }
    private void OnDisable()
    {
        inputVector = Vector2.zero;
    }
    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 touchPosition = Vector2.zero;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(background, eventData.position, eventData.pressEventCamera, out touchPosition))
        {
            touchPosition.x = (touchPosition.x / background.sizeDelta.x);
            touchPosition.y = (touchPosition.y / background.sizeDelta.y);

            inputVector = new Vector2(touchPosition.x * 2, touchPosition.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;


            knob.anchoredPosition = new Vector2(inputVector.x * (background.sizeDelta.x / 2), inputVector.y * (background.sizeDelta.y / 2));
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        knob.anchoredPosition = Vector2.zero;
    }

    public float Horizontal()
    {
        return inputVector.x;
    }

    public float Vertical()
    {
        return inputVector.y;
    }
}
