using Devdog.General2.UI;
using Devdog.Rucksack.Items;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Devdog.Rucksack.UI
{
    [RequireComponent(typeof(UIWindow))]
    public class ItemTooltipUI : UIMonoBehaviour
    {
        [SerializeField]
        protected Text itemName;
        [SerializeField]
        protected Text itemDescription;
        [SerializeField]
        protected Image icon;

        private UIWindow _window;

        private void Awake()
        {
            _window = GetComponent<UIWindow>();
        }
        
        public virtual void Repaint(IUnityItemInstance item, int amount, PointerEventData eventData)
        {
            if (item != null)
            {
                Set(itemName, item.itemDefinition.name); 
                Set(itemDescription, item.itemDefinition.description); 
                Set(icon, item.itemDefinition.icon);
                
                _window.Show();
            }
            else
            {
                _window.Hide();
            }
        }

        protected virtual void Update()
        {
            if (_window.isVisible)
            {
                // Update position to mouse
                PositionRectTransformAtPosition(transform, Input.mousePosition);
            }
        }
        
        protected void PositionRectTransformAtPosition(Transform t, Vector3 screenPos)
        {
            var canvas = GetComponentInParent<Canvas>().rootCanvas;
            if (canvas.renderMode == RenderMode.ScreenSpaceCamera || canvas.renderMode == RenderMode.WorldSpace)
            {
                Vector2 pos;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), screenPos, canvas.worldCamera, out pos);
                t.position = canvas.transform.TransformPoint(pos);
            }
            else if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                t.position = screenPos;
            }
        }
    }
}