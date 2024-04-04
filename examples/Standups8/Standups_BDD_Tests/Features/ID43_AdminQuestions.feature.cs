﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:1.0.0.0
//      Reqnroll Generator Version:1.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Standups_BDD_Tests.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "1.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("ID43_AdminQuestions")]
    [NUnit.Framework.CategoryAttribute("Scot")]
    public partial class ID43_AdminQuestionsFeature
    {
        
        private Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "Scot"};
        
#line 1 "ID43_AdminQuestions.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual async System.Threading.Tasks.Task FeatureSetupAsync()
        {
            testRunner = Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(null, NUnit.Framework.TestContext.CurrentContext.WorkerId);
            Reqnroll.FeatureInfo featureInfo = new Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "ID43_AdminQuestions", @"As an admin I would like to be able to ask students questions so that I can get feedback on a course.

This one assumes a single admin user.  It also needs students that already have a group set.  We can do this
in the seeding or we can ensure it in the Background (approach taken here).", ProgrammingLanguage.CSharp, featureTags);
            await testRunner.OnFeatureStartAsync(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
            await testRunner.OnFeatureEndAsync();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
        }
        
        public void ScenarioInitialize(Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        public virtual async System.Threading.Tasks.Task FeatureBackgroundAsync()
        {
#line 9
#line hidden
            Reqnroll.Table table1 = new Reqnroll.Table(new string[] {
                        "UserName",
                        "Email",
                        "FirstName",
                        "LastName",
                        "Password"});
            table1.AddRow(new string[] {
                        "TaliaK",
                        "knott@example.com",
                        "Talia",
                        "Knott",
                        "Hello123#"});
#line 10
 await testRunner.GivenAsync("the following users exist", ((string)(null)), table1, "Given ");
#line hidden
#line 13
 await testRunner.AndAsync("I am a user with first name \'Talia\'", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 14
 await testRunner.AndAsync("I login", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 15
 await testRunner.AndAsync("I am on the \"SelectGroup\" page", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 16
 await testRunner.AndAsync("I select a group", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 17
 await testRunner.AndAsync("I logout", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Admin can create questions that students can see")]
        [NUnit.Framework.CategoryAttribute("admin")]
        public async System.Threading.Tasks.Task AdminCanCreateQuestionsThatStudentsCanSee()
        {
            string[] tagsOfScenario = new string[] {
                    "admin"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            Reqnroll.ScenarioInfo scenarioInfo = new Reqnroll.ScenarioInfo("Admin can create questions that students can see", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 20
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 9
await this.FeatureBackgroundAsync();
#line hidden
#line 21
 await testRunner.GivenAsync("I am the admin", ((string)(null)), ((Reqnroll.Table)(null)), "Given ");
#line hidden
#line 22
  await testRunner.AndAsync("I login", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 23
  await testRunner.AndAsync("I am on the \"AdminQuestions\" page", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 24
 await testRunner.WhenAsync("I click on Create New question", ((string)(null)), ((Reqnroll.Table)(null)), "When ");
#line hidden
#line 25
  await testRunner.AndAsync("I create a new \"active\" question called \"question\"", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 26
  await testRunner.AndAsync("I logout", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 27
  await testRunner.AndAsync("I am a user with first name \'Talia\'", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 28
  await testRunner.AndAsync("I login", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 29
 await testRunner.ThenAsync("I can see a link for \"question\" on the page", ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion
