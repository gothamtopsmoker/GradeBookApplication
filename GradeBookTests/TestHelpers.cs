using System;
using System.Linq;

namespace GradeBookTests
{
    public static class TestHelpers
    {
        private static readonly string _projectName = "GradeBook";

        public static Type GetUserType(string fullName)
        {
            // Force load tracking logic to make isolated tests run correctly
            var dummy = typeof(GradeBook.Enums.GradeBookType);

            return (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                    where assembly.FullName.StartsWith(_projectName)
                    from type in assembly.GetTypes()
                    where type.FullName == fullName
                    select type).FirstOrDefault();
        }
    }
}
