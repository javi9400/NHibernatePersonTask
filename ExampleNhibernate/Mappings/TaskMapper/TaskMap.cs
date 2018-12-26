using ExampleNhibernate.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ExampleNhibernate.Mappings.TaskMapper
{
    public class TaskMap: ClassMap<Task>
    {
        public TaskMap()
        {

            Id(x => x.Id).GeneratedBy
                .Assigned(); 
            Map(x => x.CreationTime);
            Map(x => x.State);
            Map(x => x.Title);
            Map(x => x.Description);
            Map(x => x.UpdatedDate);
            Map(x => x.CreationDate);
            References(x => x.AssignedTo)
                .Cascade.All();

        }
    }
}
