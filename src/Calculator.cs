using System;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using NUnit.Framework;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace karthickSpecflowCourse_linux_gl.src
{
    public class Calculator
    {
        List<int> operands;

        public Calculator()
        {
            operands = new List<int>();
            operands.Add(0);
        }

        public void enterNumber(int number) {
            operands.Add(number);       
        }

        public int sumAllNumbers() {
            int sum = 0;
            foreach (int o in operands) {
                sum += o;
            }
            operands.Clear();
            operands.Add(sum);
            return sum;
        }

        public int getLastResult() {
            return operands[0];
        }
    }
}