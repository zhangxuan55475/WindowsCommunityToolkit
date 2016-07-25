﻿// ******************************************************************
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THE CODE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE CODE OR THE USE OR OTHER DEALINGS IN THE CODE.
// ******************************************************************
using Microsoft.Windows.Toolkit.Notifications.Adaptive.Elements;

namespace Microsoft.Windows.Toolkit.Notifications
{
    /// <summary>
    /// An adaptive text element.
    /// </summary>
    public sealed class AdaptiveText
        : IAdaptiveChild,
        IAdaptiveSubgroupChild,
        ITileBindingContentAdaptiveChild,
        IToastBindingGenericChild,
        IBaseText
    {
        /// <summary>
        /// The text to display.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The target locale of the XML payload, specified as a BCP-47 language tags such as "en-US" or "fr-FR". The locale specified here overrides any other specified locale, such as that in binding or visual. If this value is a literal string, this attribute defaults to the user's UI language. If this value is a string reference, this attribute defaults to the locale chosen by Windows Runtime in resolving the string.
        /// </summary>
        public string Language { get; set; }

#if ANNIVERSARY_UPDATE
        /// <summary>
        /// The style controls the text's font size, weight, and opacity. Note that for Toast, the style will only take effect if the text is inside an <see cref="AdaptiveSubgroup"/>.
        /// </summary>
#else
        /// <summary>
        /// The style controls the text's font size, weight, and opacity. Not supported on Toast.
        /// </summary>
#endif
        public AdaptiveTextStyle HintStyle { get; set; }

#if ANNIVERSARY_UPDATE
        /// <summary>
        /// Set this to true to enable text wrapping. For Tiles, this is false by default. For Toasts, this is true on top-level text elements, and false inside an <see cref="AdaptiveSubgroup"/>. Note that for Toast, setting wrap will only take effect if the text is inside an <see cref="AdaptiveSubgroup"/> (you can use HintMaxLines = 1 to prevent top-level text elements from wrapping).
        /// </summary>
#else
        /// <summary>
        /// Set this to true to enable text wrapping. For Tiles, this is false by default. Not supported on Toast (text will always wrap).
        /// </summary>
#endif
        public bool? HintWrap { get; set; }

        private int? _hintMaxLines;

#if ANNIVERSARY_UPDATE
        /// <summary>
        /// The maximum number of lines the text element is allowed to display. For Tiles, this is infinity by default. For Toasts, top-level text elements will have varying max line amounts (and in the Anniversary Update you can change the max lines). Text on a Toast inside an <see cref="AdaptiveSubgroup"/> will behave identically to Tiles (default to infinity).
        /// </summary>
#else
        /// <summary>
        /// The maximum number of lines the text element is allowed to display. For Tiles, this is infinity by default. Not supported on Toast (the max lines will vary).
        /// </summary>
#endif
        public int? HintMaxLines
        {
            get
            {
                return _hintMaxLines;
            }

            set
            {
                if (value != null)
                {
                    Element_AdaptiveText.CheckMaxLinesValue(value.Value);
                }

                _hintMaxLines = value;
            }
        }

        private int? _hintMinLines;

#if ANNIVERSARY_UPDATE
        /// <summary>
        /// The minimum number of lines the text element must display. Note that for Toast, this property will only take effect if the text is inside an <see cref="AdaptiveSubgroup"/>.
        /// </summary>
#else
        /// <summary>
        /// The minimum number of lines the text element must display. Not supported on Toast.
        /// </summary>
#endif
        public int? HintMinLines
        {
            get
            {
                return _hintMinLines;
            }

            set
            {
                if (value != null)
                {
                    Element_AdaptiveText.CheckMinLinesValue(value.Value);
                }

                _hintMinLines = value;
            }
        }

#if ANNIVERSARY_UPDATE
        /// <summary>
        /// The horizontal alignment of the text. Note that for Toast, this property will only take effect if the text is inside an <see cref="AdaptiveSubgroup"/>.
        /// </summary>
#else
        /// <summary>
        /// The horizontal alignment of the text. Not supported on Toast.
        /// </summary>
#endif
        public AdaptiveTextAlign HintAlign { get; set; }

        internal Element_AdaptiveText ConvertToElement()
        {
            return new Element_AdaptiveText()
            {
                Text = Text,
                Lang = Language,
                Style = HintStyle,
                Wrap = HintWrap,
                MaxLines = HintMaxLines,
                MinLines = HintMinLines,
                Align = HintAlign
            };
        }

        /// <summary>
        /// Returns the value of the Text property.
        /// </summary>
        /// <returns>The value of the Text property.</returns>
        public override string ToString()
        {
            return Text;
        }
    }
}