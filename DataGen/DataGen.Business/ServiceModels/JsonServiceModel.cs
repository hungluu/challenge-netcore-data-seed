using System;

namespace DataGen.Business.ServiceModels
{
    public class JsonServiceModel
    {
        public string OutputPath { get; set; }
        public int Count { get; set; }
        public string TemplateText { get; set; }

        public Predicate<int> StepCallback { get; set; }
    }
}
