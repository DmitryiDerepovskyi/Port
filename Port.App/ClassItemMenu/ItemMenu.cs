using System;
using System.Collections.Generic;

namespace Port.App.ClassItemMenu
{
    public abstract class ItemMenu
    {
        protected ItemMenu()
        {
            OperationItemMenu = new Dictionary<string, Action>
            {
                {"Add", this.Add},
                {"Update", this.Update},
                {"Search by id", this.SearchById },
                {"Remove", this.Remove},
                {"Print all",this.PrintAll},
            };
        }
        public Dictionary<string, Action> OperationItemMenu;
        abstract public void Add();
        abstract public void Remove();
        abstract public void Update();
        abstract public void SearchById();
        abstract public void PrintAll();
    }
}
