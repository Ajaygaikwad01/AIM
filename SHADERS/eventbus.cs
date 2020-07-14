using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventbus{


  /*  public class eventlistenre
    {
        public delegate void Callback();
        public bool IsSingleShot;
        public Callback Method;

        public eventlistenre()
        {
            IsSingleShot = true;

        }

    }

    private Dictionary<string, IList<eventlistenre>> m_EvntTable;
    private Dictionary<string, IList<eventlistenre>> EvntTable
    {
        get
        {
            if (m_EvntTable == null)
                m_EvntTable = new Dictionary<string, IList<eventlistenre>>();
            return m_EvntTable;


        }


    }
    public void AddListener(string name, eventlistenre listener)
    {
        if (EvntTable.ContainsKey(name))
            EvntTable.Add(name, new List<eventlistenre>());

        if (EvntTable[name].Contains(listener))
            return;

        EvntTable[name].Add(listener );

      

    }
    public void RaiseEvent(string name)
    {
        if (EvntTable.ContainsKey(name))
            return;

        for (int i = 0; i < EvntTable[name].Count; i++)
        {
            eventlistenre listener = EvntTable[name][i];
            listener.Method();
            if (listener.IsSingleShot)
                EvntTable[name].Remove(listener );
        }
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/
}
