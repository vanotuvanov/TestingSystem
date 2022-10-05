using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDeveloper.Domen;
using TestDeveloper.Infrastructure;

namespace TestProject1
{

    public class SingleCaseQuestionTest
    {
        [Fact]
        public void SingleCaseQuestionAdd()
        {
            TestRepository personRepository;
            KnowledgeTest test;
            Guid testid;
            KnowledgeTestTest.SettingProperties(out personRepository, out test, out testid);
            Guid questionId = Guid.NewGuid();
            SingleCaseQuestion singleCaseQuestion = new SingleCaseQuestion();
            singleCaseQuestion.Id = questionId;
            singleCaseQuestion.Content = "вопрос";
            SingleCaseAnswer singleCaseAnswer1 = new SingleCaseAnswer();
            SingleCaseAnswer singleCaseAnswer2 = new SingleCaseAnswer();
            Guid answerId1 = Guid.NewGuid();
            singleCaseAnswer1.Id = answerId1;
            singleCaseAnswer1.TrueVarriant = false;
            singleCaseAnswer1.Content = "ответ 1";
            Guid answerId2 = Guid.NewGuid();
            singleCaseAnswer2.Id = answerId2;
            singleCaseAnswer2.TrueVarriant = true;
            singleCaseAnswer2.Content = "ответ 2";
            singleCaseQuestion.SingleCaseAnswers.Add(singleCaseAnswer1);
            singleCaseQuestion.SingleCaseAnswers.Add(singleCaseAnswer2);
            test.Questions.Add(singleCaseQuestion);

            personRepository.AddAsync(test).Wait();

            Assert.Equal(testid, personRepository.GetAsync(testid).Result.Id);
            Assert.True(personRepository.GetAllAsync().Result.Count == 1);
            Assert.Equal("вопрос", personRepository.GetAsync(testid).Result.Questions[0].Content);
            Assert.True(((SingleCaseQuestion)personRepository.GetAsync(testid).Result.Questions[0]).SingleCaseAnswers[1].TrueVarriant);
            Assert.Equal("ответ 2", ((SingleCaseQuestion)personRepository.GetAsync(testid).Result.Questions[0]).SingleCaseAnswers[1].Content);
        }
    }
}