Addon for [MMORPG Kit](https://assetstore.unity.com/packages/templates/systems/mmorpg-kit-2d-3d-survival-110188) shows PlayingCharacter on [UIObject3D](https://assetstore.unity.com/packages/tools/gui/uiobject3d-render-3d-models-on-any-unity-ui-canvas-92476). UIObject3D dynamically creates camera and clones target object. This addon will make it automatically clone the PlayingCharacter with configuration to disable certain components and child objects (like CharacterController).

UIObject3D has settings to control the rendertexture is rendered constantly or static, light up the clone model, etc.

### Setup

1. patch for UICharacterObject3D should be applied to UIObject3D.cs.
2. add UIObject3D to your UICharacterInventory by right-clicking in the Hierarchy window and selecting UI: UIObject3d
3. add the UICharacterObject3D component to that object, and change target and camera settings as needed
4. optionally set MMORPG character components and child objects to disable in the cloned player