Addon for [MMORPG Kit](https://assetstore.unity.com/packages/templates/systems/mmorpg-kit-2d-3d-survival-110188) shows PlayingCharacter on [UIObject3D](https://assetstore.unity.com/packages/tools/gui/uiobject3d-render-3d-models-on-any-unity-ui-canvas-92476). UIObject3D dynamically creates camera and clones target object. This addon will make it automatically clone the PlayingCharacter with configuration to disable certain components and child objects (like CharacterController).

UIObject3D has settings to control the rendertexture is rendered constantly or static, light up the clone model, etc.

### Setup

![1-import](https://user-images.githubusercontent.com/755461/223911585-4e581af8-a3ee-4151-bc0e-a541cfaad1d5.png)

1. import UIObject3D from Asset Store

![2-clone](https://user-images.githubusercontent.com/755461/223911678-bff68b83-eebf-4591-b760-0f9ce9485520.png)

2. clone repository

![3-patch](https://user-images.githubusercontent.com/755461/223911716-debe992c-d858-4336-b6b9-58f68ab274d4.png)

3. apply UICharacterObject3D patch. Note that if you are not using Git, you will need to modify the lines manually in UIObject3D. Not to worry, they are small changes adding protected to a few methods.

![4-unpackprefab](https://user-images.githubusercontent.com/755461/223911967-81de32a4-a414-4d9c-ad6b-90812e1916c5.png)

4. modify your UIItemsDialog in the CanvasGameplay to accomodate UICharacterObject3D. In the screenshot above, this is a fresh install of Kit and we would first unpack the prefab.

![5-modifydialog](https://user-images.githubusercontent.com/755461/223912143-3e07da23-a02e-40bb-ba21-dc1930b7eb7d.png)

5. here we change the width of the dialog

![6-modifywindow](https://user-images.githubusercontent.com/755461/223912259-b4247de5-4550-4908-b587-7885d5989a99.png)

6. then we modify the width of the window

![7-addcharacter](https://user-images.githubusercontent.com/755461/223912328-31f1605e-e0d9-4ad1-a7d3-7a6c10f5e68b.png)

7. then we drag the UICharacterObject3D prefab into the hierarchy and change the left margin

![8-settings](https://user-images.githubusercontent.com/755461/223912464-698f530d-af8c-4795-ae68-f8d36074709a.png)

8. modify settings as desired. Note the Enable Character Components and Children sections. *Any component or child not explicitly listed-- including the root and skinned mesh renderer-- will be disabled.*

![9-settingsapplied](https://user-images.githubusercontent.com/755461/223912704-7dae7789-1b4c-47a2-bcd9-3665a89bd733.png)

9. validate settings are applied to the cloned player
