using System.Collections;
using System.Linq;
using LiteNetLibManager;
using UnityEngine;
using MultiplayerARPG;

namespace UI.ThreeDimensional
{
	[RequireComponent(typeof(RectTransform)), DisallowMultipleComponent, ExecuteInEditMode]
	[AddComponentMenu("UI/UIObject3D/UICharacterObject3D")]
	public class UICharacterObject3D : UIObject3D
	{
		[Header("MMORPG Kit CharacterEntity")]
		[SerializeField] private string[] EnableCharacterComponents;
		[SerializeField] private string[] EnableCharacterChildren;

        protected override void OnEnable()
        {
			base.OnEnable();
			RegisterOwningCharacterEvents();
		}

        protected override void OnDisable()
        {
			base.OnDisable();
			UnregisterOwningCharacterEvents();
		}

		protected override void SetupTarget()
		{
			//set ObjectPrefab to PlayingCharacterEntity
			if (!GameInstance.PlayingCharacterEntity) return;
			ObjectPrefab = GameInstance.PlayingCharacterEntity.gameObject.transform;

			base.SetupTarget();
		}

		protected override void UpdateTargetPositioningAndScale()
		{
			if (target == null) return;
			bool initial = targetBounds == default(Bounds);

			if (initial)
			{
				//disable all character components
				MonoBehaviour[] components = target.GetComponents<MonoBehaviour>();
				foreach (MonoBehaviour c in components)
				{
					if (!EnableCharacterComponents.Contains(c.name))
						c.enabled = false;
				}

				//disable all children
				foreach (Transform t in target.transform)
				{
					GameObject go = t.gameObject;
					if (!EnableCharacterChildren.Contains(go.name))
						go.SetActive(false);
				}

			}

			base.UpdateTargetPositioningAndScale();

			//target bouncing around on equip
			target.transform.localPosition = Vector3.zero;
		}

		private void RegisterOwningCharacterEvents()
		{
			UnregisterOwningCharacterEvents();
			if (!GameInstance.PlayingCharacterEntity) return;
			GameInstance.PlayingCharacterEntity.onEquipWeaponSetChange += OnEquipWeaponSetChange;
			GameInstance.PlayingCharacterEntity.onSelectableWeaponSetsOperation += OnSelectableWeaponSetsOperation;
			GameInstance.PlayingCharacterEntity.onEquipItemsOperation += OnEquipItemsOperation;
		}

		private void UnregisterOwningCharacterEvents()
		{
			if (!GameInstance.PlayingCharacterEntity) return;
			GameInstance.PlayingCharacterEntity.onEquipWeaponSetChange -= OnEquipWeaponSetChange;
			GameInstance.PlayingCharacterEntity.onSelectableWeaponSetsOperation -= OnSelectableWeaponSetsOperation;
			GameInstance.PlayingCharacterEntity.onEquipItemsOperation -= OnEquipItemsOperation;
		}

		private void OnEquipWeaponSetChange(byte equipWeaponSet)
		{
			StartCoroutine(WaitRefreshTarget(0.1f));
		}

		private void OnSelectableWeaponSetsOperation(LiteNetLibSyncList.Operation operation, int index)
		{
			//wait longer for weapon instantiate
			StartCoroutine(WaitRefreshTarget(1f));
		}

		private void OnEquipItemsOperation(LiteNetLibSyncList.Operation operation, int index)
		{
			StartCoroutine(WaitRefreshTarget(0.1f));
		}

		IEnumerator WaitRefreshTarget(float wait)
		{      
			yield return new WaitForSeconds(wait);
			RefreshTarget();
		}
	}
}
