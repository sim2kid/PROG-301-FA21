using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPFlyingVehicle
{
    /*
        By Owen Ravelo
        Events and Collections
        Time: about 30 minutes
     */
    abstract public class AerialVehicle
    {
        public Engine Engine { get; protected set; }
        public bool IsFlying { get; protected set; }
        public int MaxAltitude { get; protected set; }
        public int CurrentAltitude { get; protected set; }
        protected int DefaultFlyAmount { get; set; }

        public event EventHandler OnTakeOff;

        public AerialVehicle()
        {
            this.Engine = new Engine();
            this.CurrentAltitude = 0;
            this.DefaultFlyAmount = 1000;
            this.OnTakeOff += onTakeOff;
        }

        public virtual void StartEngine()
        {
            Engine.Start();
        }

        public virtual void StopEngine()
        {
            Engine.Stop();
        }

        public void FlyUp()
        {
            FlyUp(DefaultFlyAmount);
        }

        public void FlyUp(int HowManyFeet)
        {
            if (HowManyFeet < 0) 
                throw new InvalidOperationException("Can't FlyUp a negative amount");
            CurrentAltitude = Math.Clamp(CurrentAltitude + HowManyFeet, 0, MaxAltitude);
        }

        public void FlyDown()
        {
            FlyDown(DefaultFlyAmount);
        }

        public void FlyDown(int HowManyFeet)
        {
            if (HowManyFeet < 0) 
                throw new InvalidOperationException("Can't FlyDown a negative amount");
            CurrentAltitude = Math.Clamp(CurrentAltitude - HowManyFeet, 0, MaxAltitude);
        }
        public virtual string TakeOff()
        {
            if (Engine.IsStarted)
            {
                IsFlying = true;
                return $"{this.ToString()} is flying"; ;
            }
            return $"{this.ToString()} can't fly it's engine is not started.";
        }

        protected void onTakeOff(object sender, EventArgs e) 
        {
            this.StartEngine();
            this.TakeOff();
        }

        public void SilentTakeOff() 
        {
            this.OnTakeOff.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Returns a string that describes if an engine is started
        /// </summary>
        /// <returns></returns>
        protected string getEngineStartedString()
        {
            return this.Engine.About();
        }

        public virtual string About()
        {
            string about = string.Format("This {0} has a max altitude of {1} ft. \nIt's current altitude is {2} ft. \n{3}", 
                this.ToString(), this.MaxAltitude.ToString(), this.CurrentAltitude, this.getEngineStartedString());
            return about;
            
        }
    }
}
