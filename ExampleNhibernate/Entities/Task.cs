using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleNhibernate.Entities
{
    public class Task
    {
        public virtual int  Id { get; set; }

        public virtual string Title
        {
            get;
            set;
        }
        public virtual string Description
        {
            get;
            set;
        }
        public virtual DateTime CreationTime
        {
            get;
            set;
        }
        public virtual TaskState State
        {
            get;
            set;
        }

        //Llave foranea
        public virtual Person AssignedTo
        {
            get;
            set;
        }

       
        public virtual DateTime CreationDate
        {
            get;
            set;
        }
        public virtual DateTime UpdatedDate
        {
            get;
            set;
        }

        public Task()
        {
            CreationTime = DateTime.UtcNow;
            State = TaskState.Open;
        }
    }

    public enum TaskState: byte
    {
        Open=0,
        Active=1,
        Completed=2,
        Close=3

    }
}
