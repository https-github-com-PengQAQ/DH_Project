using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
[Hotfix]
[LuaCallCSharp]
public class BossFollow : MonoBehaviour
{
    const int Length = 100;
    TraceableObject tb;
    int tail = 0;       //队列位置
    int i = 0;
    public GameObject redLight;
    public void BeginFollow()
    {
        this.gameObject.SetActive(true);
        tb = new TraceableObject();
        tb.ob = GameObject.Find("Player(Clone)");
        if(tb.ob == null)
            tb.ob = GameObject.Find("GunPlayer(Clone)");
        StartCoroutine(RecordHistory());
        StartCoroutine(dealy3f());
        //redLight.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        { 
            BeginFollow();
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            EndFollow();
        }
    }
    IEnumerator dealy3f()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(OnBackInTime());
    }
    public void EndFollow()
    {
        this.gameObject.SetActive(false);
    }
    
    /// <summary>
    /// 记录历史参数
    /// </summary>
    public class TraceableObject
    {
        public GameObject ob;
        public Queue<Vector3> pos = new Queue<Vector3>();     //在时间片中的位置
        public Queue<Vector3> scale = new Queue<Vector3>();
        public Queue<Quaternion> rot = new Queue<Quaternion>();
        public Queue<Sprite> sprite = new Queue<Sprite>();
    }

    /// <summary>
    /// 记录历史信息
    /// </summary>
    /// <returns></returns>
    IEnumerator RecordHistory()
    {
        while (true)
        {
            Record(tb);
            yield return new WaitForEndOfFrame();
        }

    }

    /// <summary>
    /// 恢复
    /// </summary>
    /// <returns></returns>
    IEnumerator OnBackInTime()
    {
        while (tb.pos.Count > 0)
        {
            transform.position = tb.pos.Dequeue();
            transform.rotation = tb.rot.Dequeue();
            transform.localScale = tb.scale.Dequeue();
            GetComponent<SpriteRenderer>().sprite = tb.sprite.Dequeue();
            yield return new WaitForEndOfFrame();
        }
    }
    /// <summary>
    /// 记录tb当前状态到时间片i上
    /// </summary>
    /// <param name="tb"></param>
    /// <param name="i"></param>
    void Record(TraceableObject tb)
    {
        if (tb.ob == null)
            return;
        tb.pos.Enqueue(tb.ob.transform.position);
        tb.rot.Enqueue(tb.ob.transform.rotation);
        tb.scale.Enqueue(tb.ob.transform.localScale);
        tb.sprite.Enqueue(tb.ob.GetComponent<SpriteRenderer>().sprite);
        i++;
        if (i >= Length)
        {
            Reset();
        }

    }
    void Reset()
    {
        StopCoroutine(RecordHistory());
        //tb.pos.Clear();
        //tb.sprite.Clear();
        //i = 0;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Globel.Player.GetComponent<MoveController>().PlayerHurt();
    }
}
