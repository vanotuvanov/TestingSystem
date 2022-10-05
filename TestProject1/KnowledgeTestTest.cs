using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDeveloper.Domen;
using TestDeveloper.Infrastructure;

namespace TestProject1
{
    public class KnowledgeTestTest
    {
    
        
        public void TestAdd()
        {
            TestRepository personRepository;
            KnowledgeTest test;
            Guid testid;
            SettingProperties(out personRepository, out test, out testid);

            personRepository.AddAsync(test).Wait();

            Assert.Equal(testid, personRepository.GetAsync(testid).Result.Id);
            Assert.True(personRepository.GetAllAsync().Result.Count == 1);
            Assert.Equal("тестирование", personRepository.GetAsync(testid).Result.Title);
            Assert.Equal(3, personRepository.GetAsync(testid).Result.Option.NumberOfQuestions);
        }

        public static void SettingProperties(out TestRepository personRepository, out KnowledgeTest test, out Guid testid)
        {
            var testHelper = new TestHelper();
            personRepository = testHelper.TestRepository;
            test = new KnowledgeTest();
            test.Id = Guid.NewGuid();
            testid = test.Id;
            test.Title = "тестирование";
            test.Description = "описание";
            test.Option = new Option();
            Guid optionId = Guid.NewGuid();
            test.Option.Id = optionId;
            test.Option.TestTime = 30;
            test.Option.NumberOfQuestions = 3;
            test.Option.NumberOfEttemps = 2;
        }
    }
}