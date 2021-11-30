using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPFlyingVehicle
{
    public class ToyPlane : Airplane
    {
        bool isWoundUP
        {
            get { return ((ToyEngine)Engine).IsFullyWound; }
        }

        public ToyPlane()
        {
            this.MaxAltitude = 50;
            this.Engine = new ToyEngine();
        }

        public override void StartEngine()
        {
            Engine.Start();
        }

        public override string TakeOff()
        {
            if (isWoundUP)
                return base.TakeOff();
            else
                return $"{this.ToString()} can't fly it's engine is not wound up.";
        }

        public void WindUp()
        {
            while (((ToyEngine)Engine).IsFullyWound == false)
            {
                this.Wind();
            }
        }

        public void Wind()
        {
            ((ToyEngine)Engine).Wind();
        }

        public void UnWind()
        {
            ((ToyEngine)Engine).UnWind();
        }

        public void UnWindCompletely()
        {
            while (((ToyEngine)Engine).NumWinds > 0) 
            {
                UnWind();
            }
        }

        protected string getWindUpString()
        {
            string woundUp = "It's not wound up.";
            if(isWoundUP) woundUp = woundUp.Replace("not ", "");
            return woundUp;
        }

        public override string About()
        {
            return base.About() + "\n" + this.getWindUpString();
        }
    }
}
