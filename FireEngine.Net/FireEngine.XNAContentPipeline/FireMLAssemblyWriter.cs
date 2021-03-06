using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using System.Runtime.Serialization.Formatters.Binary; 

// TODO: replace this with the type you want to write out.
using TWrite = FireEngine.FireMLEngine.FireMLRoot;

namespace FireEngine.XNAContentPipeline
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content Pipeline
    /// to write the specified data type into binary .xnb format.
    ///
    /// This should be part of a Content Pipeline Extension Library project.
    /// </summary>
    [ContentTypeWriter]
    public class FireMLAssemblyWriter : ContentTypeWriter<TWrite>
    {
        protected override void Write(ContentWriter output, TWrite value)
        {
            // TODO: write the specified value to the output ContentWriter.
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(output.BaseStream, value);
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            // TODO: change this to the name of your ContentTypeReader
            // class which will be used to load this data.
            return "FireEngine.XNAContent.FireMLAssemblyReader, FireEngine.XNAContent";
        }
    }
}
