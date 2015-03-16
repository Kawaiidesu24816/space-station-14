﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Drawing = System.Drawing;
using SS14.Client.Graphics.CluwneLib;
using SS14.Shared.Maths;
using SS14.Client.Graphics.CluwneLib.Vertex;
using SS14.Client.Graphics.CluwneLib.Collection;
using VertexFieldContext = SS14.Client.Graphics.CluwneLib.Vertex.VertexEnums.VertexFieldContext;
using VertexFieldType = SS14.Client.Graphics.CluwneLib.Vertex.VertexEnums.VertexFieldType;



namespace SS14.Client.Graphics.CluwneLib.Vertex
{
    /// <summary>
    /// Object representing a list of vertex types.
    /// </summary>
    public class VertexTypeList : BaseCollection<VertexType> , IDisposable
    {
        #region Value Types.
        /// <summary>
        /// Value type describing a sprite vertex.
        /// </summary>
        [StructLayout(LayoutKind.Sequential , Pack = 1)]
        public struct PositionDiffuse2DTexture1
        {
            #region Variables.
            /// <summary>
            /// Position of the vertex.
            /// </summary>
            public Vector3 Position;

            /// <summary>
            /// Color value of the vertex.
            /// </summary>
            internal int ColorValue;

            /// <summary>
            /// Texture coordinates.
            /// </summary>
            public Vector2 TextureCoordinates;
            #endregion

            #region Properties.
            /// <summary>
            /// Property to set or return the color as a <see cref="System.Drawing.Color"/> value.
            /// </summary>
            public Drawing.Color Color
            {
                get
                {
                    return Drawing.Color.FromArgb(ColorValue);
                }
                set
                {
                    ColorValue = value.ToArgb();
                }
            }
            #endregion

            #region Methods.
            /// <summary>
            /// Returns the fully qualified type name of this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="T:System.String"/> containing a fully qualified type name.
            /// </returns>
            public override string ToString ( )
            {
                return string.Format("PositionDiffuse2DTexture1:\nPosition: X={0}, Y={1}, Z={2}\nDiffuse: R={3}, G={4}, B={5}, A={6}\n2D Texture coordinates (index 0): X={7}, Y={8}" , Position.X , Position.Y , Position.Z , Color.R , Color.G , Color.B , Color.A , TextureCoordinates.X , TextureCoordinates.Y);
            }

            /// <summary>
            /// Indicates whether this instance and a specified object are equal.
            /// </summary>
            /// <param name="obj">Another object to compare to.</param>
            /// <returns>
            /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
            /// </returns>
            public override bool Equals ( object obj )
            {
                if (!(obj is PositionDiffuse2DTexture1))
                    return false;

                PositionDiffuse2DTexture1 value = (PositionDiffuse2DTexture1)obj;

                return (value.ColorValue == this.ColorValue) && (value.Position == this.Position) && (value.TextureCoordinates == this.TextureCoordinates);
            }

            /// <summary>
            /// Returns the hash code for this instance.
            /// </summary>
            /// <returns>
            /// A 32-bit signed integer that is the hash code for this instance.
            /// </returns>
            public override int GetHashCode ( )
            {
                return base.GetHashCode();
            }

            /// <summary>
            /// Implements the operator ==.
            /// </summary>
            /// <param name="left">The left value.</param>
            /// <param name="right">The right value.</param>
            /// <returns>The result of the operator.</returns>
            public static bool operator == ( PositionDiffuse2DTexture1 left , PositionDiffuse2DTexture1 right )
            {
                return (left.Position == right.Position) && (left.TextureCoordinates == right.TextureCoordinates) && (left.ColorValue == right.ColorValue);
            }

            /// <summary>
            /// Implements the operator !=.
            /// </summary>
            /// <param name="left">The left value.</param>
            /// <param name="right">The right value.</param>
            /// <returns>The result of the operator.</returns>
            public static bool operator != ( PositionDiffuse2DTexture1 left , PositionDiffuse2DTexture1 right )
            {
                return (left.Position != right.Position) || (left.TextureCoordinates != right.TextureCoordinates) || (left.ColorValue != right.ColorValue);
            }
            #endregion

            #region Constructor.
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="position">Position of the vertex.</param>
            /// <param name="color">Color of the vertex.</param>
            /// <param name="textureCoordinates">Texture coordinates.</param>
            public PositionDiffuse2DTexture1 ( Vector3 position , Drawing.Color color , Vector2 textureCoordinates )
            {
                // Copy data.
                Position = position;
                ColorValue = color.ToArgb();
                TextureCoordinates = textureCoordinates;
            }
            #endregion
        }
        #endregion

        #region Properties.
        /// <summary>
        /// Property to return a vertex type by index.
        /// </summary>
        public VertexType this[int index]
        {
            get
            {
                return GetItem(index);
            }
        }

        /// <summary>
        /// Property to return a vertex type by its key name.
        /// </summary>
        public VertexType this[string key]
        {
            get
            {
                return GetItem(key);
            }
        }
        #endregion

        #region Methods.
        /// <summary>
        /// Function to clear the list.
        /// </summary>
        protected void Clear ( )
        {
            // Destroy all the vertex types.
            foreach (VertexType vertexType in this)
                vertexType.Dispose();

            base.ClearItems();
        }

        /// <summary>
        /// Function to create the vertex types.
        /// </summary>
        protected void CreateVertexTypes ( )
        {
            VertexType newType;		// Vertex type.

            // Position, Diffuse, Normal, 1 2D Texture Coord.
            newType = new VertexType();
            newType.CreateField(0 , 0 , VertexFieldContext.Position , VertexFieldType.Float3);
            newType.CreateField(0 , 12 , VertexFieldContext.Diffuse , VertexFieldType.Color);
            newType.CreateField(0 , 16 , VertexFieldContext.TexCoords , VertexFieldType.Float2);

            AddItem("PositionDiffuse2DTexture1" , newType);
        }
        #endregion

        #region Constructor/Destructor.
        /// <summary>
        /// Constructor.
        /// </summary>
        internal VertexTypeList ( )
            : base(16 , true)
        {
            CreateVertexTypes();
        }
        #endregion

        #region IDisposable Members

        /// <summary>
        /// Function to perform clean up.
        /// </summary>
        /// <param name="disposing">TRUE to release all resources, FALSE to only release unmanaged.</param>
        protected virtual void Dispose ( bool disposing )
        {
            if (disposing)
                Clear();
        }

        /// <summary>
        /// Function to perform clean up.
        /// </summary>
        public void Dispose ( )
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}