﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaTest;

using Xsd2.Capitalizers;

namespace Xsd2.Tests
{
    [TestFixture]
    public class GenerationTests
    {
        [Test]
        public void Test1()
        {
            var options = new XsdCodeGeneratorOptions
            {
                Imports = new List<string>() {@"Schemas\MetaConfig.xsd"},
                PropertyNameCapitalizer = new FirstCharacterCapitalizer(),
                OutputNamespace = "XSD2",
                UseLists = true,
                UseNullableTypes = true,
                ExcludeImportedTypes = true,
                AttributesToRemove =
                {
                    "System.Diagnostics.DebuggerStepThroughAttribute"
                }
            };
            
            using (var o = File.CreateText(@"Schemas\Xsd2Config.cs"))
            {
                var generator = new XsdCodeGenerator() { Options = options };
                generator.Generate(new[] { @"Schemas\Xsd2Config.xsd" }, o);
            }
        }

        [Test(Active=false)]
        public void Test2()
        {
            var options = new XsdCodeGeneratorOptions
            {
                PropertyNameCapitalizer = new FirstCharacterCapitalizer(),
                OutputNamespace = "XSD2",
                UseLists = true,
                UseNullableTypes = true,
                ExcludeImportedTypes = true,
                AttributesToRemove =
                {
                    "System.Diagnostics.DebuggerStepThroughAttribute"
                }
            };

            using (var o = File.CreateText(@"Schemas\Data.cs"))
            {
                var generator = new XsdCodeGenerator() { Options = options };
                generator.Generate(new[] { @"Schemas\Data.xsd" }, o);
            }
        }

        [Test(Active = true)]
        public void Test3()
        {
            var options = new XsdCodeGeneratorOptions
            {
                PropertyNameCapitalizer = new FirstCharacterCapitalizer(),
                OutputNamespace = "XSD2",
                UseLists = true,
                UseNullableTypes = true,
                ExcludeImportedTypes = true,
                MixedContent = true,
                AttributesToRemove =
                {
                    "System.Diagnostics.DebuggerStepThroughAttribute"
                }
            };
            
            using (var o = File.CreateText(@"Schemas\Form.cs"))
            {
                var generator = new XsdCodeGenerator() { Options = options };
                generator.Generate(new[] { @"Schemas\Form.xsd" }, o);
            }
        }

    }
}
