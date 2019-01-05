using System;
using System.IO;
using System.Linq;
using Quaver.API.Maps.Parsers.StepMania;
using Xunit;

namespace Quaver.API.Tests.Stepmania
{
    public class TestCaseStepManiaConverter
    {
        [Fact]
        public void ConvertToQua()
        {
            var converter = new StepmaniaConverter("./Stepmania/Resources/chaoz-airflow.sm");
            var quas = converter.ToQua();

            Assert.Single(quas);
        }

        [Fact]
        public void ConvertToQuaFile()
        {
            var dir = "./tests/sm";
            Directory.CreateDirectory(dir);

            var converter = new StepmaniaConverter("./Stepmania/Resources/chaoz-airflow.sm");
            var quas = converter.ToQua();


            for (var i = 0; i < quas.Count; i++)
                quas[i].Save($"{dir}/{i}.qua");
        }

        [Fact]
        public void CheckObjectCount()
        {
            var converter = new StepmaniaConverter("./Stepmania/Resources/chaoz-airflow.sm");
            var qua = converter.ToQua().First();

            Assert.True(qua.HitObjects.Count >= 1);
        }
    }
}
