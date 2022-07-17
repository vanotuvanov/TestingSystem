using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDeveloper.Domen;
using TestDeveloper.API.DTO;
using TestDeveloper.Infrastructure;

namespace TestProject1
{
    public class TestDTO
    {
        [Fact]
        public void DTOTestSingleCaseAnswers()
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

            KnowledgeTestDTO knowledgeTestDTO1 = new KnowledgeTestDTO(test);
            Assert.Equal(test.Id, knowledgeTestDTO1.Id);
            Assert.True(knowledgeTestDTO1.QuestionDTOs.Count == 1);
            Assert.Equal("вопрос", knowledgeTestDTO1.QuestionDTOs[0].Content);
        }


        [Fact]
        public void DTOTestMultipleCaseAnswer()
        {
            TestRepository personRepository;
            KnowledgeTest test;
            Guid testid;
            KnowledgeTestTest.SettingProperties(out personRepository, out test, out testid);
            Guid questionId = Guid.NewGuid();
            MultipleCaseQuestion multipleCaseQuestion = new MultipleCaseQuestion();
            multipleCaseQuestion.Id = questionId;
            multipleCaseQuestion.Content = "множественный вопрос";
            MultipleCaseAnswer multipleCaseAnswer1 = new MultipleCaseAnswer();
            MultipleCaseAnswer multipleCaseAnswer2 = new MultipleCaseAnswer();
            MultipleCaseAnswer multipleCaseAnswer3 = new MultipleCaseAnswer();
            Guid answerId1 = Guid.NewGuid(),
                answerId2 = Guid.NewGuid(),
                answerId3 = Guid.NewGuid();
            multipleCaseAnswer1.Id = answerId1;
            multipleCaseAnswer1.TrueVarriant = true;
            multipleCaseAnswer1.Content = "первый, правильный";
            multipleCaseAnswer2.Id = answerId2;
            multipleCaseAnswer2.TrueVarriant = false;
            multipleCaseAnswer2.Content = "второй, неправильный";
            multipleCaseAnswer3.Id = answerId3;
            multipleCaseAnswer3.TrueVarriant = true;
            multipleCaseAnswer3.Content = "третий, правильный";
            multipleCaseQuestion.MultipleCaseAnswers.Add(multipleCaseAnswer1);
            multipleCaseQuestion.MultipleCaseAnswers.Add(multipleCaseAnswer2);
            multipleCaseQuestion.MultipleCaseAnswers.Add(multipleCaseAnswer3);
            test.Questions.Add(multipleCaseQuestion);

            KnowledgeTestDTO knowledgeTestDTO = new KnowledgeTestDTO(test);
            Assert.Equal(test.Id, knowledgeTestDTO.Id);
            Assert.Equal("множественный вопрос", knowledgeTestDTO.QuestionDTOs[0].Content);
            Assert.Equal("первый, правильный", ((MultipleCaseQuestionDTO)knowledgeTestDTO.QuestionDTOs[0]).MultipleCaseAnswerDTOs[0].Content);
            Assert.Equal("второй, неправильный", ((MultipleCaseQuestionDTO)knowledgeTestDTO.QuestionDTOs[0]).MultipleCaseAnswerDTOs[1].Content);
            Assert.True(((MultipleCaseQuestionDTO)knowledgeTestDTO.QuestionDTOs[0]).MultipleCaseAnswerDTOs[0].TrueVarriant 
                == ((MultipleCaseQuestionDTO)knowledgeTestDTO.QuestionDTOs[0]).MultipleCaseAnswerDTOs[2].TrueVarriant);
        }

        [Fact]
        public void DTOTestMultipleAndSingleCaseAnswer()
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
            

            questionId = Guid.NewGuid();
            MultipleCaseQuestion multipleCaseQuestion = new MultipleCaseQuestion();
            multipleCaseQuestion.Id = questionId;
            multipleCaseQuestion.Content = "множественный вопрос";
            MultipleCaseAnswer multipleCaseAnswer1 = new MultipleCaseAnswer();
            MultipleCaseAnswer multipleCaseAnswer2 = new MultipleCaseAnswer();
            MultipleCaseAnswer multipleCaseAnswer3 = new MultipleCaseAnswer();
            answerId1 = Guid.NewGuid();
            answerId2 = Guid.NewGuid();
            Guid answerId3 = Guid.NewGuid();
            multipleCaseAnswer1.Id = answerId1;
            multipleCaseAnswer1.TrueVarriant = true;
            multipleCaseAnswer1.Content = "первый, правильный";
            multipleCaseAnswer2.Id = answerId2;
            multipleCaseAnswer2.TrueVarriant = false;
            multipleCaseAnswer2.Content = "второй, неправильный";
            multipleCaseAnswer3.Id = answerId3;
            multipleCaseAnswer3.TrueVarriant = true;
            multipleCaseAnswer3.Content = "третий, правильный";
            multipleCaseQuestion.MultipleCaseAnswers.Add(multipleCaseAnswer1);
            multipleCaseQuestion.MultipleCaseAnswers.Add(multipleCaseAnswer2);
            multipleCaseQuestion.MultipleCaseAnswers.Add(multipleCaseAnswer3);
            
            test.Questions.Add(singleCaseQuestion);
            test.Questions.Add(multipleCaseQuestion);

            KnowledgeTestDTO knowledgeTestDTO = new KnowledgeTestDTO(test);
            Assert.Equal(test.Id, knowledgeTestDTO.Id);
            Assert.True(knowledgeTestDTO.QuestionDTOs.Count == 2);
            Assert.Equal("вопрос", knowledgeTestDTO.QuestionDTOs[0].Content);
            Assert.True(((SingleCaseQuestionDTO)knowledgeTestDTO.QuestionDTOs[0]).SingleCaseAnswerDTOs[1].TrueVarriant);
            Assert.Equal("множественный вопрос", knowledgeTestDTO.QuestionDTOs[1].Content);
            Assert.Equal("первый, правильный", ((MultipleCaseQuestionDTO)knowledgeTestDTO.QuestionDTOs[1]).MultipleCaseAnswerDTOs[0].Content);
            Assert.Equal("второй, неправильный", ((MultipleCaseQuestionDTO)knowledgeTestDTO.QuestionDTOs[1]).MultipleCaseAnswerDTOs[1].Content);
            Assert.True(((MultipleCaseQuestionDTO)knowledgeTestDTO.QuestionDTOs[1]).MultipleCaseAnswerDTOs[0].TrueVarriant
                == ((MultipleCaseQuestionDTO)knowledgeTestDTO.QuestionDTOs[1]).MultipleCaseAnswerDTOs[2].TrueVarriant);
        }
    }
}