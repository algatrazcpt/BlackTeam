using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class TimeControlSubLevel  : MonoBehaviour
{
    StarterAssetsInputs _inputs;
    public ItemImageControl gameUiItem;
    public LevelAcces _inventorSystem;
    public InputActionReference _actionReference;
    private float scrollingValue;
    private bool isPerformed;
    private bool isMainMachineRegion = false;
    public bool SubLevel = false;
    public int levelId=1;
    void Start()
    {
        _inputs = GetComponent<StarterAssetsInputs>();
        _inventorSystem = LevelAcces.Instance;
        gameUiItem = GameObject.Find("GameGui").GetComponent<ItemImageControl>();
        _actionReference.action.performed += _x => scrollingValue = _x.action.ReadValue<float>();
    }
    public void TestItem(InputAction.CallbackContext context)
    {
        Debug.Log("Only me");
    }

    private void OnTriggerEnter(Collider other)
    {
        isMainMachineRegion = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isMainMachineRegion = false;
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
                int value = hit.collider.GetComponent<ChipSettings>().ChipId;
                _inputs.pick = false;
                Debug.Log("Pick Ýtem");
                Destroy(hit.collider.gameObject);
                _inventorSystem.currentLevel = value;
                _inventorSystem.LevelControl(value);
                // 
            }
        }
            if (_inputs.pick && isMainMachineRegion)
            {
                _inputs.pick = false;
                LevelAcces.Instance.currentLevel = levelId;
                TimeControl.Instance.isSubState = false;
                Destroy(gameObject);
                SceneManager.LoadScene("CutScene",LoadSceneMode.Additive);
                
                Debug.Log("Wroking");
            }
        

        if (_inputs.pick)
        {
            _inputs.pick = false;
        }

    }
}
