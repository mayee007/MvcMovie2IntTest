using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MvcMovie2IntTest.Utils 
{
    [CollectionDefinition("Database collection")]
    class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
