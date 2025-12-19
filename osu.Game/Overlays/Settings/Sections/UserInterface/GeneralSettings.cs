// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Localisation;
using osu.Game.Configuration;
using osu.Game.Graphics.UserInterface;
using osu.Game.Localisation;

namespace osu.Game.Overlays.Settings.Sections.UserInterface
{
    public partial class GeneralSettings : SettingsSubsection
    {
        protected override LocalisableString Header => CommonStrings.General;

        private SettingsCheckbox legacySkinUI = null!;

        [BackgroundDependencyLoader]
        private void load(OsuConfigManager config)
        {
            Children = new Drawable[]
            {
                legacySkinUI = new SettingsCheckbox
                {
                    LabelText = UserInterfaceStrings.LegacySkinUI,
                    Current = config.GetBindable<bool>(OsuSetting.LegacySkinUI),
                },
                new SettingsCheckbox
                {
                    LabelText = UserInterfaceStrings.CursorRotation,
                    Current = config.GetBindable<bool>(OsuSetting.CursorRotation)
                },
                new SettingsSlider<float, SizeSlider<float>>
                {
                    LabelText = UserInterfaceStrings.MenuCursorSize,
                    Current = config.GetBindable<float>(OsuSetting.MenuCursorSize),
                    KeyboardStep = 0.01f
                },
                new SettingsCheckbox
                {
                    LabelText = UserInterfaceStrings.Parallax,
                    Current = config.GetBindable<bool>(OsuSetting.MenuParallax)
                },
                new SettingsSlider<double, TimeSlider>
                {
                    ClassicDefault = 0,
                    LabelText = UserInterfaceStrings.HoldToConfirmActivationTime,
                    Current = config.GetBindable<double>(OsuSetting.UIHoldActivationDelay),
                    Keywords = new[] { @"delay" },
                    KeyboardStep = 50
                },
            };
            legacySkinUI.Current.BindValueChanged(LegacySkinUISetting =>
            {
                if (LegacySkinUISetting.NewValue)
                {
                    legacySkinUI.SetNoticeText(UserInterfaceStrings.LegacySkinUIWarning, true);
                }
                else
                {
                    legacySkinUI.ClearNoticeText();
                }
            }, true);
        }
    }
}
