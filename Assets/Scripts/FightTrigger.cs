using UnityEngine;

public class FightTrigger : MonoBehaviour
{
    [SerializeField] Character character; // Owner of the trigger

    private void Start()
    {
        if (character == null)
        {
            Debug.LogWarning("Character is NULL");

            character = transform.parent.GetComponent<Character>();

            Debug.Log("Character was found");
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        character.Attack(collision.gameObject.GetComponent<Character>());
    }

    public void OnCollisionExit(Collision collision)
    {
        character.PlayAnimation(0);
    }
}
