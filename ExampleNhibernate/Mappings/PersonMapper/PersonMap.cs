using ExampleNhibernate.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleNhibernate.Mappings.PersonMapper
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id)
                .GeneratedBy
                .Assigned();
            Map(x => x.Name);
            Map(x => x.CreationDate);
            Map(x => x.UpdatedDate);
        }
    }
}
