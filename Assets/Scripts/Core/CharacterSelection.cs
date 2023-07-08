using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    private LinkedList<int> list = new LinkedList<int>();
    private LinkedListNode<int> frist = null;
    private LinkedListNode<int> last = null;
    [SerializeField] Transform[] points;
    private int index = 1;

    public List<GameObject> characters = new List<GameObject>();
    public List<GameObject> names = new List<GameObject>();
    public Text viewText = null;

    private void Start()
    {
        LinkedListNode<int> current = null;

        for(int i = 0; i < characters.Count; i++)
        {
            LinkedListNode<int> node = new LinkedListNode<int>(i);
            
            if(list.Count <= 0)
            {
                list.AddFirst(node);
                current = node;
            }
            else
            {
                list.AddAfter(current, node);
                current = node;
            }
        }

        frist = list.First;
        last = list.Last;
    }

    private void SelectCharacter()
    {
        int p = 0, n = 2;

        if(list.Find(index).Previous != null)
        {
            p = list.Find(index).Previous.Value;
        }
        else
        {
            p = last.Value;
        }

        if (list.Find(index).Next != null)
        {
            n = list.Find(index).Next.Value;
        }
        else
        {
            n = frist.Value;
        }

        characters[p].transform.position = points[0].position;
        names[p].SetActive(false);
        characters[index].transform.position = points[1].position;
        names[index].SetActive(true);
        characters[n].transform.position = points[2].position;
        names[n].SetActive(false);

        CharacterSpwonManager.getInstance().SetCharacter(index);
    }

    public void Left()
    {
        if (list.Find(index).Previous != null)
        {
            index = list.Find(index).Previous.Value;
        }
        else
        {
            index = last.Value;
        }

        SelectCharacter();
    }

    public void Right()
    {
        if (list.Find(index).Next != null)
        {
            index = list.Find(index).Next.Value;
        }
        else
        {
            index = frist.Value;
        }

        SelectCharacter();
    }
}
