using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerActionControl : MonoBehaviour
{
    MissionControl taskSystem;
    StarterAssetsInputs _inputs;
    public ItemImageControl gameUiItem;
    public LevelAcces _inventorSystem;
    public InputActionReference _actionReference;
    private float scrollingValue;
    private bool isPerformed;
    private bool isMainMachineRegion=false;
    public bool SubLevel = false;
    void Start()
    {
        taskSystem = MissionControl.Instance;
        _inputs = GetComponent<StarterAssetsInputs>();
        _inventorSystem = LevelAcces.Instance;
        gameUiItem = GameObject.Find("GameGui").GetComponent<ItemImageControl>();
        _actionReference.action.performed += _x => scrollingValue = _x.action.ReadValue<float>();
        //Task
        taskSystem.GetTask(0);
        taskSystem.StartTask();
        // 
    }
    public void TestItem(InputAction.CallbackContext context)
    {
        Debug.Log("Only me");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MachineRegion"))
        {
            isMainMachineRegion = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MachineRegion"))
        {
            isMainMachineRegion = false;
        }

    }
    void FixedUpdate()
    {
        LayerMask mask = LayerMask.GetMask("PickItems");
        RaycastHit hit;
        //Debug.DrawRay(new Vector3(transform.position.x, 1.5f, transform.position.z), transform.TransformDirection(new Vector3(0, -0.2f, 1)),Color.red);
        if (Physics.Raycast(new Vector3(transform.position.x, 1.5f, transform.position.z), transform.TransformDirection(new Vector3(0, -0.2f, 1)), out hit, 2, mask))
        {
            Debug.DrawRay(new Vector3(transform.position.x, 1.5f, transform.position.z), transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            if (_inputs.pick)
            {
                if (hit.collider.CompareTag("ChipSifre"))
                {
                    Destroy(hit.collider.gameObject);
                    ChipsSifreControls.Instance.AddChips();
                }
                else
                {
                    int value = hit.collider.GetComponent<ChipSettings>().ChipId;
                    _inputs.pick = false;
                    Debug.Log("Pick Ýtem");
                    Destroy(hit.collider.gameObject);
                    _inventorSystem.currentLevel = value;
                    _inventorSystem.LevelControl(value);
                    //
                    //Task
                    if (taskSystem.TaskState(1))
                    {
                        taskSystem.GetTask(1);
                        taskSystem.StartTask();
                    }
                    // 
                }
            }
        }

        if (SubLevel == false)
        {
            
            //
            if (_inputs.pick && _inventorSystem.AccesControl() && _inventorSystem.currentLevel != 0 && isMainMachineRegion)
            {
                
                Debug.Log("CurrenlevelChange");
                _inputs.pick = false;
                TimeControl.Instance.isSubState = true;
                TimeControl.Instance.StartLevel();
                
            }
            else if (_inputs.pick && _inventorSystem.AccesControl() && _inventorSystem.isMainAcces && isMainMachineRegion)
            {
                _inputs.pick = false;
                TimeControl.Instance.isSubState = false;
                TimeControl.Instance.ReturnGame();
            }
        }
        else
        {
           /// Debug.Log("Sublevel Trrue");
            if (_inputs.pick && isMainMachineRegion)
            {
                _inputs.pick = false;
                LevelAcces.Instance.currentLevel = 0;
                TimeControl.Instance.isSubState = true;
                TimeControl.Instance.ReturnGame();
                Debug.Log("Wroking");
            }
        }
        if (scrollingValue > 0)
        {
            if (_inventorSystem.maxLevel <= _inventorSystem.currentLevel)
            {
                _inventorSystem.currentLevel = 1;
            }
            else
            {
                _inventorSystem.currentLevel += 1;

            }
        }

        else if (scrollingValue < 0)
        {
            if (1 > _inventorSystem.currentLevel)
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
