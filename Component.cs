using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LiveSplit.UI.Components
{
    partial class AlternateFramerateComponent : LogicComponent
    {
        public override string ComponentName => "Alternate Framerate Converter";
        private readonly TimerModel timer;
        private LiveSplitState CurrentState;
        private AlternateFramerateSettings Settings { get; set; }

        public AlternateFramerateComponent(LiveSplitState state)
        {
            this.timer = new TimerModel { CurrentState = state };
            Settings = new AlternateFramerateSettings();
            CurrentState = state;
        }

        public override void Dispose()
        {
            Settings.Dispose();
        }

        public override XmlNode GetSettings(XmlDocument document)
        {
            return this.Settings.GetSettings(document);
        }

        public override System.Windows.Forms.Control GetSettingsControl(LayoutMode mode)
        {
            return this.Settings;
        }

        public override void SetSettings(XmlNode settings)
        {
            Settings.SetSettings(settings);
        }



        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            if (CurrentState.CurrentPhase.Equals(TimerPhase.Running))
            {
                TimeSpan currentRealTime = CurrentState.CurrentTime.RealTime.GetValueOrDefault();
                double realTimeMillis = currentRealTime.TotalMilliseconds;
                double convertedMillis = realTimeMillis / Settings.srcFramerate * Settings.adjFramerate;
                TimeSpan currentConvertedTime = TimeSpan.FromMilliseconds(convertedMillis);
                CurrentState.SetGameTime(currentConvertedTime);
            }
        }
    }
}
