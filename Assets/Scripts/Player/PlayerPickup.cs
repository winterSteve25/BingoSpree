using System;
using Items;
using UnityEngine;

namespace Player
{
    public class PlayerPickup : MonoBehaviour
    {
        private static PlayerPickup _instance;
        public static PlayerPickup Instance => _instance;
        
        public event Action<Item> OnItemPickedUp;

        [SerializeField] private Camera mainCam;
        public float pickupRange;
        
        private WorldItem _hoveringItem;
        
        private void Awake()
        {
            _instance = this;
        }

        private void Update()
        {
            TryPickupItem();
        }

        private void TryPickupItem()
        {
            Vector2 mp = Input.mousePosition;
            Ray ray = mainCam.ScreenPointToRay(mp);
            var hasHit = Physics.Raycast(ray, out var hit, pickupRange, LayerMask.GetMask("Items"));
            
            if (!hasHit)
            {
                ResetHovering();
                return;
            }

            if (!hit.transform.TryGetComponent(out WorldItem item))
            {
                ResetHovering();
                return;
            }

            if (!item.Pickable)
            {
                ResetHovering();
                return;
            }

            if (_hoveringItem != item)
            {
                if (_hoveringItem != null)
                {
                    _hoveringItem.IsHovering = false;
                }

                _hoveringItem = item;
                _hoveringItem.IsHovering = true;
            }

            if (!Input.GetMouseButton(0)) return;

            OnItemPickedUp?.Invoke(item.Item);
            item.PickUp(transform);
        }

        private void ResetHovering()
        {
            if (_hoveringItem != null)
            {
                _hoveringItem.IsHovering = false;
            }

            _hoveringItem = null;
        }
    }
}