using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExperiment
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = InitializeAutomapper();
            IMapper mapper = config.CreateMapper();

            ClassA classA = new ClassA { Value = "B" };
            ClassB classB = mapper.Map<ClassB>(classA);



            Console.ReadLine();
        }

        static MapperConfiguration InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ClassA, ClassB>()
               .ForMember(b => b.Value, a => a.ConvertUsing<string>(new StringToEnumConverter<EnumTypes>(), y => y.Value));

            });
            return config;
        }
    }

    public class ClassA
    {
        public string Value { get; set; }
    }

    public class ClassB
    {
        public EnumTypes Value { get; set; }
    }


    public enum EnumTypes: short
    {
        A = 0,
        B = 1
    }
}
