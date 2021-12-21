﻿using DexieWrapper.Database;
using DexieWrapper.Demo.Persons;
using DexieWrapper.JsModule;

namespace DexieWrapper.Demo.Database
{
    public class MyDb : Db
    {
        public Store<Person> Persons { get; set; } = new("id");

        public MyDb(IJsModuleFactory jsModuleFactory) 
            : base("MyDatabase", 2, new DbVersion[] { new Version1() }, jsModuleFactory)
        {
        }
    }
}