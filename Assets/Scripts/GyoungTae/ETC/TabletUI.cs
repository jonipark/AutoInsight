using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TabletUI : MonoBehaviour
{

 //   public InputActionAsset inputActions;

    public Camera mainCamera;
    public GameObject TestUI;
 

    private float distanceFromCamera = 0.5f;

    // 이전 프레임의 primaryButton 값을 저장하기 위한 변수
    private float previousPrimaryButton = 0;
    private float previousSecondaryButton = 0;

    // Update is called once per frame
    void Update()
    {
     //   var primaryButton = inputActions.actionMaps[2].actions[9].ReadValue<float>();
        
        //var secondaryButton = inputActions.actionMaps[2].actions[10].ReadValue<float>();

        //// 이전 프레임과 현재 프레임의 값이 다를 때만 상태를 업데이트
        //if (secondaryButton == 1 && previousSecondaryButton != 1)
        //{
        //    // 현재 상태의 반대 값을 넘겨서 업데이트
        //    ActionTabletUI(!TestUI.activeSelf);
        //}

        //// 현재 프레임의 값을 이전 프레임의 값으로 저장
        //previousSecondaryButton = secondaryButton;

        UpdateUIToCameraPosition(); // 매 프레임마다 UI를 카메라 위치에 업데이트
    }

    

    void ActionTabletUI(bool isActive)
    {
        TestUI.gameObject.SetActive(isActive);

        //if (isActive)
        //{
        //    // MainCamera의 위치와 방향을 가져와서 TestUI를 바로 앞에 배치합니다.
        //    Vector3 cameraPosition = mainCamera.transform.position;
        //    Vector3 cameraForward = mainCamera.transform.forward;
        //    Vector3 tabletPosition = cameraPosition + cameraForward * distanceFromCamera;

        //    // TestUI의 위치를 업데이트합니다.
        //    TestUI.transform.position = tabletPosition;
        //    // 이 부분에서 필요에 따라 TestUI의 회전 등을 조절할 수 있습니다.
        //    TestUI.transform.LookAt(cameraPosition);
        //    // 반대 방향으로 향하고 있어 앞쪽 축을 뒤집는다.
        //    TestUI.transform.forward *= -1;
        //}
    }

   public void UpdateUIToCameraPosition()
    {
        if (TestUI.activeSelf)
        {
            // MainCamera의 위치와 방향을 가져와서 TestUI를 바로 앞에 배치합니다.
           
            Vector3 cameraPosition = mainCamera.transform.position;
     

          // Vector3 cameraForward = mainCamera.transform.forward;  
          // Vector3 tabletPosition = cameraPosition + cameraForward * distanceFromCamera;


            Vector3 updateForward = new Vector3(mainCamera.transform.forward.x, 0, mainCamera.transform.forward.z).normalized;
            Vector3 updateTabletPos = cameraPosition + updateForward * distanceFromCamera;



            // TestUI의 위치를 업데이트합니다.

            //TestUI.transform.position = tabletPosition;
            TestUI.transform.position = updateTabletPos;

            TestUI.transform.LookAt(cameraPosition);
            // 반대 방향으로 향하고 있어 앞쪽 축을 뒤집는다.
            TestUI.transform.forward *= -1;
        }
    }
}
