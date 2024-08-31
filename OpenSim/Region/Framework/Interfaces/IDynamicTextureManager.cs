/*
 * Copyright (c) Contributors, http://opensimulator.org/
 * See CONTRIBUTORS.TXT for a full list of copyright holders.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *     * Redistributions of source code must retain the above copyright
 *       notice, this list of conditions and the following disclaimer.
 *     * Redistributions in binary form must reproduce the above copyright
 *       notice, this list of conditions and the following disclaimer in the
 *       documentation and/or other materials provided with the distribution.
 *     * Neither the name of the OpenSimulator Project nor the
 *       names of its contributors may be used to endorse or promote products
 *       derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE DEVELOPERS ``AS IS'' AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE CONTRIBUTORS BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Drawing;
using System.IO;

using OpenMetaverse;

namespace OpenSim.Region.Framework.Interfaces
{
    public interface IDynamicTextureManager
    {
        void RegisterRender(string handleType, IDynamicTextureRender render);

        void ReturnData(UUID id, IDynamicTexture texture);

        UUID AddDynamicTextureURL(UUID simID, UUID primID, string contentType, string url, string extraParams);
        UUID AddDynamicTextureURL(UUID simID, UUID primID, string contentType, string url, string extraParams,
                                bool SetBlending, byte AlphaValue);
        UUID AddDynamicTextureURL(UUID simID, UUID primID, string contentType, string url, string extraParams,
                                bool SetBlending, int disp, byte AlphaValue, int face);

        UUID AddDynamicTextureUUID(UUID simID, UUID primID, string contentType, UUID textureUUID, string extraParams);
        UUID AddDynamicTextureUUID(UUID simID, UUID primID, string contentType, UUID textureUUID, string extraParams, bool SetBlending, byte AlphaValue);
        UUID AddDynamicTextureUUID(UUID simID, UUID primID, string contentType, UUID textureUUID, string extraParams, bool SetBlending, int disp, byte AlphaValue, int face);


        UUID AddDynamicTextureData(UUID simID, UUID primID, string contentType, string data, string extraParams);


        UUID AddDynamicTextureData(UUID simID, UUID primID, string contentType, string data, string extraParams,
                                    bool SetBlending, byte AlphaValue);


        UUID AddDynamicTextureData(UUID simID, UUID primID, string contentType, string data, string extraParams,
                    bool SetBlending, int disp, byte AlphaValue, int face);

        void GetDrawStringSize(string contentType, string text, string fontName, int fontSize,
                               out double xSize, out double ySize);
    }

    public interface IDynamicTextureRender
    {
        string GetName();
        string GetContentType();
        bool SupportsAsynchronous();

        IDynamicTexture ConvertUrl(string url, string extraParams);
        IDynamicTexture ConvertUUID(UUID textureUUID, string extraParams);
        IDynamicTexture ConvertData(string bodyData, string extraParams);

        bool AsyncConvertUrl(UUID id, string url, string extraParams);
        bool AsyncConvertUUID(UUID id, UUID textureUUID, string extraParams);
        bool AsyncConvertData(UUID id, string bodyData, string extraParams);

        void GetDrawStringSize(string text, string fontName, int fontSize,
                               out double xSize, out double ySize);
    }

    public interface IDynamicTexture
    {
        /// <summary>
        /// Input commands used to generate this data.
        /// </summary>
        /// <remarks>
        /// Null if input commands were not used.
        /// </remarks>
        string InputCommands { get; }

        /// <summary>
        /// Uri used to generate this data.
        /// </summary>
        /// <remarks>
        /// Null if a uri was not used.
        /// </remarks>
        Uri InputUri { get; }

        /// <summary>
        /// UUID used to generate this data.
        /// </summary>
        /// <remarks>
        /// Null if a UUID was not used.
        /// </remarks>
        UUID InputUUID { get; }

        /// <summary>
        /// Extra input params used to generate this data.
        /// </summary>
        string InputParams { get; }

        /// <summary>
        /// Texture data.
        /// </summary>
        byte[] Data { get; }

        /// <summary>
        /// Size of texture.
        /// </summary>
        Size Size { get; }

        /// <summary>
        /// Signal whether the texture is reusable (i.e. whether the same input data will always generate the same
        /// texture).
        /// </summary>
        bool IsReusable { get; }
        bool IsReuseable { get; set; }
    }
}
