using Svg;

namespace Kenku.WinformApplication.Helpers
{
    internal static class ImageHelpers
    {
        public static class Record
        {
            public static SvgDocument Start { get; } = SvgDocument
                .Open(@"resources\microphone-button-green-icon.svg");

            public static SvgDocument Stop { get; } = SvgDocument
                .Open(@"resources\microphone-button-red-icon.svg");
        }

        public static class Playback
        {
            public static SvgDocument Start { get; } = SvgDocument
                .Open(@"resources\green-play-button-icon.svg");

            public static SvgDocument Stop { get; } = SvgDocument
                .Open(@"resources\stop-button-red-icon.svg");
        }
    }
}