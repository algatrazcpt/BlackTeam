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
    public GameObject _gameObject;
    private float scrollingValue;
    void Start()
    {
        _inputs = GetComponent<StarterAssetsInputs>();
        _actionReference.action.performed += _x => scrollingValue = _x.action.ReadValue<float>();
    }
    void FixedUpdate()
    {
        LayerMask mask = LayerMask.GetMask("PickItems");
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(transform.position.x, 1.5f, transform.position.z), transform.TransformDirection(Vector3.forward), out hit, 2, mask))
        {
            Debug.DrawRay(new Vector3(transform.position.x, 1.5f, transform.position.z), transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            gameUiItem.ItemMaterialChange(1);
            Debug.Log(hit.collider.GetComponent<ChipSettings>().ChipName);
            if (_inputs.pick)
            {
                _inputs.pick = false;
                Debug.Log("Pick Ýtem");
                Destroy(hit.collider.gameObject);
                _inventorSystem.Acceslevel(hit.collider.GetComponent<ChipSettings>().ChipId);
                // 
            }
        }
        else
        {
            gameUiItem.ItemMaterialChange(2);
        }
        //
        if (_inputs.jump && _inventorSystem.isAccesLevel2)
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Additive);
            _inputs.jump = false;
            _gameObject.SetActive(false);
        }
        else if (_inputs.jump && _inventorSystem.isAccesLevel1)
        {
            SceneManager.LoadScene("Level", LoadSceneMode.Additive);
            _inputs.jump = false;
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
            Debug.Log("ScrolUp");
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
    }
}
