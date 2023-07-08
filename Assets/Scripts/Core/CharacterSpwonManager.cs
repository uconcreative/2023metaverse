using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterSpwonManager : SingleonMono<CharacterSpwonManager>
{
    [SerializeField] private GameObject[] characters = null;

    public int arrayIndex = 1;
    public int[] partsIndex = new int[5]{0, 0, 0, 0, 0}; 

    public void SetCharacter(int index)
    {
        if(characters.Length > 0)
        {
            arrayIndex = index;
        }
    }

    public void SpwonCharacter(Transform location, LevelChanger level, CinemachineFreeLook freeLook)
    {
        GameObject character = Instantiate(characters[arrayIndex], location.position, location.rotation);
        character.GetComponent<PlayerTriggerController>().changer = level;
        freeLook.Follow = character.transform;
        freeLook.LookAt = character.GetComponent<PlayerController>().LookAtPoint;

        CustomizableCharacter customizable = character.GetComponent<CustomizableCharacter>();
            customizable.SetParts(CustomizableCharacter.Parts.Face, partsIndex[0]);
        customizable.SetParts(CustomizableCharacter.Parts.Hair,partsIndex[1]);
		customizable.SetParts(CustomizableCharacter.Parts.Cloth, partsIndex[2]);
		//customizable.SetParts(CustomizableCharacter.Parts.Bottom,partsIndex[3]);
		//customizable.SetParts(CustomizableCharacter.Parts.Shoes, partsIndex[4]);



	}
}
