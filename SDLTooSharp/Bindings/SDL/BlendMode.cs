using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings;

public static partial class SDL2
{
    /// <summary>
    /// The blend mode used in drawing operations and RenderCopy.
    /// </summary>
    public enum SDL_BlendMode
    {
        /// <summary>
        /// No blending
        /// </summary>
        /// <remarks>
        /// <code>dstRGBA = srcRGBA</code></remarks>
        SDL_BLENDMODE_NONE = 0x00000000,

        /// <summary>
        /// Alpha blending
        /// </summary>
        /// <remarks>
        /// <code>dstRgb = (srcRGB * srcA) + (dstRGB * (1-srcA)),
        /// dstA = srcA + (dstA * (1 - srcA))</code></remarks>
        SDL_BLENDMODE_BLEND = 0x00000001,

        /// <summary>
        /// Additive blending.
        /// </summary>
        /// <remarks>
        /// <code>
        ///  dstRGB = (srcRGB * srcA) + dstRGB
        ///  dstA = dstA
        /// </code>
        /// </remarks>
        SDL_BLENDMODE_ADD = 0x00000002,

        /// <summary>
        /// Color modulate
        /// </summary>
        /// <remarks>
        /// <code>
        /// dstRGB = srcRGB * dstRGB
        /// dstA = dstA
        /// </code>
        /// </remarks>
        SDL_BLENDMODE_MOD = 0x00000004,

        /// <summary>
        /// Color multiply
        /// </summary>
        /// <remarks>
        /// <code>
        /// dstRGB = (srcRGB * dstRGB) + (dstRGB * (1-srcA))
        ///dstA = (srcA * dstA) + (dstA * (1-srcA))
        /// </code>
        /// </remarks>
        SDL_BLENDMODE_MUL = 0x00000008,
        SDL_BLENDMODE_INVALID = 0x7FFFFFFF
    }

    /// <summary>
    /// The blend operation used when combining pixel components
    /// </summary>
    public enum SDL_BlendOperation
    {
        /// <summary>
        /// Add
        /// </summary>
        /// <remarks><code>dst + src</code></remarks>
        SDL_BLENDOPERATION_ADD = 0x1,

        /// <summary>
        /// Subtract
        /// </summary>
        /// <remarks><code>dst - src</code></remarks>
        SDL_BLENDOPERATION_SUBTRACT = 0x2,

        /// <summary>
        /// Reverse Subtract
        /// </summary>
        /// <remarks><code>src - dst</code></remarks>
        SDL_BLENDOPERATION_REV_SUBTRACT = 0x3,

        /// <summary>
        /// Minimum
        /// </summary>
        /// <remarks><code>min(dst, src)</code></remarks>
        SDL_BLENDOPERATION_MINIMUM = 0x4,

        /// <summary>
        /// Maximum
        /// </summary>
        /// <remarks><code>max(dst, src)</code></remarks>
        SDL_BLENDOPERATION_MAXIMUM = 0x5
    }

    /// <summary>
    /// The normalized factor used to multiply pixel components.
    /// </summary>
    public enum SDL_BlendFactor
    {
        /// <summary>
        /// <code>0, 0, 0, 0</code>
        /// </summary>
        SDL_BLENDFACTOR_ZERO = 0x1,

        /// <summary>
        /// <code>1, 1, 1, 1</code>
        /// </summary>
        SDL_BLENDFACTOR_ONE = 0x2,

        /// <summary>
        /// <code>srcR, srcG, srcB, srcA</code>
        /// </summary>
        SDL_BLENDFACTOR_SRC_COLOR = 0x3,

        /// <summary>
        /// <code>1-srcR, 1-srcG, 1-srcB, 1-srcA</code>
        /// </summary>
        SDL_BLENDFACTOR_ONE_MINUS_SRC_COLOR = 0x4,

        /// <summary>
        /// <code>srcA, srcA, srcA, srcA</code>
        /// </summary>
        SDL_BLENDFACTOR_SRC_ALPHA = 0x5,

        /// <summary>
        /// <code>1-srcA, 1-srcA, 1-srcA, 1-srcA</code>
        /// </summary>
        SDL_BLENDFACTOR_ONE_MINUS_SRC_ALPHA = 0x6,

        /// <summary>
        /// <code>dstR, dstG, dstB, dstA</code>
        /// </summary>
        SDL_BLENDFACTOR_DST_COLOR = 0x7,

        /// <summary>
        /// <code>1-dstR, 1-dstG, 1-dstB, 1-dstA</code>
        /// </summary>
        SDL_BLENDFACTOR_ONE_MINUS_DST_COLOR = 0x8,

        /// <summary>
        /// <code>dstA, dstA, dstA, dstA</code>
        /// </summary>
        SDL_BLENDFACTOR_DST_ALPHA = 0x9,

        /// <summary>
        /// <code>1-dstA, 1-dstA, 1-dstA, 1-dstA</code>
        /// </summary>
        SDL_BLENDFACTOR_ONE_MINUS_DST_ALPHA = 0xA
    }

    /// <summary>
    /// Compose a custom blend mode
    /// </summary>
    /// <param name="srcColorFactor">The blend factor to be applied to the source color</param>
    /// <param name="dstColorFactor">The blend factor to be applied to the destination color</param>
    /// <param name="colorOperation">The operation used to combine the color components of source and destination</param>
    /// <param name="srcAlphaFactor">The blend factor to be applied to the source alpha</param>
    /// <param name="dstAlphaFactor">The blend factor to be applied to the destination alpha</param>
    /// <param name="alphaOperation">The operation used to combine the alpha components.</param>
    /// <returns></returns>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    [SDLVersion(2, 0, 6)]
    public static extern SDL_BlendMode SDL_ComposeCustomBlendMode(
        SDL_BlendFactor srcColorFactor,
        SDL_BlendFactor dstColorFactor,
        SDL_BlendOperation colorOperation,
        SDL_BlendFactor srcAlphaFactor,
        SDL_BlendFactor dstAlphaFactor,
        SDL_BlendOperation alphaOperation);
}