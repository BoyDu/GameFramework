using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Test : MonoBehaviour {

    List<Vector3> m_pathList = null;
    public Transform start;
    public Transform end;

    bool moving = false;
    int pathIndex = 0;
    float speed = 20f;
    Seeker m_seeker = null;
	// Use this for initialization
	void Start () {
        m_seeker = gameObject.AddComponent<Seeker>();
	}

    void Update()
    {
        if (moving)
        {
            //Util.DrawPathLine(m_pathList);

            if (pathIndex >= m_pathList.Count)
            {
                Debug.Log("pathindex = " + pathIndex + "   count = " + m_pathList.Count);
                Stop();
                return;
            }

            Vector3 dir = m_pathList[pathIndex] - start.position;
            start.position += dir * speed * Time.deltaTime;

            if( (start.position - m_pathList[pathIndex]).sqrMagnitude <= Mathf.Pow(speed * Time.deltaTime,2) )
            {
                pathIndex++;
            }
            

            
        }
    }
	
	void OnGUI()
    {
        if(GUI.Button(new Rect(0,100,100,50),"寻路"))
        {
            Stop();
//             m_pathList = AStar.FindPath(start.position, end.position);
//             moving = (m_pathList != null && m_pathList.Count > 0);

          m_seeker.StartPath(start.position, end.position,FindPathComplete);
           
        }
    }

    void FindPathComplete(Pathfinding.Path p)
    {
        if (!p.error)
        {
            m_pathList = p.vectorPath;
            moving = true;
            Debug.Log("error : " + p.vectorPath.Count);
        }
        else
        {
            Debug.Log("right : " + p.vectorPath.Count);
            moving = false;
        }
    }

    void Stop()
    {
        m_pathList = null;
        moving = false;
        pathIndex = 0;
    }
}
