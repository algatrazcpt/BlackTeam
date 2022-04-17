using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class TimeControlSubLevel  : MonoBehaviour
{
    MissionControl taskSystem;
    StarterAssetsInputs _inputs;
    public ItemImageControl gameUiItem;
    public LevelAcces _inventorSystem;
    public InputActionReference _actionReference;
    public TeleportTime teleporTimerControl;
    private float scrollingValue;
    private bool isPerformed;
    private bool isMainMachineRegion = false;
    public bool SubLevel = false;
    public int levelId=1;
    void Start()
    {
        teleporTimerControl=TeleportTime.Instance;
        taskSystem = MissionControl.Instance;
        levelId = LevelAcces.Instance.currentLevel;
        _inputs = GetComponent<StarterAssetsInputs>();
        _inventorSystem = LevelAcces.Instance;
        gameUiItem = GameObject.Find("GameGui").GetComponent<ItemImageControl>();
        _actionReference.action.performed += _x => scrollingValue = _x.action.ReadValue<float>();
        if (levelId == 1 && taskSystem.TaskState(3))
        {
            Debug.Log("Task2");
            taskSystem.GetTask(3);
            taskSystem.StartTask();
        }
        else if (levelId == 2 && taskSystem.TaskState(5))
        {
            Debug.Log("Task3");
            taskSystem.GetTask(5);
            taskSystem.StartTask();
        }
         teleporTimerControl.StartTeleportTimer();
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
                teleporTimerControl.DeleteTimerNotBreak();
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
