using System.Collections;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float minHeight;
    public float maxHeight;
    public GameObject pivot;

    // Start is called before the first frame update
    void Start()
    {
        // ������ �� ƴ���� ���̸� ����
        ChangeHeight();
    }

    private void ChangeHeight()
    {
        //������ ���̸� �����ϰ� ����
        float height = Random.Range(minHeight, maxHeight);
        pivot.transform.localPosition = new Vector3(0.0f, height, 0.0f);
    }

    // ScrollObject ��ũ��Ʈ�κ����� �޽����� �޾� ���̸� ����
    void OnScrollEnd()
    {
        ChangeHeight();
    }
}
