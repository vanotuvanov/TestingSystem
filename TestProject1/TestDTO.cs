using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDeveloper.Domen;
using TestDeveloper.API;

namespace TestProject1
{
    public class TestDTO
    {
        [Fact]
        public void DTOTest()
        {
            KnowledgeTest test = new KnowledgeTest();
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

            TestDeveloper.API.DTO.KnowledgeTestDTO knowledgeTestDTO = new TestDeveloper.API.DTO.KnowledgeTestDTO(test);
            Assert.Equal(test.Id, knowledgeTestDTO.Id);
            Assert.True(knowledgeTestDTO.QuestionDTOs.Count == 1);
            Assert.Equal("вопрос", knowledgeTestDTO.QuestionDTOs);
        }
    }
}
