using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// �˼ƭp��
/// �åB����i�Y��Ʊ��j
/// �Ҧp�G���}�C���B���s�C���B��ܿ��..
/// </summary>
public class CountDownAndDoSomething : MonoBehaviour
{
    #region ���P�ݩ�
    [Header("�˼Ʈɶ�"), Range(1, 5)]
    public float timeCountDown = 3;
    [Header("�˼ƫ�ƥ�")]
    public UnityEvent onTimeUp;
    [Header("����")]
    public Image imgBar;

    private float timeMax;

    /// <summary>
    /// �}�l�˼ơGtrue �}�l�Bfalse ����
    /// Unity Event �i�H�s��
    /// 1. ���骫��s�����󤺪� API
    /// 2. �s�����}��k�ȭ��G�L�Ϊ̤@�ӰѼơA������������� (������)
    /// 3. �s�����}�ݩʡG������������� (������)
    /// </summary>
    public bool startCountDown { get; set; }
    #endregion

    #region �˼ƥ\��
    // ����ƥ�G�b Start �e����@��
    private void Awake()
    {
        timeMax = timeCountDown;
    }

    private void Update()
    {
        CountDown();
    }

    /// <summary>
    /// �p�ɾ�
    /// </summary>
    private float timer;

    /// <summary>
    /// �˼ƭp�ɥ\��
    /// </summary>
    private void CountDown()
    {
        if (startCountDown)                         // �p�G �}�l �˼�
        {
            if (timer < timeCountDown)              // �p�G �p�ɾ� �p�� �˼Ʈɶ�
            {
                timer += Time.deltaTime;            // �֥[�ɶ� (�� Update ���I�s)
            }
            else
            {
                onTimeUp.Invoke();                  // �_�h �p�ɾ� �j�󵥩� �˼Ʈɶ� �N �I�s�ƥ�
            }

            imgBar.fillAmount = timer / timeMax;    // ���� = ��e�ɶ� / �̤j�ɶ�
        }
        else                                        // �_�h �S���ݵ۫��s �N����
        {
            timer = 0;                              // �p�ɾ��k�s
            imgBar.fillAmount = 0;                  // �����k�s
        }
    }
    #endregion
}
