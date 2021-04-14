using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace LambdaUnitTestExample
{
    public enum Condition
    {
        EXCELLENT,
        GOOD,
        FAIR,
        BAD
    };
    public class Car
    {
        public string Make;
        public int Speed {
            get {

                return _Speed; }
            set
            {
                _Speed = value;
                if (_Speed > 200)
                {
                    Speed = 200;
                }
                else if (_Speed < -50)
                {
                    Speed = -50;
                }
            }
        }
        private int _Speed;
        public Condition Condition;

    public Car(string mk, Condition con) {
            Make = mk;
            //spd = Speed;

            con = Condition; 
        }

    }
    public class Function
    {
        
        public string FunctionHandler(string input, ILambdaContext context)
        {
            return input?.ToUpper();
        }
    }
}
