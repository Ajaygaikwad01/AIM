using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Container : MonoBehaviour {

    [System .Serializable ]
    public class ContainerItem
    {

        public System.Guid Id;
        public string Name;
        public int Maximun;

        public int amounttaken;

        public  ContainerItem ()
        {
            Id = System.Guid.NewGuid();

        }

        public int remaining
        {
            get
            {

                return Maximun - amounttaken;



            }



        }

        public int Get(int value)
        {
            if ((amounttaken + value) > Maximun)
            {

                int toMuch = (amounttaken + value) - Maximun;
                amounttaken = Maximun;
                return value - toMuch;
            }
            amounttaken += value;
            return value;

        }
        public void Set(int amount)
        {
            amounttaken -= amount;
            if (amounttaken < 0)
                amounttaken = 0;
        }
    }

    
  public  List <ContainerItem > item;



  public event System.Action OnContanerReady;

    // Use this for initialization
  void Awake()
  {
      item = new List<ContainerItem>();

      if (OnContanerReady != null)
          OnContanerReady();

  }


    public System.Guid Add(string name, int maximum)
    {
        item.Add(new ContainerItem
        {
           // Id = System .Guid .NewGuid (),
            Maximun =maximum ,
            Name=name 
           
        });
        return item .Last ().Id;
    }

    public void Put(string name, int amount)
    {

        var ContainerItem = item.Where(x => x.Name == name).FirstOrDefault();
        if (ContainerItem == null)
            return;
        ContainerItem.Set(amount );
    }

public int TakeFromContainer(System.Guid  id,int amount){
    var ContainerItem = getcontaineritem(id);
    if(ContainerItem == null)
        return -1;

    return ContainerItem.Get(amount );

}
public int GetAmountRemaining(System.Guid id)
{
    var ContainerItem = getcontaineritem(id);
    if (ContainerItem == null)
        return -1;

    return ContainerItem.remaining;
}
    private ContainerItem getcontaineritem(System.Guid id)
    {

        var ContainerItem = item.Where(x => x.Id == id).FirstOrDefault();
        return ContainerItem;
    }
}

	