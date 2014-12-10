using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
