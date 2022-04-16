using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerActionControl : MonoBehaviour
{
    StarterAssetsInputs _inputs;
    public ItemImageControl gameUiItem;
    public LevelAcces _inventorSystem;
    public InputActionReference _actionReference;
    private float scrollingValue;
    private bool isPerformed;
    void Start()
    {
        _inputs = GetComponent<StarterAssetsInputs>();
        _actionReference.action.performed += _x => scrollingValue = _x.action.ReadValue<float>();
    }
    public void TestItem(InputAction.CallbackContext context)
    {
        Debug.Log("Only me");
    }

    void FixedUpdate()
    {
        LayerMask mask = LayerMask.GetMask("PickItems");
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(transform.position.x, 1.5f, transform.position.z), transform.TransformDirection(Vector3.forward), out hit, 2, mask))
        {
            Debug.DrawRay(new Vector3(transform.position.x, 1.5f, transform.position.z), transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            Debug.Log(hit.collider.GetComponent<ChipSettings>().ChipName);
            if (_inputs.pick)
            {
                int value= hit.collider.GetComponent<ChipSettings>().ChipId;
                _inputs.pick = false;
                Debug.Log("Pick Ýtem");
                Destroy(hit.collider.gameObject);
                _inventorSystem.currentLevel = value;
                _inventorSystem.LevelControl(value);
                // 
            }
        }
        

        //
        if(_inputs.pick && _inventorSystem.AccesControl() && _inventorSystem.currentLevel!=0)
        {
            _inputs.pick = false;
            TimeControl.Instance.StartLevel();
        }
        if (_inputs.pick && _inventorSystem.AccesControl() && _inventorSystem.isMainAcces)
        {
            _inputs.pick = false;
            TimeControl.Instance.ReturnGame();
        }
        //
        if (scrollingValue > 0)
        {
            if (_inventorSystem.maxLevel <= _inventorSystem.currentLevel)
            {
                _inventorSystem.currentLevel = 0;
            }
            else
            {
                _inventorSystem.currentLevel += 1;
                
            }
        }
        
        else if (scrollingValue < 0)
        {
            if (0 > _inventorSystem.currentLevel)
            {
                _inventorSystem.currentLevel = _inventorSystem.maxLevel;
            }
            else
            {
                _inventorSystem.currentLevel -= 1;
                
            }
        }
        gameUiItem.ItemMaterialChange(_inventorSystem.currentLevel, _inventorSystem.AccesControl());
        if (_inputs.pick)
        {
            _inputs.pick= false;
        }
    }
}
