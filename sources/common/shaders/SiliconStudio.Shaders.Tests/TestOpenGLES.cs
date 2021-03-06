﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using SiliconStudio.Core.IO;
using SiliconStudio.Paradox.Effects;
using SiliconStudio.Shaders.Utilities;

namespace SiliconStudio.Shaders.Tests
{
    [TestFixture]
    class TestOpenGLES
    {
        private void Mount()
        {
            VirtualFileSystem.MountFileSystem("/assets/shaders", "../../ShaderES");
        }

        [Test]
        public void TestUnroll()
        {
            Mount();

            var fileStream = VirtualFileSystem.OpenStream("/assets/shaders/UnrollTest.hlsl", VirtualFileMode.Open, VirtualFileAccess.Read);
            var sr = new StreamReader(fileStream);
            string source = sr.ReadToEnd();
            fileStream.Close();

            var compilerES = new SiliconStudio.Paradox.Graphics.ShaderCompiler.OpenGL.ShaderCompiler(true);
            compilerES.Compile(source, "VSMain", "vs");

            var compiler = new SiliconStudio.Paradox.Graphics.ShaderCompiler.OpenGL.ShaderCompiler();
            compiler.Compile(source, "VSMain", "vs");
        }

        [Test]
        public void TestBreak()
        {
            Mount();

            var fileStream = VirtualFileSystem.OpenStream("/assets/shaders/UnrollBreak.hlsl", VirtualFileMode.Open, VirtualFileAccess.Read);
            var sr = new StreamReader(fileStream);
            string source = sr.ReadToEnd();
            fileStream.Close();

            var compiler = new SiliconStudio.Paradox.Graphics.ShaderCompiler.OpenGL.ShaderCompiler(true);
            compiler.Compile(source, "VSMain", "vs");
        }
    }
}
